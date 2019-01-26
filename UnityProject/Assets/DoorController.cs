using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private bool playerInFront = false;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            Debug.Log("player in front");
            playerInFront = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            Debug.Log("player left");
            playerInFront = false;
        }
    }

    public void OnTriggeStay2D(Collider2D collision)
    {
        Debug.Log("stay");
        if (collision.name == "Player")
        {
            Debug.Log("player in front of door");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && playerInFront)
        {
            Debug.Log("player opening door");
        }
    }
}
