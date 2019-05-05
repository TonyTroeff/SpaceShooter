#region

using UnityEngine;

#endregion

public class TimeDestructionController : MonoBehaviour
{
	public float Lifetime;

	private void Start() { Destroy(this.gameObject, this.Lifetime); }
}