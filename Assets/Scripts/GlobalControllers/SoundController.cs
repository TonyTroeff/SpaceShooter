#region

using UnityEngine;

#endregion

namespace GlobalControllers
{
	public class SoundController : MonoBehaviour
	{
		private static SoundController _instance;

		private void Awake()
		{
			if (_instance == null) _instance = this;
			else if (_instance != this) Destroy(this.gameObject);

			DontDestroyOnLoad(_instance);
		}
	}
}