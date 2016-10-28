using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour
{
   
    private GameObject head;
    private Rigidbody rb;

    public float walkSpeed, rotateSpeed;
    public Texture2D centerTexture;

    // Use this for initialization
    void Start(){
        rotateSpeed = 0.5f;
        head = transform.GetChild(0).gameObject;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 direction = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
        rb.velocity = (walkSpeed * direction);

        transform.Rotate(new Vector3(0, Time.deltaTime * 200 * rotateSpeed * Input.GetAxis("Mouse X"), 0));
        head.transform.Rotate(-Time.deltaTime * 200 * rotateSpeed * Input.GetAxis("Mouse Y"), 0, 0);
	}


    void OnGUI() {
        GUI.DrawTexture(new Rect(Screen.width / 2 - 7, Screen.height / 2 - 7, 14, 14), centerTexture);
    }
}


