using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour {

	public float visibleHeight = 0.2f;
	public float hiddenHeight = -0.2f;
	
	public float speed = 3f;

	private Vector3 targetPosition;

	public float dissapearDuration = 1.25f;
	private float dissapearTimer = 0f;
	public bool Whackable = false;


	// Use this for initialization
	void Awake () {
		targetPosition = new Vector3 (
			transform.localPosition.x,
			hiddenHeight,
			transform.localPosition.z
		);

		transform.localPosition = targetPosition;
	}
	
	// Update is called once per frame
	void Update () {
		dissapearTimer -= Time.deltaTime;
		if(dissapearTimer <=0){
			Hide ();
		}
		transform.localPosition = Vector3.Lerp (transform.localPosition, targetPosition, Time.deltaTime*speed);
	}

	public void Rise() {
		Whackable = true;
		targetPosition = new Vector3 (
			transform.localPosition.x,
			visibleHeight,
			transform.localPosition.z
		);
		

		dissapearTimer = dissapearDuration;
	}

	public void Hide() {
		Whackable = false;
		targetPosition = new Vector3 (
			transform.localPosition.x,
			hiddenHeight,
			transform.localPosition.z
		);
	}

	public void OnHit() {
		Hide ();
		print("mole hit");
	}
}
