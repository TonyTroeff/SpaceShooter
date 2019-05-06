#region

using System.Linq;
using UnityEngine;

#endregion

public class ExplosionsController : MonoBehaviour
{
	private static ExplosionsController _instance;
	
	private Transform _explosionsContainer;

	public GameObject[] Explosions;

	private void Awake()
	{
		if (_instance == null) _instance = this;
		else if (_instance != this) Destroy(this.gameObject);

		DontDestroyOnLoad(_instance);

		this._explosionsContainer = GameObject.FindWithTag("ExplosionsContainer").transform;
	}

	public static GameObject GetExplosion(string tagName)
		=> _instance.Explosions.SingleOrDefault(e => e.name == $"{tagName}Explosion");

	public static void Execute(GameObject explosion, Transform position)
	{
		if (explosion == null) return;

		GameObject instantiatedExplosion = Instantiate(explosion, _instance._explosionsContainer);
		instantiatedExplosion.transform.position = position.position;
	}
}