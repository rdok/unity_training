using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary { 
	public float xMin, xMax, zMin, zMax;

} // end class Boundary

public class PlayerController : MonoBehaviour {

	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn; 
	public float fireRate;

	private float nextFire;
	/**
	 * executes update code just before updating the frame every frame
	 */
	void Update() {
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			// GameObject clone = 
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation); //  as GameObject;
			audio.Play();
		} // end if
	} // end function update

	/**
	 * Called automatically by unity, just before each fixed physics step.
	 * This is code is executed once per physics step.
	 */
	void FixedUpdate() {
		// grabs the input from the Player
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		// need to apply to this input to player object
		rigidbody.velocity = movement * speed;

		rigidbody.position = new Vector3 
			(
				Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
			 	0.0f,
				Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
			);

		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
	} // end function FixedUpdate
} // end class PlayerController
