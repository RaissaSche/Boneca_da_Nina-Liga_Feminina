using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour
{

    public GameObject failNeverCollided;
    public GameObject successNeverCollided;
    public GameObject failSmiled;
    public GameObject successSmiled;

    private GameObject player;

    private GameObject termometro;

    private bool neverCollided;
    private bool smiled;

    void Start()
    {
        player = GameObject.Find("PaperBoat");
        termometro = GameObject.Find("Canvas");
    }

    void Update()
    {
        neverCollided = player.GetComponent<PlayerBoat>().neverCollided;
        smiled = termometro.GetComponent<Cocegas>().smiled;

        Debug.Log("neverCollided " + neverCollided);
        Debug.Log("smiled " + smiled);

        successNeverCollided.SetActive(neverCollided);
        failNeverCollided.SetActive(!neverCollided);

        successSmiled.SetActive(smiled);
        failSmiled.SetActive(!smiled);

    }
}
