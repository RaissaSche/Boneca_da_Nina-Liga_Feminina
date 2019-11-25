using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Cocegas : MonoBehaviour, IPointerClickHandler {
	enum Status {
		WaitingToStart,
		Playing,
		Won,
		Lost
	};

	public Slider termometro;

	private float count = 0;
	private int lastClickCount = 0;
	private int previousClickCount = 0;

	private Status status;

	private float timer = 0;
	private float timeInGame = 0;
	
	private ParticleSystem particle;

	private GameObject sadMonster;
	private GameObject happyMonster;

	private GameObject achievements;

	void Start () {
		particle = GameObject.Find("SadnessParticle").GetComponent<ParticleSystem>();	

		sadMonster = GameObject.Find("SadMonster");
		happyMonster = GameObject.Find("HappyMonster");
		happyMonster.SetActive(false);
		status = Status.WaitingToStart;

		achievements = GameObject.Find("Achievements");
		achievements.SetActive(false);
	}

	void Update () {

		if (status != Status.Playing) {
			particle.Stop();

			if (status == Status.Lost || status == Status.Won) {
				achievements.SetActive(true);
			}

			return;
		}

		timeInGame += Time.deltaTime;

		if (status == Status.Playing && timeInGame > 2) {
			if (termometro.value <= 0f)
				status = Status.Lost;
			else if (termometro.value >= 1f) {
				status = Status.Won;
				happyMonster.SetActive(true);
				sadMonster.SetActive(false);
			}
		}

		if (previousClickCount == lastClickCount) {
			timer += Time.deltaTime;
		} else {
			timer = 0;
		}

		if (timer == 0) count += .005f;

		if (timer > .3f) {

			if (count > 0) {
				count = -.5f;
			} else {
				count -= .1f * Time.deltaTime;
			}
		}

		termometro.value += count * Time.deltaTime;
		previousClickCount = lastClickCount;
	}

	public void OnPointerClick(PointerEventData eventData)
	{ 
		if (status == Status.WaitingToStart && eventData.clickCount > 2) {
			status = Status.Playing;
			particle.Play();
		}

		if (termometro.value < .2f)
			count = .1f;
		else if (termometro.value < .3f)
			count = .09f;
		else if (termometro.value < .5)
			count = .07f;
		else if (termometro.value < .6)
			count = .05f;
		else if (termometro.value < .8)
			count = .03f;
		else
			count = .018f;

		lastClickCount = eventData.clickCount;
    }
}
