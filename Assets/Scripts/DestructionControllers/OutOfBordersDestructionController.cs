#region

using Helpers;
using UnityEngine;

#endregion

namespace DestructionControllers
{
	public class OutOfBordersDestructionController : MonoBehaviour
	{
		private void OnTriggerExit(Collider other) => other.DestroyCollider();
	}
}