#region

using UnityEngine;

#endregion

namespace Helpers
{
	public static class MenuHelper
	{
		public static void ToggleSettingsMenu(GameObject settingsMenu, bool pause)
		{
			settingsMenu.SetActive(pause);

			// Pause the game.
			Time.timeScale = pause
				? 0
				: 1;
		}
	}
}