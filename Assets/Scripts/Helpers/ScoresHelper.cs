namespace Helpers
{
	using UnityEngine;
	using Utilities;

	public class ScoresHelper : MonoBehaviour
	{
		public static int GetPoints(GameObject gameObject)
			=> gameObject.GetComponent<ScoreInfo>()
				.Points;
	}
}