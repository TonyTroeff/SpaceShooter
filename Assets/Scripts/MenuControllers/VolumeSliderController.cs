#region

using GlobalControllers;
using UnityEngine;
using UnityEngine.UI;

#endregion

namespace MenuControllers
{
	public class VolumeSliderController : MonoBehaviour
	{
		public string Source;

		private void Start()
		{
			this.GetComponent<Slider>()
				.value = PlayerPrefs.GetFloat(this.Source, 1f);
		}

		public void OnVolumePreferencesChanged(float newValue) { SoundController.ChangeVolume(newValue, this.Source); }
	}
}