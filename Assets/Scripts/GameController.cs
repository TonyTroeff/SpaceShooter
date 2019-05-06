#region

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#endregion

public class GameController : MonoBehaviour
{
	private Transform _enemiesContainer;

	private bool _playerIsAlive = true;
	private int _score;

	public GameObject[] Enemies;
	public int EnemiesPerWave;
	public float EnemiesSpawnOffset;
	public GameObject RestartMenu;
	public Text ScoreBoard;
	public Vector3 SpawnDimensions;
	public float StartDelay;
	public int WavesSpawnOffset;

	private void Awake()
	{
		this._enemiesContainer = GameObject.FindWithTag("EnemiesContainer")
			.transform;

		this.ScoreBoard.gameObject.SetActive(true);
		this.RestartMenu.SetActive(false);
	}

	private void Start()
	{
		this.StartCoroutine(this.SpawnWave());
		this.UpdateScore();
	}

	private IEnumerator<WaitForSeconds> SpawnWave()
	{
		yield return new WaitForSeconds(this.StartDelay);

		while (this._playerIsAlive)
		{
			for (int i = 0; i < this.EnemiesPerWave; i++)
			{
				int randomIndex = Random.Range(0, this.Enemies.Length);
				Vector3 spawnPosition = new Vector3(
					Random.Range(this.SpawnDimensions.x * -1, this.SpawnDimensions.x),
					this.SpawnDimensions.y,
					this.SpawnDimensions.z);

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
		this._playerIsAlive = false;

		this.ScoreBoard.gameObject.SetActive(false);

		this.RestartMenu.SetActive(true);
		Text gameOverText = this.RestartMenu.gameObject.transform.Find("PointsText")
			.GetComponent<Text>();
		gameOverText.text = $"You scored {this._score} points.";
	}
}