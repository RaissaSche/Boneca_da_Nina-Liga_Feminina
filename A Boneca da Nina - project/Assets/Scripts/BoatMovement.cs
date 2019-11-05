using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour {
	
	private float RotateSpeed = 6f;           
	private float _angle;
	private int Direction = 1;

	void Start () {
		transform.eulerAngles = new Vector3 (0,0,0);
	}
	
	void Update () {

		if (Direction > 0) {
			if (transform.eulerAngles.z > 350 && transform.eulerAngles.z <= 357 && RotateSpeed > 1f)
				RotateSpeed -= .2f;
			else if (Direction > 0 && transform.eulerAngles.z >= 340 && transform.eulerAngles.z <= 350) {
				Direction = -1;
				RotateSpeed = 0;
			}
		} 
		else 
		{
			if (transform.eulerAngles.z > 3 && transform.eulerAngles.z < 10 && RotateSpeed > 1f)
				RotateSpeed -= .2f;
			else if (transform.eulerAngles.z <= 20 && transform.eulerAngles.z >= 10) {
				Direction = 1;
				RotateSpeed = 0;
			}
		}
		
		transform.Rotate (Vector3.forward *- (5 * Direction * RotateSpeed * Time.deltaTime));
		RotateSpeed += .07f;

		transform.position += new Vector3 (10 * Time.deltaTime, 0, 0);
	}
}
