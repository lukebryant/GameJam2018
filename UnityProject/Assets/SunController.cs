using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunController : MonoBehaviour
{

    public float yOffset = 0;
    public float arcRadius = 15;
    public float startingAngle = -0.48f; //radians
    public float angle = -0.48f; //radians
    public float updateAngle = 0.001f; //radians

    // Start is called before the first frame update
    void Start()
    {
        this.transform.localPosition = new Vector3(1,1,0);
    }

    // Update is called once per frame
    void Update()
    {
        angle += updateAngle;
        float x = arcRadius * Mathf.Sin(angle);
        float y = arcRadius * Mathf.Cos(angle);
        this.transform.localPosition = new Vector3(x, y + yOffset, 0);
        if(angle > 0.8) { angle = startingAngle; }
    }
}
