using UnityEngine;

[CreateAssetMenu(fileName = "WeaponDetails_", menuName = "Scriptable Objects/Weapons/Weapon Details")]
public class WeaponsDetailsSO : ScriptableObject
{
    #region Header WEAPON BASE DETAILS
    [Space(10)]
    [Header("WEAPON BASE DETAILS")]
    #endregion Header WEAPON BASE DETAILS

    public string weaponName;

    public Sprite weaponSprite;

    #region Header WEAPON CONFIGURATION
    [Space(10)]
    [Header("WEAPON CONFIGURATION")]
    #endregion Header WEAPON CONFIGURATION

    public Vector3 weaponShootPosition;

    public AmmoDetailsSO weaponCurrentAmmo;

    #region  Tooltip
    [Tooltip("the firing sound effect SO for the weapon")]
    #endregion

    public SoundEffectSO weaponFiringSoundEffect;

    #region  Tooltip
    [Tooltip("the reloading sound effect SO for the weapon")]
    #endregion

    public SoundEffectSO weaponReloadingSoundEffect;

    #region Header WEAPON OPERATING VALUES 
    [Space(10)]
    [Header("WEAPON OPERATING VALUES")]
    #endregion Header WEAPON OPERATING VALUES

    public bool hasInfiniteAmmo = false;

    public bool hasInfiniteClipCapacity = false;

    public int weaponClipAmmoCapacity = 6;

    public int weaponAmmoCapacity = 100;

    public float weaponFireRate = 0.2f;

    public float weaponPrechargeTime = 0f;

    public float weaponReloadTime = 0f;

    #region Validation
#if UNITY_EDITOR
    private void OnValidate()
    {
        HelperUtilities.ValidateCheckEmptyString(this, nameof(weaponName), weaponName);
        HelperUtilities.ValidateCheckNullValue(this, nameof(weaponCurrentAmmo), weaponCurrentAmmo);
        HelperUtilities.ValidateCheckPositiveValue(this, nameof(weaponFireRate), weaponFireRate, false);
        HelperUtilities.ValidateCheckPositiveValue(this, nameof(weaponPrechargeTime), weaponPrechargeTime, true);

        if (!hasInfiniteAmmo)
        {
            HelperUtilities.ValidateCheckPositiveValue(this, nameof(weaponAmmoCapacity), weaponAmmoCapacity, false);
        }

        if (!hasInfiniteClipCapacity)
        {
            HelperUtilities.ValidateCheckPositiveValue(this, nameof(weaponClipAmmoCapacity), weaponClipAmmoCapacity, false);
        }
    }
#endif
    #endregion
}

