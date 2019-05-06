#region

using System.Linq;
using UnityEngine;

#endregion

public class ScoresController : MonoBehaviour
{
	private static ScoresController _instance;

	public ScoreInfo[] ScoreInfos;

	private void Awake()
	{
		if (_instance == null) _instance = this;
		else if (_instance != this) Destroy(this.gameObject);

		DontDestroyOnLoad(_instance);
	}

	public static int GetPoints(string name) => _instance.ScoreInfos.Single(
			si => si.Name
				== name.Replace("(Clone)", string.Empty)
					.Trim())
		.Points;
}