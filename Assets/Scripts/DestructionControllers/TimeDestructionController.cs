#region

using UnityEngine;

#endregion

namespace DestructionControllers
{
	public class TimeDestructionController : MonoBehaviour
	{
		public float Lifetime;

		private void Start() { Destroy(this.gameObject, this.Lifetime); }
	}
}