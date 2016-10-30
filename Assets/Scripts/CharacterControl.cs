using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {

    private GameObject head;
    private Rigidbody rb;

    public float walkSpeed, rotateSpeed, maxAngle;

    // Use this for initialization
    void Start () {
        head = transform.GetChild(0).gameObject;
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

        Vector3 direction = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
        rb.velocity = (walkSpeed * direction);

 
        transform.Rotate(new Vector3(0, Time.deltaTime * rotateSpeed * Input.GetAxis("Mouse X"), 0));

        float newRotation = head.transform.localEulerAngles.x - Time.deltaTime * rotateSpeed * Input.GetAxis("Mouse Y");
        
        head.transform.localEulerAngles = new Vector3(newRotation, head.transform.localEulerAngles.y, head.transform.localEulerAngles.z);
    }
}
