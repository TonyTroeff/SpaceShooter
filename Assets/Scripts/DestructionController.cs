#region

using UnityEngine;

#endregion

public class DestructionController : MonoBehaviour
{
	private GameController _gameController;
	public GameObject Explosion;
	public GameObject PlayerExplosion;
	public int Points;

	private void Awake() { this._gameController = FindObjectOfType<GameController>(); }

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Border")) return;

		Transform triggerTransform = this.transform;
		Instantiate(this.Explosion, triggerTransform.position, triggerTransform.rotation);

		if (other.CompareTag("Player"))
		{
			Transform playerTransform = other.transform;
			Instantiate(this.PlayerExplosion, playerTransform.position, playerTransform.rotation);
			this._gameController.GameOver();
		}
		else this._gameController.AddScores(this.Points);

		Destroy(other.gameObject);
		Destroy(this.gameObject);
	}
}