using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public float speed;
    float moveVelocity;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {


        if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) 
        {
            if(speed <=3) speed++;
            moveVelocity = speed;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if(speed >=-3) speed--;
            moveVelocity = speed;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
    }
}
