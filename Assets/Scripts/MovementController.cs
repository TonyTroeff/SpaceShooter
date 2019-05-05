#region

using UnityEngine;

#endregion

public class MovementController : MonoBehaviour
{
	public float Speed = 1;

	private void Start()
	{
		this.GetComponent<Rigidbody>()
			.velocity = Vector3.forward * this.Speed;
	}
}