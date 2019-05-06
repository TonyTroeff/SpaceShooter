#region

using UnityEngine;

#endregion

public class BorderGarbageCollector : MonoBehaviour
{
	private void OnTriggerExit(Collider other) { other.DestroyCollider(); }
}