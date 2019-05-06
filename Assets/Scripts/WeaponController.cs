#region

using UnityEngine;

#endregion

public class WeaponController : MonoBehaviour
{
	private AudioSource _audioSource;
	private float _nextShot;
	private Rigidbody _shipRigidbody;
	public GameObject Bolt;
	public float FireRate;

	public Transform Shots;

	private void Awake()
	{
		this._audioSource = this.GetComponent<AudioSource>();
		this._shipRigidbody = this.transform.parent.GetComponent<Rigidbody>();
	}

	private void Update()
	{
		if (Input.GetButton("Fire1") == false
			|| Time.time < this._nextShot) return;

		this._nextShot = Time.time + this.FireRate;

		GameObject bolt = Instantiate(this.Bolt, this.Shots);
		bolt.transform.position = this._shipRigidbody.position + Vector3.forward;

		this._audioSource.Play();
	}
}