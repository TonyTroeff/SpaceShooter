#region

using UnityEngine;
using UnityEngine.SceneManagement;

#endregion

public class RestartButtonController : MonoBehaviour
{
	public void Restart() => SceneManager.LoadScene(0);
}