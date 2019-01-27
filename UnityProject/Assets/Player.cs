using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public float friction = 1;
    public bool sleeping = false;

    float moveVelocity;
    int speed;
    public AudioSource footSteps;

    private Rigidbody2D rb;
    private Transform parentTransform;
    private Vector3 preSleepPosition;
    Animator animator;
    private bool walking = false;
    private bool inOcean = false;
    private bool inCabin = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        parentTransform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        speed = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Ocean")
        {
            inOcean = true;
            Debug.Log("in ocean");
        }

    }

    public void EnterCabin()
    {
        inCabin = true;
    }
    public void ExitCabin()
    {
        inCabin = false;
    }
    public bool IsInCabin()
    {
        return inCabin;
    }
    public void sleep()
    {
        Debug.Log("sleeping");
        preSleepPosition = parentTransform.position;
        parentTransform.position = new Vector3(-1.1f, -0.85f, 0);
        Vector3 oldVec3 = parentTransform.localScale;
        parentTransform.localScale = new Vector3(-Mathf.Abs(oldVec3.x), oldVec3.y, oldVec3.z);
        parentTransform.localEulerAngles = new Vector3(0, 0, 90);
        sleeping = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name == "Ocean")
        {
            inOcean = false;
            Debug.Log("on land");
        }
    }

    void Update() {

        if (sleeping)
        {
            if (Input.GetKey(KeyCode.L)) {
                parentTransform.localPosition = preSleepPosition;
                sleeping = false;
            }
            return;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            animator.SetTrigger("Walk");
            Vector3 oldVec3 = parentTransform.localScale;
            parentTransform.localScale = new Vector3(-Mathf.Abs(oldVec3.x), oldVec3.y, oldVec3.z);
            if (speed <= 3) speed++;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            animator.SetTrigger("Walk");
            Vector3 oldVec3 = parentTransform.localScale;
            parentTransform.localScale = new Vector3(Mathf.Abs(oldVec3.x), oldVec3.y, oldVec3.z);
            if (speed >= -3) speed--;
        }
        else
        {
            animator.SetTrigger("Idle");
            moveVelocity = 0;
            int sign = speed >= 0 ? 1 : -1;
            speed = (int)Mathf.Max(Mathf.Abs((float)speed) - friction, 0) * sign;
        }
        moveVelocity = speed * 0.25f;
        if (speed != 0 && !walking)
        {
            if (!inOcean)
            {
                walking = true;
                footSteps.Play();
                Debug.Log("walking");
            }

        }
        else if (speed == 0 || inOcean)
        {
            footSteps.Stop();
            walking = false;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
    }
}
