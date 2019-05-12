namespace GlobalControllers
{
	using System.Linq;
	using UnityEngine;
	using Utilities;

	public class ScoresController : MonoBehaviour
	{
		static private ScoresController _instance;

		public ScoreInfo[] ScoreInfos;

		private void Awake()
		{
			if (_instance == null) _instance = this;
			else if (_instance != this) Destroy(this.gameObject);

			DontDestroyOnLoad(_instance);
		}

		static public int GetPoints(string name)
			=> _instance.ScoreInfos.Single(
					si => si.Name == name.Replace("(Clone)", string.Empty)
						.Trim())
				.Points;
	}
}