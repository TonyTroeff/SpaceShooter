#region

using UnityEngine;

#endregion

public class WeaponController : MonoBehaviour
{
	private AudioSource _audioSource;

	private float _nextShot;
	private Rigidbody _shipRigidbody;
	private Transform _shotsContainer;

	public GameObject Bolt;
	public float FireRate;
	public bool ShouldWaitForInput;

	private void Awake()
	{
		this._audioSource = this.GetComponent<AudioSource>();
		this._shipRigidbody = this.transform.parent.GetComponent<Rigidbody>();
		this._shotsContainer = GameObject.FindWithTag("ShotsContainer")
			.transform;
	}

	private void Update()
	{
		if (Input.GetButton("Fire1") != this.ShouldWaitForInput
			|| Time.time < this._nextShot) return;

		this._nextShot = Time.time + this.FireRate;

		GameObject bolt = Instantiate(this.Bolt, this._shotsContainer);
		bolt.transform.position = this._shipRigidbody.position + Vector3.forward;
		bolt.transform.rotation = this._shipRigidbody.rotation;

		this._audioSource.Play();
	}
}