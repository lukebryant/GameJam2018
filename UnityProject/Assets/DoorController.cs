using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private bool playerInFront = false;
    private bool inHouse = false;
    private SpriteRenderer cabinFrontSpriteRenderer;
    private BoxCollider2D cabinLeftSideCollider;
    private BoxCollider2D cabinRightSideCollider;
    public Player player;

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

    // Start is called before the first frame update
    void Start()
    {
        cabinFrontSpriteRenderer = GameObject.Find("/Cabin/Front").GetComponent<SpriteRenderer>();
        cabinLeftSideCollider = GameObject.Find("/Cabin/LeftSide").GetComponent<BoxCollider2D>();
        cabinRightSideCollider = GameObject.Find("/Cabin/RightSide").GetComponent<BoxCollider2D>();
        cabinLeftSideCollider.enabled = false;
        cabinRightSideCollider.enabled = false;
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && playerInFront)
        {
            enterDoor();
        }
        if (Input.GetKeyDown("l") && playerInFront && inHouse)
        {
            exitDoor();
        }
    }

    void enterDoor()
    {
        inHouse = true;
        cabinFrontSpriteRenderer.sortingLayerName = "sea";
        cabinLeftSideCollider.enabled = true;
        cabinRightSideCollider.enabled = true;
        Color newColor = cabinFrontSpriteRenderer.color;
        newColor.a = 0.5f;
        cabinFrontSpriteRenderer.color = newColor;
        player.EnterCabin();
        Debug.Log("entering cabin");
    }

    void exitDoor()
    {
        inHouse = false;
        cabinFrontSpriteRenderer.sortingLayerName = "cabin front";
        cabinLeftSideCollider.enabled = false;
        cabinRightSideCollider.enabled = false;
        Color newColor = cabinFrontSpriteRenderer.color;
        newColor.a = 1f;
        cabinFrontSpriteRenderer.color = newColor;
        player.ExitCabin();
        Debug.Log("Exiting cabin");
    }
}