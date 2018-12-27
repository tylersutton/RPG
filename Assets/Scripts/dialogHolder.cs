using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogHolder : MonoBehaviour {

	public string dialog;
	private DialogManager DMan;

	// Use this for initialization
	void Start () {
		DMan = FindObjectOfType<DialogManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.name == "Player" && Input.GetKeyUp(KeyCode.Space)) {
			DMan.ShowBox(dialog);
		}
	}
}
