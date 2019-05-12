using UnityEngine;

public class WeaponController : MonoBehaviour
{
	private AudioSource _audioSource;
	private float _nextShot;
	private Transform _shotsContainer;

	public GameObject Bolt;
	public float FireRate;
	public bool ShouldWaitForInput;

	private void Awake()
	{
		this._audioSource = this.GetComponent<AudioSource>();

		this._shotsContainer = GameObject.FindWithTag("ShotsContainer")
			.transform;
	}

	private void Update()
	{
		if (GameController.PlayerIsAlive == false
			|| Time.time < this._nextShot
			|| this.ShouldWaitForInput && Input.GetButton("Fire1") == false) return;

		this._nextShot = Time.time + this.FireRate;

		GameObject bolt = Instantiate(this.Bolt, this._shotsContainer);

		Transform weaponTransform = this.transform;
		bolt.transform.position = weaponTransform.position;
		bolt.transform.rotation = weaponTransform.rotation;

		this._audioSource.Play();
	}
}