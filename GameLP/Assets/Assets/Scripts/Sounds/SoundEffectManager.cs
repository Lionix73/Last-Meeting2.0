using System.Collections;
using UnityEngine;

[DisallowMultipleComponent]

public class SoundEffectManager : SingletonMonobehaviour<SoundEffectManager>
{
    public int soundsVolume = 8;

    private void Start() 
    {
        if (PlayerPrefs.HasKey("soundsVolume"))
        {
            SetSoundsVolume(soundsVolume);
        }

        SetSoundsVolume(soundsVolume);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("soundsVolume", soundsVolume);
    }

    public void PlaySoundEffect(SoundEffectSO SoundEffect)
    {
        SoundEffect sound = (SoundEffect)PoolManager.Instance.ReuseComponent(SoundEffect.soundPrefab, Vector3.zero, Quaternion.identity);

        sound.SetSound(SoundEffect);
        sound.gameObject.SetActive(true);
        StartCoroutine(DisableSound(sound, SoundEffect.SoundEffectClip.length));
    }

    private IEnumerator DisableSound(SoundEffect sound, float soundDuration)
    {
        yield return new WaitForSeconds(soundDuration);
        sound.gameObject.SetActive(false);
    }

    public void IncreaeSoundsVolume()
    {
        int maxSoundsVolume = 20;

        if (soundsVolume >= maxSoundsVolume) return;

        soundsVolume += 1;

        SetSoundsVolume(soundsVolume);
    }

    public void DecreaseSoundsVolume()
    {
        if (soundsVolume == 0) return;

        soundsVolume -= 1;

        SetSoundsVolume(soundsVolume);
    }

    private void SetSoundsVolume(int soundsVolume)
    {
        float muteDecibels = -80f;

        if(soundsVolume == 0)
        {
            GameResources.Instance.soundsMasterMixerGroup.audioMixer.SetFloat("soundsVolume", muteDecibels);
        }
        else
        {
            GameResources.Instance.soundsMasterMixerGroup.audioMixer.SetFloat("soundsVolume", HelperUtilities.LinearToDecibels(soundsVolume));
        }
    }
}
