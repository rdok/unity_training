using UnityEngine;
using System.Collections;

public class LaserBlinking : MonoBehaviour {

	public float onTime;
	public float offTime;

	private float timer;

	void Update() {
		timer += Time.deltaTime;

		if (renderer.enabled && timer >= onTime) {
			SwitchBeam();
		} // end if

		if (!renderer.enabled && timer >= offTime) {
			SwitchBeam();
		} // end if
	} // end function Update

	void SwitchBeam() {
		timer = 0f;

		renderer.enabled = !renderer.enabled;
		light.enabled = !light.enabled;
	} // end functin SwitchBean
}
