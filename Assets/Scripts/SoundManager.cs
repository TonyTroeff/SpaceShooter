#region

using UnityEngine;

#endregion

public class SoundManager : MonoBehaviour
{
	private static SoundManager _instance;

	private void Awake()
	{
		if (_instance == null) _instance = this;
		else if (_instance != this) Destroy(this.gameObject);

		DontDestroyOnLoad(_instance);
	}
}