using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    Rigidbody2D body;
    public AudioSource impact;
    bool falling = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Player" && falling)
        {
            impact.Play();
            falling = false;
        }
        falling = false;
    }

    public void Drop()
    {
        body.gravityScale = 1f;
        falling = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
    }
}
