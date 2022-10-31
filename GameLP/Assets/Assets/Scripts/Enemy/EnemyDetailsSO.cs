using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDetails_", menuName = "Scriptable Objects/Enemy/EnemyDetails")]

public class EnemyDetailsSO : ScriptableObject
{
    #region Header BASE ENEMY DETAILS
    [Space(10)]
    [Header("BASE ENEMY DETAILS")]
    #endregion

    #region Tooltip
    [Tooltip("The name of the enemy")]
    #endregion

    public string enemyName;

    #region Tooltip
    [Tooltip("The prefab for the enemy")]
    #endregion

    public GameObject enemyPrefab;

    #region Tooltip
    [Tooltip("Distance to the player before enemy starts chasing")]
    #endregion    

    public float chaseDistance = 50f;

    public Material enemyStandardMaterial;

    #region Header ENEMY MATERIALIZE SETTINGS
    [Space(10)]
    [Header("ENEMY MATERIALIZE SETTINGS")]
    #endregion

    public float enemyMaterializeTime;
    public Shader enemyMaterializeShader;
    public Color enemyMaterializeColor;

    #region Header ENEMY WEAPON SETTINGS
    [Space(10)]
    [Header("ENEMY WEAPON SETTINGS")]
    #endregion

    public WeaponsDetailsSO enemyWeapon;

    public float firingIntervalMin = 0.1f;
    public float firingIntervalMax = 1f;

    public float firingDurationMin = 1f;
    public float firingDurationMax = 2f;

    public bool firingLineOfSightRequired;


    #region Header ENEMY HEALTH
    [Space(10)]
    [Header("ENEMY HEALTH")]
    #endregion
    #region Tooltip
    [Tooltip("The health of the enemy for each level")]
    #endregion  
    public EnemyHealthDetails[] enemyHealthDetailsArray;

    #region Tooltip
    [Tooltip("Select if the inmunity inmediately after being hit. If so specify the inmunity time in seconds in the other field")]
    #endregion  
    public bool isInmuneAfterHit = false;

    #region Tooltip
    [Tooltip("Inmunity in seconds after being hit")]
    #endregion  
    public float hitInmunityTime;

    #region Tooltip
    [Tooltip("Select to display a health bar for the enemy")]
    #endregion
    public bool isHealthBarDisplayed = false;

    private void OnValidate() {
        HelperUtilities.ValidateCheckEmptyString(this, nameof(enemyName), enemyName);
        HelperUtilities.ValidateCheckNullValue(this, nameof(enemyPrefab), enemyPrefab);
        HelperUtilities.ValidateCheckPositiveValue(this, nameof(chaseDistance), chaseDistance, false);
        HelperUtilities.ValidateCheckNullValue(this, nameof(enemyStandardMaterial), enemyStandardMaterial);
        HelperUtilities.ValidateCheckPositiveValue(this, nameof(enemyMaterializeTime), enemyMaterializeTime, true);
        HelperUtilities.ValidateCheckNullValue(this, nameof(enemyMaterializeShader), enemyMaterializeShader);
        HelperUtilities.ValidateCheckPositiveRange(this, nameof(firingIntervalMin), firingIntervalMin, nameof(firingIntervalMax), firingIntervalMax, false);
        HelperUtilities.ValidateCheckPositiveRange(this, nameof(firingDurationMin), firingDurationMin, nameof(firingDurationMax), firingDurationMax, false);
        HelperUtilities.ValidateCheckEnumerableValues(this, nameof(enemyHealthDetailsArray), enemyHealthDetailsArray);

        if(isInmuneAfterHit)
        {
            HelperUtilities.ValidateCheckPositiveValue(this, nameof(hitInmunityTime), hitInmunityTime, false);
        }
    }
}
