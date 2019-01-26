using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    Rigidbody2D body;
    private bool inOcean = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Ocean")
        {
            Debug.Log("fruit in ocean");
            inOcean = true;
        }
    }
    public void Drop()
    {
        body.gravityScale = 1f;
    }

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (inOcean)
        {
            float r = Random.Range(0, 1);
            if (r < 0.5) {
                body.AddForce(new Vector2(-5, 0));
            }else
        }
        */
    }
}
