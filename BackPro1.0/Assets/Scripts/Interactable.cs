using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour {

	NavMeshAgent playerAgent;
	private bool hasInteracted;
	public virtual void moveToInteraction(NavMeshAgent playerAgent){
		hasInteracted = false;
		this.playerAgent = playerAgent;
		playerAgent.stoppingDistance = 2.5f;
		playerAgent.destination = this.transform.position;
	}

	void Update(){
		if (!hasInteracted && playerAgent != null && !playerAgent.pathPending) {
			if(playerAgent.remainingDistance <= playerAgent.stoppingDistance){
				interact ();
				hasInteracted = true;
			}
		}
	}
	public virtual void interact(){
		Debug.Log ("Interacting with base class.");
	}
}
