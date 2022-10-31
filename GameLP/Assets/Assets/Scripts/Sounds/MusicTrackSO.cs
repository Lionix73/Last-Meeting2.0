using UnityEngine;

[CreateAssetMenu(fileName = "Music Track", menuName = "Scriptable Objects/Sounds/MusicTrack")]
public class MusicTrackSO : ScriptableObject
{
	#region Header MUSIC TRACK DETAILS
	[Space(10)]
	[Header("MUSIC TRACK DETAILS")]
	#endregion

	public string musicName;
	public AudioClip musicClip;
	public float musicVolume = 1f;

	private void OnValidate()
	{
		HelperUtilities.ValidateCheckEmptyString(this, nameof(musicName), musicName);
		HelperUtilities.ValidateCheckNullValue(this, nameof(musicClip), musicClip);
		HelperUtilities.ValidateCheckPositiveValue(this, nameof(musicVolume), musicVolume, true);
	}
}
