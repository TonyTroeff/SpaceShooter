namespace DestructionControllers
{
	using Helpers;
	using UnityEngine;

	public class OutOfBordersDestructionController : MonoBehaviour
	{
		private void OnTriggerExit(Collider other) => other.DestroyCollider();
	}
}