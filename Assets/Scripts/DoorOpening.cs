using UnityEngine;
using System.Collections;
using System;

public class DoorOpening : MonoBehaviour
{
    static private float closedRotation, thold = 5, nextPosition, velocity = 0;
    static public float openSpeed = 0.3f;
    public float transportDistance = 0.5f;

    public Boolean open = false;

    // Use this for initialization
    void Start()
    {
        closedRotation = transform.localEulerAngles.y;
        nextPosition = closedRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(open)
            transform.localEulerAngles = new Vector3(0, Mathf.SmoothDamp(transform.localEulerAngles.y, nextPosition, ref velocity, openSpeed), 0);
    }
    public void Open()
    {
        if (transform.localEulerAngles.y < closedRotation - thold || transform.localEulerAngles.y > closedRotation + thold)
        {
            nextPosition = closedRotation;
        }
        else
            nextPosition = (closedRotation + 120) % 360;

        open = true;
    }

    public Vector3 GetTeleportPosition(Vector3 actualPos)
    {
        float dist1 = Vector3.Distance(actualPos, transform.position - transform.right * transportDistance);
        float dist2 = Vector3.Distance(actualPos, transform.position + transform.right * transportDistance);

        if (dist1 < dist2)
            return transform.position + transform.right * transportDistance;
        else
            return transform.position - transform.right * transportDistance;

    }
}