#region

using UnityEngine;

#endregion

public class PlayerController : MonoBehaviour
{
	private Rigidbody _rigidbody;

	public GameField GameField;
	public float Speed = 1;
	public float Tilt = 1;

	private void Awake() { this._rigidbody = this.GetComponent<Rigidbody>(); }

	private void FixedUpdate()
	{
		float horizontalMovement = Input.GetAxis("Horizontal");
		float verticalMovement = Input.GetAxis("Vertical");

		this._rigidbody.velocity = new Vector3(horizontalMovement, 0f, verticalMovement) * this.Speed;
		this._rigidbody.position = new Vector3(
			Mathf.Clamp(this._rigidbody.position.x, this.GameField.MinX, this.GameField.MaxX),
			0f,
			Mathf.Clamp(this._rigidbody.position.z, this.GameField.MinZ, this.GameField.MaxZ));
		this._rigidbody.rotation = Quaternion.Euler(0f, 0f, this._rigidbody.velocity.x * this.Tilt * -1);
	}
}