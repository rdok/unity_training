using UnityEngine;
using System.Collections;

public class SceneFadeIntOut : MonoBehaviour {

	public float fadeSpeed = 1.5f;
	private bool sceneStarting = true;

	void Awake() {
		guiTexture.pixelInset = new Rect (0f, 0f, Screen.width, Screen.height);
	} // end functino Awake

	void Update() {
		if (sceneStarting) {
			StartScene();
		} // end if
	} // end function Update

	void FadeToClear() {
		guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
	} // end function FadeToClear

	void FadeToBlack() {
		guiTexture.color = Color.Lerp(guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);
	} // end function FadeToBlack

	void StartScene() {
		FadeToClear ();

		if (guiTexture.color.a <= 0.05f) {
			guiTexture.color = Color.clear;
			guiTexture.enabled = false;
			sceneStarting = false;
		} // end if
	} // end function StartScene

	public void EndScene() {
		guiTexture.enabled = true;
		FadeToBlack ();

		if (guiTexture.color.a >= 0.95f) {
			Application.LoadLevel(1);
		} // end if
	} // end function EndScene
}
