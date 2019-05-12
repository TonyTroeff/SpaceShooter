using UnityEngine;

public class ScreenController : MonoBehaviour
{
	static public Vector3 Dimensions { get; private set; }

	private void Awake()
	{
		Vector3 screenValues = new Vector3(Screen.width, Screen.height, 0);
		Dimensions = Camera.main.ScreenToWorldPoint(screenValues);
	}
}