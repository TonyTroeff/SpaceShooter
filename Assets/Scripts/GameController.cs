namespace SpaceShooter
{
	using System.Collections.Generic;
	using Helpers;
	using Serialization;
	using UnityEngine;
	using UnityEngine.UI;
	using Utilities;

	public class GameController : MonoBehaviour
	{
		public delegate void OnWaveSpawnDelegate(int waveCount);

		private Transform _enemiesContainer;
		private int _score;
		private int _waveCount;

		public GameObject[] Enemies;
		public int EnemiesPerWave;
		public float EnemiesSpawnOffset;
		public Text HighestScoreBoard;

		public GameObject RestartMenu;
		public Text ScoreBoard;
		public GameObject SettingsMenu;

		public float StartDelay;
		public int WavesSpawnOffset;

		public static PlayerProgressInfo PlayerProgressInfo { get; private set; }
		public static bool PlayerIsAlive { get; private set; } = true;

		public static event OnWaveSpawnDelegate OnWaveSpawn;

		private void Awake()
		{
			PlayerIsAlive = true;
			PlayerProgressInfo = Serializer.Load<PlayerProgressInfo>();

			this._enemiesContainer = GameObject.FindWithTag("EnemiesContainer")
				.transform;
		}

		private void Start()
		{
			this.StartCoroutine(this.SpawnWave());
			this.UpdateHighestScore();
			this.UpdateScore();
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape) == false) return;

			MenuHelper.ToggleSettingsMenu(this.SettingsMenu);
		}

		private void OnDestroy() => this.SaveProgress();

		private IEnumerator<WaitForSeconds> SpawnWave()
		{
			yield return new WaitForSeconds(this.StartDelay);

			while (PlayerIsAlive)
			{
				OnWaveSpawn?.Invoke(this._waveCount);

				for (int i = 0; i < this.EnemiesPerWave; i++)
				{
					int randomIndex = Random.Range(0, this.Enemies.Length);

					Vector3 spawnPosition = new Vector3(
						Random.Range(-(ScreenController.Dimensions.x - 1), ScreenController.Dimensions.x - 1),
						0,
						ScreenController.Dimensions.z + 1);

					GameObject obstacle = Instantiate(this.Enemies[randomIndex], this._enemiesContainer);
					obstacle.transform.position = spawnPosition;

					yield return new WaitForSeconds(this.EnemiesSpawnOffset);
				}

				this._waveCount++;

				yield return new WaitForSeconds(this.WavesSpawnOffset);
			}
		}

		private void UpdateScore() => this.ScoreBoard.text = $"{this._score} points";

		private void UpdateHighestScore()
			=> this.HighestScoreBoard.text = $"Highest score: {PlayerProgressInfo.HighestScore} points";

		private void SaveProgress()
		{
			PlayerProgressInfo.HighestScore = Mathf.Max(PlayerProgressInfo.HighestScore, this._score);
			Serializer.Save(PlayerProgressInfo);
			PlayerPrefs.Save();
		}

		public void AddPoints(int scores)
		{
			this._score += scores;
			this.UpdateScore();

			// TODO: Consider if the highest score board should be updated if a new record is submitted.
		}

		public void GameOver()
		{
			PlayerIsAlive = false;

			this.ScoreBoard.gameObject.SetActive(false);

			this.RestartMenu.SetActive(true);
			this.RestartMenu.gameObject.transform.Find("PointsText")
				.GetComponent<Text>()
				.text = $"You scored {this._score} points.";
		}
	}
}