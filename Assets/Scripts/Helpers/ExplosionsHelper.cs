namespace SpaceShooter.Helpers
{
	using UnityEngine;
	using Utilities;

	public static class ExplosionsHelper
	{
		public static GameObject GetExplosion(GameObject gameObject)
			=> gameObject.GetComponent<ExplosionInfo>()
				.Explosion;

		public static void Execute(GameObject explosion, Transform position)
		{
			if (explosion == null) return;

			Transform explosionsContainer = GameObject.FindWithTag("ExplosionsContainer")
				.transform;

			GameObject instantiatedExplosion = Object.Instantiate(explosion, explosionsContainer);
			instantiatedExplosion.transform.position = position.position;
		}
	}
}