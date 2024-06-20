using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    public float speed = 1.5f; 
    public float maxAngle = 45.0f; 

    private float storedAngle;
    private float timeOffset; 

    private float angle;
    private Quaternion startRotation;
    private Quaternion endRotation;

    private bool doRotate = true;
    private float pauseTime;

    void Start()
    {
        startRotation = Quaternion.AngleAxis(maxAngle, Vector3.forward);
        endRotation = Quaternion.AngleAxis(-maxAngle, Vector3.forward);
        timeOffset = Time.time; 
    }

    void Update()
    {
        if (doRotate)
        {

            angle = maxAngle * Mathf.Sin((Time.time - timeOffset) * speed);
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            storedAngle = angle;
        }
        else
        {
            transform.rotation = Quaternion.AngleAxis(storedAngle, Vector3.forward);
        }
    }

    public void StartRotation(bool action)
    {
        if (action && !doRotate)
        {
            float currentSinValue = Mathf.Asin(storedAngle / maxAngle);
            timeOffset += (Time.time - pauseTime); 
        }
        else if (!action && doRotate)
        {
            pauseTime = Time.time;
        }

        doRotate = action;
    }
}
