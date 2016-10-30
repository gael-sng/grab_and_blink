using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveChildScript: MonoBehaviour {

	private GameObject saved;
	public GameObject current;


	public CheckPointScript[] CPList = new CheckPointScript[10];

	void Start(){
		
		saved = Object.Instantiate (current);
		saved.GetComponent<SaveChildScript> ().current = saved;
		saved.GetComponent<SaveChildScript> ().enabled = false;
		saved.SetActive (false);
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.R)) {
			print ("destruido");
			saved.GetComponent<SaveChildScript>().enabled = true;
			saved.SetActive (true);
			UpdateCheckpoints (saved.GetComponent<SaveChildScript>());
			GameObject.Destroy (current);
		}
	}
	public SaveChildScript SaveNow(){
		GameObject.Destroy (saved);
		saved = Object.Instantiate (current);
		saved.GetComponent<SaveChildScript> ().current = saved;
		saved.GetComponent<SaveChildScript> ().enabled = false;
		saved.SetActive (false);
		return current.GetComponents<SaveChildScript>()[0];
	}

	private void UpdateCheckpoints(SaveChildScript currentSave){
		int i;
		for (i = 0; i < CPList.Length; i++) {
			if (CPList [i] != null) {
				CPList [i].save = currentSave;
				print ("Atualizei o checkpoint " + i);
			}
		}
	}
}
