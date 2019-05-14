namespace GlobalControllers
{
	using UnityEngine;
	using UnityEngine.Audio;

	public class SoundController : MonoBehaviour
	{
		private static readonly string[] _audioMixerVariables = { "BackgroundVolume", "SFXVolume" };

		public AudioMixer AudioMixer;

		public static SoundController Instance { get; private set; }

		private void Awake()
		{
			if (Instance == null) Instance = this;
			else if (Instance != this) Destroy(this.gameObject);

			DontDestroyOnLoad(Instance);
		}

		private void Start()
		{
			foreach (string audioMixerVariable in _audioMixerVariables)
			{
				float backgroundVolumeLevel = PlayerPrefs.GetFloat(audioMixerVariable, 1f);
				ChangeVolume(backgroundVolumeLevel, audioMixerVariable);
			}
		}

		public static void ChangeVolume(float newVolumeLevel, string source)
		{
			PlayerPrefs.SetFloat(source, newVolumeLevel);

			float convertedVolumeLevel = ConvertToDecibels(newVolumeLevel);
			Instance.AudioMixer.SetFloat(source, convertedVolumeLevel);
		}

		private static float ConvertToDecibels(float volumeLevel) => Mathf.Log10(volumeLevel) * 20f;
	}
}