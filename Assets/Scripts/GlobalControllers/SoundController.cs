#region

using System;
using UnityEngine;
using UnityEngine.Audio;

#endregion

namespace GlobalControllers
{
	public class SoundController : MonoBehaviour
	{
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
			float initialVolumeLevel = PlayerPrefs.GetFloat("MasterVolume", 1f);
			ChangeVolume(initialVolumeLevel);
		}

		public static void ChangeVolume(float newVolumeLevel)
		{
			PlayerPrefs.SetFloat("MasterVolume", newVolumeLevel);

			float convertedVolumeLevel = ConvertToDecibels(newVolumeLevel);
			Instance.AudioMixer.SetFloat("MasterVolume", convertedVolumeLevel);
		}

		private static float ConvertToDecibels(float volumeLevel) => Mathf.Log10(volumeLevel) * 20f;
	}
}