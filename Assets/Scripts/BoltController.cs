using Helpers;
using UnityEngine;

public class BoltController : MonoBehaviour
{
	private GameController _gameController;

	public bool IsPlayerBolt;

	private void Awake() => this._gameController = FindObjectOfType<GameController>();

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Border")
			|| other.CompareTag(this.tag)
			|| other.CompareParentTag("Player") == this.IsPlayerBolt) return;

		GameObject target = other.GetParent();
		GameObject explosion = ExplosionsHelper.GetExplosion(target);
		ExplosionsHelper.Execute(explosion, this.transform);

		if (this.IsPlayerBolt)
		{
			int scores = ScoresHelper.GetPoints(target);
			this._gameController.AddPoints(scores);
		}
		else this._gameController.GameOver();

		other.DestroyCollider();
		Destroy(this.gameObject);
	}
}