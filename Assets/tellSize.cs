using UnityEngine;
using System.Collections;

public class tellSize : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log(GetComponent<Collider>().bounds.size);
    }
	
	// Update is called once per frame
	void Update () {
       
	}
}
