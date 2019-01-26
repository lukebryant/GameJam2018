using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    Rigidbody2D body;
    private bool inOcean = false;
    private long frame = 0;
    private long lastWaveFrame = 0;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Ocean")
        {
            Debug.Log("fruit in ocean");
            inOcean = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.name == "Ocean")
        {
            Debug.Log("fruit out of ocean");
            inOcean = false;
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
        frame++;

        if (inOcean && frame > lastWaveFrame + 90)
        {
            lastWaveFrame = frame;
            float r = Random.Range(0, 1);
            if (r < 0.40) {
                body.AddForce(new Vector2(-5, 0));
            }
            else
            {
                body.AddForce(new Vector2(5, 0));
            }
        }
    }
}
