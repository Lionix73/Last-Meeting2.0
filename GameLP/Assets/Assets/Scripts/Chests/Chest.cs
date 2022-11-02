using System.Collections;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(MaterializeEffects))]
public class Chest : MonoBehaviour, IUseable
{
    [ColorUsage(false, true)]
    [SerializeField] private Color materializeColor;
    [SerializeField] private float materializeTime = 3f;
    [SerializeField] private Transform itemSpawnPoint;

    private int healthPercent;
    private WeaponsDetailsSO weaponsDetails;
    private int ammoPercent;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private MaterializeEffects materializeEffects;
    private bool isEnabled = false;
    private ChestState chestState = ChestState.closed;
    private GameObject chestItemGameObject;
    private ChestItem chestItem;
    private TextMeshPro messageTextTMP;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        materializeEffects = GetComponent<MaterializeEffects>();
        messageTextTMP = GetComponent<TextMeshPro>();
    }

    public void Initialize(bool shouldMaterialize, int healthPercent, WeaponsDetailsSO weaponDetails, int ammoPercent)
    {
        this.healthPercent = healthPercent;
        this.weaponsDetails = weaponDetails;
        this.ammoPercent = ammoPercent;

        if (shouldMaterialize)
        {
            StartCoroutine(MaterializeChest());
        }
        else
        {
            EnableChest();
        }
    }

    private IEnumerator MaterializeChest()
    {
        SpriteRenderer[] spriteRendererArray = new SpriteRenderer[] {spriteRenderer };

        yield return StartCoroutine(materializeEffects.MaterializeRoutine(GameResources.Instance.materializeShader, materializeColor, materializeTime, spriteRendererArray, GameResources.Instance.litMaterial));

        EnableChest();
    }

    private void EnableChest()
    {
        isEnabled = true;
    }

    public void UseItem()
    {
        if (!isEnabled) return;

        switch (chestState)
        {
            case ChestState.closed:
                OpenChest();
                break;

            case ChestState.healthItem:
                CollectHealthItem();
                break;

            case ChestState.ammoItem:
                CollectAmmoItem();
                break;

            case ChestState.weaponItem:
                CollectWeaponItem();
                break;

            case ChestState.empty:
                break;

            default:
                break;
        }
    }

    private void OpenChest()
    {
        animator.SetBool(Settings.use, true);

        SoundEffectManager.Instance.PlaySoundEffect(GameResources.Instance.chestOpen);

        if (weaponsDetails != null)
        {
            if (GameManager.Instance.GetPlayer().IsWeaponHeldByPlayer(weaponsDetails))
                weaponsDetails = null;
        }

        UpdateChestState();
    }

    private void UpdateChestState()
    {
        if (healthPercent != 0)
        {
            chestState = ChestState.healthItem;
            InstantiateHealthItem();
        }
        else if (ammoPercent != 0)
        {
            chestState = ChestState.ammoItem;
            InstantiateAmmoItem();
        }
        else if (weaponsDetails != null)
        {
            chestState = ChestState.weaponItem;
            InstantiateWeaponItem();
        }
        else
        {
            chestState = ChestState.empty;
        }
    }

    private void InstantiateItem()
    {
        chestItemGameObject = Instantiate(GameResources.Instance.chestItemPrefab, this.transform);

        chestItem = chestItemGameObject.GetComponent<ChestItem>();
    }

    private void InstantiateHealthItem()
    {
        InstantiateItem();

        chestItem.Initialize(GameResources.Instance.heartIcon, healthPercent.ToString() + "%", itemSpawnPoint.position, materializeColor);
    }

    private void CollectHealthItem()
    {
        if (chestItem == null || !chestItem.isItemMaterialized) return;

        GameManager.Instance.GetPlayer().health.AddHealth(healthPercent);

        SoundEffectManager.Instance.PlaySoundEffect(GameResources.Instance.healthPickUp);

        healthPercent = 0;

        Destroy(chestItemGameObject);

        UpdateChestState();
    }

    private void InstantiateAmmoItem()
    {
        InstantiateItem();

        chestItem.Initialize(GameResources.Instance.bulletIcon, ammoPercent.ToString() + "%", itemSpawnPoint.position, materializeColor);
    }

    private void CollectAmmoItem()
    {
        if (chestItem == null || !chestItem.isItemMaterialized) return;

        Player player = GameManager.Instance.GetPlayer();

        player.reloadWeaponEvent.CallRealoadWeaponEvent(player.activeWeapon.GetCurrentWeapon(), ammoPercent);

        SoundEffectManager.Instance.PlaySoundEffect(GameResources.Instance.ammoPickUp);

        ammoPercent = 0;

        Destroy(chestItemGameObject);

        UpdateChestState();
    }

    private void InstantiateWeaponItem()
    {
        InstantiateItem();

        chestItemGameObject.GetComponent<ChestItem>().Initialize(weaponsDetails.weaponSprite, weaponsDetails.weaponName, itemSpawnPoint.position, materializeColor);
    }
    
    private void CollectWeaponItem()
    {
        if (chestItem == null || !chestItem.isItemMaterialized) return;

        if (!GameManager.Instance.GetPlayer().IsWeaponHeldByPlayer(weaponsDetails))
        {
            GameManager.Instance.GetPlayer().AddWeaponToPlayer(weaponsDetails);

            SoundEffectManager.Instance.PlaySoundEffect(GameResources.Instance.weaponPickUp);
        }

        else
        {
            StartCoroutine(DisplayMessage("ARMA\nYA\nEQUIPADA", 5f));
        }
        weaponsDetails = null;

        Destroy(chestItemGameObject);

        UpdateChestState();
    }

    private IEnumerator DisplayMessage(string messageText, float messageDisplayTime)
    {
        messageTextTMP.text = messageText;

        yield return new WaitForSeconds(messageDisplayTime);

        messageTextTMP.text = "";
    }
}
