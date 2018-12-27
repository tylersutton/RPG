using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

	public GameObject dialogBox;
	public Text dialogText;
	public bool dialogActive;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (dialogActive && Input.GetKeyDown(KeyCode.Space)) {
			dialogBox.SetActive(false);
			dialogActive = false;
		}
	}

	public void ShowBox(string dialog) {
		dialogActive = true;
		dialogBox.SetActive(true);
		dialogText.text = dialog;
	}
}
