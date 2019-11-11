using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cocegas : MonoBehaviour {

	ParticleSystem particle;

	// Use this for initialization
	void Start () {
		particle = gameObject.GetComponent<ParticleSystem>();		
	}
	
	// Update is called once per frame
	void Update () {
		particle.Stop ();
	}
}
