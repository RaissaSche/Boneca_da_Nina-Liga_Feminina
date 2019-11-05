using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBoat : MonoBehaviour {
	
	public float offset = 0f;
	private Vector3 initialPosition;

	public void ClickUp() {
		Debug.Log ("ClickUp");
		if (transform.position.y < initialPosition.y + offset) {
			transform.localPosition += new Vector3(0, offset);
		}
	}

	public void ClickDown() {
		Debug.Log ("ClickDown " + (initialPosition.y - offset).ToString());
		if (transform.position.y > initialPosition.y - offset) {
			transform.localPosition -= new Vector3(0, offset);
		}
	}

	void Update () {

	
	}
}
