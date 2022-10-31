using UnityEngine;

public class HealthBar : MonoBehaviour
{
    #region Header Gameobject References
    [Space(10)]
    [Header("Gameobject References")]
    #endregion Header Gameobject References

    #region Tooltip
    [Tooltip("Populate with the child bar gameobject")]
    #endregion Tooltip

    [SerializeField] private GameObject healthBar;

    public void EnableHealthBar()
    {
        gameObject.SetActive(true);
    }

    public void DisableHealthBar()
    {
        gameObject.SetActive(false);
    }

    public void SetHealthBarValue(float healthPercent)
    {
        healthBar.transform.localScale = new Vector3(healthPercent, 1f, 1f);
    }
}
