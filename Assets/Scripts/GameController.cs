using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject MoleContainer;
	public Player player;
	public float spawnDuration = 1.5f;
	public float minimumSpawnDuration = 0.5f;
	public float spawnTimeDecrement = 0.1f;
	public TextMesh infoText;


	private Mole[] moles;
	private float spawnTimer;
	private float gameTimer = 15f;
	private float resetTimer = 5f;

	// Use this for initialization
	void Start () {
		moles = MoleContainer.GetComponentsInChildren<Mole> ();
		spawnTimer = spawnDuration;
	}
	
	// Update is called once per frame
	void Update () {
		
		gameTimer -= Time.deltaTime;

		if (gameTimer > 0) {
			
			infoText.text = "Whack all the moles \nTime left: " + Mathf.Floor (gameTimer) + "\nScore: " + player.score;
			spawnTimer -= Time.deltaTime;


			if(spawnTimer < 0){

				moles [Random.Range (0, moles.Length)].Rise ();

				spawnDuration -= spawnTimeDecrement;

				if (spawnDuration <= minimumSpawnDuration) {
					spawnDuration = minimumSpawnDuration;		
				}

				spawnTimer = spawnDuration;
			}
		} 
		else {
			infoText.text = "Gameover!! Your score is: " +  player.score;
			resetTimer -= Time.deltaTime;
			if(resetTimer < 0){
				SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
			}
		}
					
	}
}

