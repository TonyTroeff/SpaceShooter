namespace Helpers
{
	using UnityEngine;

	static public class ColliderHelper
	{
		static public Transform GetParent(this Collider collider) => collider.transform.parent;

		static public bool CompareParentTag(this Collider collider, string tag)
			=> GetParent(collider)
				.CompareTag(tag);

		static public void DestroyCollider(this Collider collider)
		{
			if (collider.CompareTag("Bolt")) Object.Destroy(collider.gameObject);
			else
				Object.Destroy(
					GetParent(collider)
						.gameObject);
		}
	}
}