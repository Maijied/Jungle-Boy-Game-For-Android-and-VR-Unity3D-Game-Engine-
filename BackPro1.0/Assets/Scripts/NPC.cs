using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable {

	public string[] dialogue;
	public string name;
	public override void interact(){
		DialogueSystem.Instance.AddNewDialogue (dialogue, name);
		Debug.Log ("Interacting with NPC.");
	}
}
