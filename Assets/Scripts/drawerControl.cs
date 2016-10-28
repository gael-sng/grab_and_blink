using UnityEngine;
using System.Collections;

public class drawerControl : MonoBehaviour {

    Vector3 closedPosition, nextPosition, openedPosition;
    float thold = 0.01f;

	// Use this for initialization
	void Start () {
        closedPosition = transform.localPosition;
        openedPosition = closedPosition + new Vector3(0, 0, 0.15f);
        nextPosition = closedPosition;
    }
	

	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.H)) Open();

        Vector3 velocity = Vector3.zero;
        transform.localPosition = Vector3.SmoothDamp(transform.localPosition, nextPosition, ref velocity, 3f*Time.deltaTime);
	}

    void Open() {
        if (Vector3.Distance(closedPosition, transform.localPosition) < thold) {
            nextPosition = openedPosition;
        } else {
            nextPosition = closedPosition;
        } 
    }
}
