using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Cocegas : MonoBehaviour, IPointerClickHandler {

	// ParticleSystem particle;
	public Slider termometro;

	private float count = 0;
	private int lastClickCount = 0;

	float timer = 0;
	float lalala = 0;

	void Start () {
		// particle = gameObject.GetComponent<ParticleSystem>();		
	}

	void Update () {
		
		// particle.Stop ();

		if (lalala == lastClickCount) {
			timer += Time.deltaTime;
		} else {
			timer = 0;
		}

		if (timer > .5f) {
			count = -.3f;
		}

		termometro.value += count * Time.deltaTime;
		lalala = lastClickCount;

		
	}

	public void OnPointerClick(PointerEventData eventData)
    {
		if (eventData.clickCount == 1)
			count = -.01f;
		else if (eventData.clickCount < 5)
			count = .0f;
		else if (eventData.clickCount < 10)
			count = .02f;
		else if (eventData.clickCount < 20)
			count = .05f;
		else
			count = .08f;

		lastClickCount = eventData.clickCount;
    }
}
