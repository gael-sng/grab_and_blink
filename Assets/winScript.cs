using UnityEngine;
using System.Collections;

public class winScript : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			GameObject.Find ("Charater").GetComponent<GUIController> ().wonMessage();
		}
	}
}
