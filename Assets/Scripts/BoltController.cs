#region

using GlobalControllers;
using Helpers;
using UnityEngine;

#endregion

public class BoltController : MonoBehaviour
{
	private GameController _gameController;

	public bool IsPlayerBolt;

	private void Awake() { this._gameController = FindObjectOfType<GameController>(); }

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Border")
			|| other.CompareTag(this.tag)
			|| other.CompareParentTag("Player") == this.IsPlayerBolt) return;

		Transform target = other.GetParent();
		GameObject explosion = ExplosionsController.GetExplosion(target.tag);
		ExplosionsController.Execute(explosion, this.transform);

		if (this.IsPlayerBolt)
		{
			int scores = ScoresController.GetPoints(target.gameObject.name);
			this._gameController.AddPoints(scores);
		}
		else if (target.CompareTag("Player")) this._gameController.GameOver();

		other.DestroyCollider();
		Destroy(this.gameObject);
	}
}