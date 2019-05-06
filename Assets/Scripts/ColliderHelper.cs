#region

using UnityEngine;

#endregion

public static class ColliderHelper
{
	public static Transform GetParent(this Collider collider) => collider.transform.parent;

	public static bool CompareParentTag(this Collider collider, string tag) => GetParent(collider)
		.CompareTag(tag);
}