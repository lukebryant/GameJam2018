using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public float friction = 1;

    float moveVelocity;
    int speed;
    public AudioSource audio;

    private Rigidbody2D rb;
    private bool walking = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 0;
    }

    void Update() {
      
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (speed <= 3) speed++;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (speed >= -3) speed--;
        }
        else
        {
            moveVelocity = 0;
            int sign = speed >= 0 ? 1 : -1;
            speed = (int)Mathf.Max(Mathf.Abs((float)speed) - friction, 0) * sign;
    }
        moveVelocity = speed * 0.5f;
if (speed != 0 && !walking)
        {
            walking = true;
            audio.Play();
            Debug.Log("walking");

        }
        else if (speed == 0)
        {
            audio.Stop();
            walking = false;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
    }
}
