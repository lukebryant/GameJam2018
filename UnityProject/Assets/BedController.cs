using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedController : MonoBehaviour
{
    private bool playerInFront = false;
    public bool inHouse = false;
    private Player player;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            Debug.Log("player in front of bed");
            playerInFront = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            playerInFront = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && playerInFront)
        {
            player.sleep();
        }
    }
}