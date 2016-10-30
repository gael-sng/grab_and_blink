using UnityEngine;
using System.Collections;

public class DoorOpening : MonoBehaviour {
    private float closedRotation, thold = 5, nextPosition, velocity = 0;
    public float openSpeed = 0.3f;
    // Use this for initialization
    void Start () {
        closedRotation = transform.localEulerAngles.y;
        nextPosition = closedRotation;
    }
	
	// Update is called once per frame
	void Update () {
        transform.localEulerAngles = new Vector3(0, Mathf.SmoothDamp(transform.localEulerAngles.y, nextPosition, ref velocity, openSpeed), 0);
	}

    public void Open() {
        if (transform.localEulerAngles.y < closedRotation - thold || transform.localEulerAngles.y > closedRotation + thold)
            nextPosition = closedRotation;
        else
            nextPosition = (closedRotation + 120)%360;
    }
}
