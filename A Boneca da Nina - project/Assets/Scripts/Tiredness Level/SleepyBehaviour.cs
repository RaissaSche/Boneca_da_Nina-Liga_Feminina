using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Status : byte
{
    SLEEPING = 0,
    WAKINGUP = 1,
    AWAKEN = 2,
    FALLINGASLEEP = 3
};

public class SleepyBehaviour : MonoBehaviour
{
    [SerializeField] private Status status;
    private Transform player;



    private void setStatus(Status sta)
    {
        status = sta;
    }

    private void setStatusAwaken()
    {
        setStatus(Status.AWAKEN);
    }

    // Start is called before the first frame update
    void Start()
    {
        status = Status.SLEEPING;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject.transform;
            status = Status.WAKINGUP;
            Invoke("setStatusAwaken", 1.0f);
        }
    }
}
