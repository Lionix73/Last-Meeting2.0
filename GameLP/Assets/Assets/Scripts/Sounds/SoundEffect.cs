using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[DisallowMultipleComponent]

public class SoundEffect : MonoBehaviour
{
    private AudioSource audioSource;
    
    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable() {
        if(audioSource.clip != null)
        {
            audioSource.Play();
        }
    }

    private void OnDisable() {
        audioSource.Stop();
    }

    public void SetSound(SoundEffectSO SoundEffect)
    {
        audioSource.pitch = Random.Range(SoundEffect.SoundEffectPitchRandomVariationMin, SoundEffect.SoundEffectPitchRandomVariationMax);

        audioSource.volume = SoundEffect.SoundEffectVolume;
        audioSource.clip = SoundEffect.SoundEffectClip;
    }
}
