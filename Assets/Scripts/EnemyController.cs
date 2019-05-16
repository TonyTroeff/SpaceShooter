namespace SpaceShooter
{
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

			GameObject selfExplosion = ExplosionsHelper.GetExplosion(this.gameObject);
			ExplosionsHelper.Execute(selfExplosion, this.transform);

			GameObject player = other.GetParent();
			GameObject playerExplosion = ExplosionsHelper.GetExplosion(player);
			ExplosionsHelper.Execute(playerExplosion, other.transform);

			this._gameController.GameOver();

			other.DestroyCollider();
			Destroy(this.gameObject);
		}
	}
}