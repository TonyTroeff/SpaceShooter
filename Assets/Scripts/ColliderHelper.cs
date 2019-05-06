#region

using UnityEngine;

#endregion

public static class ColliderHelper
{
	public static Transform GetParent(this Collider collider) => collider.transform.parent;

	public static bool CompareParentTag(this Collider collider, string tag) => GetParent(collider)
		.CompareTag(tag);

	public static void DestroyCollider(this Collider collider)
	{
		if (collider.CompareTag("Bolt")) MonoBehaviour.Destroy(collider.gameObject);
		else
			MonoBehaviour.Destroy(
				GetParent(collider)
					.gameObject);
	}
}