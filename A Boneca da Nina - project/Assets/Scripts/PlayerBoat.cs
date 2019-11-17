using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBoat : MonoBehaviour {
	
	public float offset = 0f;
	public float speed = 20;

	private Vector3 destination;
	private float step;
	private float speedX = 10;

	private bool inBossPlace = false;

	GameObject bt;

	void Start() {
		bt = GameObject.Find ("SkipButton");
		bt.SetActive (false);
	}

	public void ClickUp() {
		if (destination.y <= 0)
			destination += new Vector3 (0, offset);
	}

	public void ClickDown() {
		if (destination.y >= 0)
			destination -= new Vector3 (0, offset);		
	}

	void Update() {

		if (inBossPlace) {

			return;
		}

		transform.localPosition += new Vector3(speedX * Time.deltaTime, 0);
		destination.x = transform.localPosition.x;
		transform.localPosition = Vector3.MoveTowards(transform.localPosition, destination, speed * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Log")
			speedX = 2;
	}

	void OnCollisionExit2D(Collision2D other) {
		if (other.gameObject.tag == "Log")
		 	speedX = 10;
	}

	void OnTriggerEnter2D(Collider2D other) {
		inBossPlace = other.gameObject.name == "BossPlace";

		bt.SetActive(true);
			
	}
}
