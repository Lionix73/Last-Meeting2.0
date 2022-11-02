using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(MaterializeEffects))]
public class ChestItem : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private TextMeshPro textTMP;
    private MaterializeEffects materializeEffects;
    [HideInInspector] public bool isItemMaterialized = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        textTMP = GetComponent<TextMeshPro>();
        materializeEffects = GetComponent<MaterializeEffects>();
    }

    public void Initialize(Sprite sprite, string text, Vector3 spawnPosition, Color materializeColor)
    {
        spriteRenderer.sprite = sprite;
        transform.position = spawnPosition;

        StartCoroutine(MaterializeItem(materializeColor, text));
    }

    private IEnumerator MaterializeItem(Color materializeColor, string text)
    {
        SpriteRenderer[] spriteRendererArray = new SpriteRenderer[] { spriteRenderer };

        yield return StartCoroutine(materializeEffects.MaterializeRoutine(GameResources.Instance.materializeShader, materializeColor, 1f, spriteRendererArray, GameResources.Instance.litMaterial));

        isItemMaterialized = true;

        textTMP.text = text;
    }
}
