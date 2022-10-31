using System.Collections;
using UnityEngine;

[RequireComponent(typeof(HealthEvent))]
[DisallowMultipleComponent]

public class Health : MonoBehaviour
{
    #region Header References
    [Space(10)]
    [Header("References")]
    #endregion
    #region Tooltip
    [Tooltip("Populate with the HealthBar component on the HealthBar gameobject")]
    #endregion
    [SerializeField] private HealthBar healthBar;

    private int startingHealth;
    private int currentHealth;
    private HealthEvent healthEvent;
    private Player player;
    private Coroutine inmunityCoroutine;
    private bool isInmuneAfterHit = false;
    private float inmunityTime = 0f;
    private SpriteRenderer spriteRenderer = null;
    private const float spriteFlashInterval = 0.2f;
    private WaitForSeconds waitForSecondsSpriteFlashInterval = new WaitForSeconds(spriteFlashInterval);

    [HideInInspector] public bool isDamageable = true;
    [HideInInspector] public Enemy enemy;

    private void Awake() 
    {
        healthEvent = GetComponent<HealthEvent>();
    }

    private void Start() {
        CallHealthEvent(0);

        player = GetComponent<Player>();
        enemy = GetComponent<Enemy>();

        if(player != null)
        {
            if(player.playerDetails.isInmuneAfterHit)
            {
                isInmuneAfterHit = true;
                inmunityTime = player.playerDetails.hitInmunityTime;
                spriteRenderer = player.spriteRenderer;
            }
        }
        else if(enemy != null)
        {
            if(enemy.enemyDetails.isInmuneAfterHit)
            {
                isInmuneAfterHit = true;
                inmunityTime = enemy.enemyDetails.hitInmunityTime;
                spriteRenderer = enemy.spriteRendererArray[0];
            }
        }

        if(enemy != null && enemy.enemyDetails.isHealthBarDisplayed == true && healthBar != null)
        {
            healthBar.EnableHealthBar();
        }
        else if(healthBar != null)
        {
            healthBar.DisableHealthBar();
        }
    }

    public void TakeDamage(int damageAmount)
    {
        bool isRolling = false;

        if(player != null)
        {
            isRolling = player.playerControl.isPlayerRolling;
        }

        if(isDamageable && !isRolling)
        {
            currentHealth -= damageAmount;
            CallHealthEvent(damageAmount);

            PostHitInmunity();

            if(healthBar != null)
            {
                healthBar.SetHealthBarValue((float)currentHealth / (float)startingHealth);
            }
        }

        // if(isDamageable && isRolling)
        // {
        //     Debug.Log("Dodged bullet by Rolling");
        // }
    }

    private void PostHitInmunity()
    {
        if(gameObject.activeSelf == false) return;

        if(isInmuneAfterHit)
        {
            if(inmunityCoroutine != null)
            {
                StopCoroutine(inmunityCoroutine);
            }

            inmunityCoroutine = StartCoroutine(PostHitInmunityRoutine(inmunityTime, spriteRenderer));
        }
    }

    private IEnumerator PostHitInmunityRoutine(float inmunityTime, SpriteRenderer spriteRenderer)
    {
        int iterations = Mathf.RoundToInt(inmunityTime / spriteFlashInterval / 2f);

        isDamageable = false;

        while (iterations > 0)
        {
            spriteRenderer.color = Color.red;

            yield return waitForSecondsSpriteFlashInterval;

            spriteRenderer.color = Color.white;

            yield return waitForSecondsSpriteFlashInterval;

            iterations--;

            yield return null;
        }

        isDamageable = true;
    }

    private void CallHealthEvent(int damageAmount)
    {
        healthEvent.CallHealthChangedEvent(((float)currentHealth / (float)startingHealth), currentHealth, damageAmount);
    }

    public void SetStartingHealth(int startingHealth)
    {
        this.startingHealth = startingHealth;
        currentHealth = startingHealth;
    }

    public int GetStartingHealth()
    {
        return startingHealth;
    }
}
