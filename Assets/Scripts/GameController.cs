using System.Collections.Generic;
using Helpers;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	private Transform _enemiesContainer;
	private int _score;

	public GameObject[] Enemies;
	public int EnemiesPerWave;
	public float EnemiesSpawnOffset;
	public GameObject RestartMenu;
	public Text ScoreBoard;
	public GameObject SettingsMenu;
	public float StartDelay;
	public int WavesSpawnOffset;

	static public bool PlayerIsAlive { get; private set; } = true;

	private void Awake()
		=> this._enemiesContainer = GameObject.FindWithTag("EnemiesContainer")
			.transform;

	private void Start()
	{
		this.StartCoroutine(this.SpawnWave());
		this.UpdateScore();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) == false) return;

		MenuHelper.ToggleSettingsMenu(this.SettingsMenu);
	}

	private void OnApplicationQuit() => PlayerPrefs.Save();

	private IEnumerator<WaitForSeconds> SpawnWave()
	{
		yield return new WaitForSeconds(this.StartDelay);

		while (PlayerIsAlive)
		{
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

			yield return new WaitForSeconds(this.WavesSpawnOffset);
		}
	}

	private void UpdateScore() => this.ScoreBoard.text = $"Score: {this._score}";

	public void AddPoints(int scores)
	{
		this._score += scores;
		this.UpdateScore();
	}

	public void GameOver()
	{
		PlayerIsAlive = false;
		this.ScoreBoard.gameObject.SetActive(false);

		this.RestartMenu.SetActive(true);

		Text gameOverText = this.RestartMenu.gameObject.transform.Find("PointsText")
			.GetComponent<Text>();

		gameOverText.text = $"You scored {this._score} points.";
	}
}