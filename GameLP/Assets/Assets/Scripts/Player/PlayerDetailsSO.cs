using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDetails_", menuName = "Scriptable Objects/Player/PlayerDetails")]
public class PlayerDetailsSO : ScriptableObject
{
    #region Header PLAYER BASE DETAILS
    [Space(10)]
    [Header("PLAYER BASE DETAILS")]
    #endregion
    #region Tooltip
    [Tooltip("Player character name.")]
    #endregion
    public string playerCharacterName;

    #region Tooltip
    [Tooltip("Prefab gameobject for the player")]
    #endregion
    public GameObject playerPrefab;

    #region Tooltip
    [Tooltip("Player runtime animator controller")]
    #endregion
    public RuntimeAnimatorController runtimeAnimatorController;

    #region Header HEALTH
    [Space(10)]
    [Header("HEALTH")]
    #endregion
    public int playerHealthAmount;

    public bool isInmuneAfterHit = false;

    public float hitInmunityTime;

    #region Header WEAPON
    [Space(10)]
    [Header("WEAPON")]
    #endregion
    public WeaponsDetailsSO startingWeapon;

    public List<WeaponsDetailsSO> startingWeaponList;

    #region Header OTHER
    [Space(10)]
    [Header("OTHER")]
    #endregion
    public Sprite playerMiniMapIcon;

    public Sprite playerHandSprite;

    #region Validation
#if UNITY_EDITOR
    private void OnValidate()
    {
        HelperUtilities.ValidateCheckEmptyString(this, nameof(playerCharacterName), playerCharacterName);
        HelperUtilities.ValidateCheckNullValue(this, nameof(playerPrefab), playerPrefab);
        HelperUtilities.ValidateCheckPositiveValue(this, nameof(playerHealthAmount), playerHealthAmount, false);
        HelperUtilities.ValidateCheckNullValue(this, nameof(startingWeapon), startingWeapon);
        HelperUtilities.ValidateCheckNullValue(this, nameof(playerMiniMapIcon), playerMiniMapIcon);
        HelperUtilities.ValidateCheckNullValue(this, nameof(playerHandSprite), playerHandSprite);
        HelperUtilities.ValidateCheckNullValue(this, nameof(runtimeAnimatorController), runtimeAnimatorController);
        HelperUtilities.ValidateCheckEnumerableValues(this, nameof(startingWeaponList), startingWeaponList);

        if(isInmuneAfterHit)
        {
            HelperUtilities.ValidateCheckPositiveValue(this, nameof(hitInmunityTime), hitInmunityTime, false);
        }
    }
#endif
    #endregion
}
