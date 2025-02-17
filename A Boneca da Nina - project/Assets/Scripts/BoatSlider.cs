﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatSlider : MonoBehaviour
{

    public GameObject player;

    private Slider slider;
    private Vector3 initialPos;
    private Vector3 endPos;
    private float target;

    private GameObject termometro;
    private GameObject[] controls = new GameObject[2];
    // Start is called before the first frame update
    void Start()
    {
        initialPos = player.transform.position;
        endPos = new Vector3(450, 0);

        target = endPos.x - initialPos.x;

        slider = GetComponent<Slider>();

        termometro = GameObject.Find("Termometro");
        termometro.SetActive(false);

        controls[0] = GameObject.Find("UpButton");
        controls[1] = GameObject.Find("DownButton");
    }

    // Update is called once per frame
    void Update()
    {
        float playerPos = player.transform.position.x - initialPos.x;
        slider.value = playerPos / endPos.x;
        if (slider.value >= 1) {
            termometro.SetActive(true);
            gameObject.SetActive(false);
            foreach (GameObject control in controls)
                control.SetActive(false);
        }
    }
}
