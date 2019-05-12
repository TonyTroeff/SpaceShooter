namespace Helpers
{
	using UnityEngine;
	using UnityEngine.SceneManagement;

	static public class MenuHelper
	{
		static private bool _isPaused;

		static public void ToggleSettingsMenu(GameObject settingsMenu)
		{
			settingsMenu.SetActive(!_isPaused);

			TogglePause();
		}

		static public void TogglePause()
		{
			Time.timeScale = _isPaused ? 1 : 0;

			_isPaused = !_isPaused;
		}

		static public void Restart()
		{
			if (_isPaused) TogglePause();
			SceneManager.LoadScene(0);
		}

		static public void Exit() => Application.Quit();
	}
}