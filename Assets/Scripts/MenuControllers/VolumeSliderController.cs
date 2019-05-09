using GlobalControllers;
using UnityEngine;
using UnityEngine.UI;

namespace MenuControllers
{
	public class VolumeSliderController : MonoBehaviour
	{
		private void Awake()
		{
			this.GetComponent<Slider>()
				.value = PlayerPrefs.GetFloat("MasterVolume", 1f);
		}

		public void OnVolumePreferencesChanged(float newValue) { SoundController.ChangeVolume(newValue); }
	}
}