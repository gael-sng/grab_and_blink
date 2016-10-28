using UnityEngine;
using System.Collections;

public class CheckPointScript : MonoBehaviour {
	public SaveChildScript save;
	public GameObject myself;

	void OnTriggerEnter(Collider other) {
		if (save != null && other.gameObject.tag == "Player") {
			print ("Salvei");
			save = save.SaveNow ();
			GameObject.Destroy(myself);
			GameObject.Find ("Charater").GetComponent<GUIController> ().CheckpointMessage();
		}
	}
}
