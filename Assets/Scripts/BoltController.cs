#region

using UnityEditor.Build.Content;
using UnityEditor.UIElements;
using UnityEngine;

#endregion

public class BoltController : MonoBehaviour
{
	private GameController _gameController;

	public string Source;

	private void Awake() { this._gameController = FindObjectOfType<GameController>(); }

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Border")
			|| other.transform.parent.CompareTag(this.Source)) return;

		GameObject explosion = ExplosionsController.GetExplosion(other.transform.parent.tag);
		ExplosionsController.Execute(explosion, this.transform);

		if (this.Source == "Player")
		{
			int scores = ScoresController.GetPoints(other.transform.parent.gameObject.name);
			this._gameController.AddPoints(scores);
		}

		// TODO: Code repetition.
		Destroy(other.transform.parent.gameObject);
		Destroy(this.gameObject);
	}
}