#region

using UnityEngine;
using UnityEngine.SceneManagement;

#endregion

namespace Helpers
{
	public static class MenuHelper
	{
		private static bool _isPaused;

		public static void ToggleSettingsMenu(GameObject settingsMenu)
		{
			settingsMenu.SetActive(!_isPaused);

			TogglePause();
		}

		public static void TogglePause()
		{
			Time.timeScale = _isPaused
				? 1
				: 0;
			_isPaused = !_isPaused;
		}

		public static void Restart()
		{
			if (_isPaused) TogglePause();
			SceneManager.LoadScene(0);
		}

		public static void Exit() => Application.Quit();
	}
}