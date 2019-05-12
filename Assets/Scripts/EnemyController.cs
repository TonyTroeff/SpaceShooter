using GlobalControllers;
using Helpers;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	private GameController _gameController;

	private void Awake() => this._gameController = FindObjectOfType<GameController>();

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Border")
			|| other.CompareParentTag("Player") == false) return;

		GameObject selfExplosion = ExplosionsController.GetExplosion(this.tag);
		ExplosionsController.Execute(selfExplosion, this.transform);

		Transform player = other.GetParent();
		GameObject playerExplosion = ExplosionsController.GetExplosion(player.tag);
		ExplosionsController.Execute(playerExplosion, other.transform);

		this._gameController.GameOver();

		other.DestroyCollider();
		Destroy(this.gameObject);
	}
}