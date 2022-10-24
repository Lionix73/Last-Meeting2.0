using UnityEngine;

[CreateAssetMenu(fileName = "SoundEffect_", menuName = "Scriptable Objects/Sounds/SoundEffect")]

public class SoundEffectSO : ScriptableObject 
{
    #region  Header SOUND EFFECT DETAILS
    [Space(10)]
    [Header("SOUND EFFECT DETAILS")]
    #endregion 

    #region Tooltip
    [Tooltip("The name for the sound effect")]
    #endregion

    public string SoundEffectName;

    #region  Tooltip
    [Tooltip("The prefab for the sound effect")]
    #endregion

    public GameObject soundPrefab;

    #region  Tooltip
    [Tooltip("The audio clip for the sound effect")]
    #endregion

    public AudioClip SoundEffectClip;


    [Range(0.1f, 1.5f)]
    public float SoundEffectPitchRandomVariationMin = 0.8f;

    [Range(0.1f, 1.5f)]
    public float SoundEffectPitchRandomVariationMax = 1.2f;

    [Range(0f, 1f)]
    public float SoundEffectVolume = 1f;


    private void OnValidate() 
    {
        HelperUtilities.ValidateCheckEmptyString(this, nameof(SoundEffectName), SoundEffectName);
        HelperUtilities.ValidateCheckNullValue(this, nameof(soundPrefab), soundPrefab);
        HelperUtilities.ValidateCheckNullValue(this, nameof(SoundEffectClip), SoundEffectClip);
        HelperUtilities.ValidateCheckPositiveRange(this, nameof(SoundEffectPitchRandomVariationMin), SoundEffectPitchRandomVariationMin,
                        nameof(SoundEffectPitchRandomVariationMax), SoundEffectPitchRandomVariationMax, false);
        
        HelperUtilities.ValidateCheckPositiveValue(this, nameof(SoundEffectVolume), SoundEffectVolume, true);
    }
}