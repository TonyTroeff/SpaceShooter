#region

using UnityEngine;

#endregion

public class PlayerController : MonoBehaviour
{
	private AudioSource _audioSource;
	private float _nextShot;
	private Transform _object;
	private Rigidbody _rigidbody;

	private Transform _shots;

	public GameObject Bolt;
	public float FireRate;

	public GameField GameField;
	public float Speed = 1;
	public float Tilt = 1;

	private void Awake()
	{
		this._object = this.transform.Find("Object");
		this._shots = this.transform.Find("Shots");

		this._rigidbody = this._object.GetComponent<Rigidbody>();
		this._audioSource = this._shots.GetComponent<AudioSource>();
	}

	private void Update()
	{
		if (Input.GetButton("Fire1") == false
			|| Time.time < this._nextShot) return;

		this._nextShot = Time.time + this.FireRate;

		GameObject shot = Instantiate(this.Bolt, this._shots);
		shot.transform.localPosition = this._rigidbody.position;
		this._audioSource.Play();
	}

	private void FixedUpdate()
	{
		if (this._object.Equals(null)
			|| this._rigidbody.Equals(null)) return;

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