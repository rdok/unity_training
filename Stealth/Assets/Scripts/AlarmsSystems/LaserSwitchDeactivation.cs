using UnityEngine;
using System.Collections;

public class LaserSwitchDeactivation : MonoBehaviour {
	// reference to the object laser
	public GameObject laser;
	public Material unlockedMat;

	private GameObject player;

	void Awake() {
		player = GameObject.FindGameObjectWithTag (Tags.player);
	} // end function Awake

	void OnTriggerStay(Collider other) {

		if (other.gameObject == player) {
			if(Input.GetButton("Switch")) {

			} // end if
		} // end if
	} // end function OnTriggerStay

	void LaserDeactivation() {
		laser.SetActive (false);

		Renderer screen = transform.Find ("prop_switchUnit_screen_001").renderer;
		screen.material = unlockedMat;
		audio.Play ();
	} // end function LaserDeactivation
}


