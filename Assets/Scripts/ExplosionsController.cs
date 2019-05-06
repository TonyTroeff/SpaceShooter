#region

using System.Linq;
using UnityEngine;

#endregion

public class ExplosionsController : MonoBehaviour
{
	private static ExplosionsController _instance;
	public GameObject[] Explosions;

	public Transform Parent;

	private void Awake()
	{
		if (_instance == null) _instance = this;
		else if (_instance != this) Destroy(this.gameObject);

		DontDestroyOnLoad(_instance);
	}

	public static GameObject GetExplosion(string tagName)
		=> _instance.Explosions.SingleOrDefault(e => e.name == $"{tagName}Explosion");

	public static void Execute(GameObject explosion, Transform position)
	{
		if (explosion == null) return;

		GameObject instantiatedExplosion = Instantiate(explosion, _instance.Parent);
		instantiatedExplosion.transform.position = position.position;
	}
}