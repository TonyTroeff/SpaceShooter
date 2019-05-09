using UnityEngine;

namespace MenuControllers
{
	public class SettingsButtonController : MonoBehaviour
	{
		public GameObject SettingsMenu;

		private bool _setActive = true;

		public void OpenSettings()
		{
			this.SettingsMenu.SetActive(this._setActive);
			this._setActive = !this._setActive;

			// Pause the game.
			Time.timeScale = this._setActive
				? 1
				: 0;
		}
	}
}