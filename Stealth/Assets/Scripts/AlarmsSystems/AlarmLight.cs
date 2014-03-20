using UnityEngine;
using System.Collections;

public class AlarmLight : MonoBehaviour
{

	// series of float controlling itensity, and fading
	public float fadeSpeed = 2f;
	public float hightItensity = 2f;
	public float lowIntensity = 0.5f;
	public float changeMargin = 0.2f;
	public bool alarmOn;
	private float targetItensity;

	/**
	 * set behaviors at the start of the scene.
	 */
	void Awake ()
	{
		light.intensity = 0;
		targetItensity = hightItensity;
	} // end method Awake

	/**
	 * Performs most of the script operations
	 */
	void Update ()
	{
		if (alarmOn) {
			light.intensity = Mathf.Lerp (light.intensity, targetItensity, fadeSpeed * Time.deltaTime);
			CheckTargetIntensity ();
		} else {
			light.intensity = Mathf.Lerp(light.intensity, 0f, fadeSpeed * Time.deltaTime);
		}
	} // end function Update

	void CheckTargetIntensity ()
	{
		if (Mathf.Abs (targetItensity - light.intensity) < changeMargin) {
			targetItensity = lowIntensity;
		} else {
			targetItensity = hightItensity;
		} // end else if
	} // end function CheckTargetIntensity
}
