using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	private float waveWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	private bool gameOver;
	private bool restart;

	private int score;

	void Start() {
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		waveWait = Random.Range (0.5f, 5);//////////
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	} // end function Start


	void Update() {
		if (restart) {
			if(Input.GetKeyDown(KeyCode.R) ){
				Application.LoadLevel(Application.loadedLevel);
			} // end if
		} // end if
	} // end function Update
	IEnumerator SpawnWaves() {

		yield return new WaitForSeconds(startWait);

		while(true) {
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x),spawnValues.y,spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(spawnWait);
			} // end fors

			waveWait = Random.Range (1, 6);
			hazardCount += (int)Random.Range (1, 3);
			yield return new WaitForSeconds(waveWait);

			if(gameOver) {
				restartText.text = "Press 'R' to try with a new space ship.\nEarth's children are depending on you.";
				restart = true;
				break;
			} // end if
		} // end while
	} // end function spawnWaves

	void UpdateScore() {
		scoreText.text = "Score: " + score;
	} // end function updateScore

	public void AddScore(int newScoreValue) {
		score += newScoreValue;
		UpdateScore ();
	} // end method AddScore

	public void GameOver() {
		gameOverText.text = "You failed to destroy enough asteroids.\nEarth is doomed.";
		gameOver = true;

	} // end function GameOver
} // end class GameController
