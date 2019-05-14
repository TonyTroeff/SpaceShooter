namespace Helpers
{
	using UnityEngine;

	public static class ColliderHelper
	{
		public static GameObject GetParent(this Collider collider) => collider.transform.parent.gameObject;

		public static bool CompareParentTag(this Collider collider, string tag)
			=> GetParent(collider)
				.CompareTag(tag);

		public static void DestroyCollider(this Collider collider)
		{
			if (collider.CompareTag("Bolt")) Object.Destroy(collider.gameObject);
			else
				Object.Destroy(
					GetParent(collider)
						.gameObject);
		}
	}
}