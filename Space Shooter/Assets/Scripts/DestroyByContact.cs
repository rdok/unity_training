using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject player;
	public int scoreValue;
	private GameController gameController;


	void Start() {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController>();
		} // end if

		if (gameController == null) {
			Debug.Log("Cannot find 'GameController' script");
		} // end if
	} // end function Start

	// Destroy everything that enters the trigger
	void OnTriggerEnter (Collider other) {

		if (other.tag == "Boundary") { 
			return;
		} // end if

		// instantiate explosion
		Instantiate(explosion, transform.position, transform.rotation); //  as GameObject;

		if (other.tag == "Player") { 
			Instantiate(player, transform.position, transform.rotation); //  as GameObject;
			gameController.GameOver();
		} // end if

		gameController.AddScore (scoreValue);
		// does not destroy, but mark for future destroy
		Destroy(other.gameObject);
		Destroy (gameObject);
	}
}
