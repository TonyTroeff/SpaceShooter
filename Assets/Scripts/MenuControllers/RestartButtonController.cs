#region

using UnityEngine;
using UnityEngine.SceneManagement;

#endregion

namespace MenuControllers
{
	public class RestartButtonController : MonoBehaviour
	{
		public void Restart() => SceneManager.LoadScene(0);
	}
}