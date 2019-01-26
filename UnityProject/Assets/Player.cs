using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public float friction = 1;

    float moveVelocity;
    float speed;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {


        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (speed <= 3) speed++;
            moveVelocity = speed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (speed >= -3) speed--;
            moveVelocity = speed;
        }
        else
        {
            int sign = speed >= 0 ? 1 : -1;
            speed = Mathf.Max(Mathf.Abs(speed) - friction, 0) * sign;
            moveVelocity = speed;
         }

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
    }
}
