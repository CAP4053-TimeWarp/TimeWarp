using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class VisionCone : MonoBehaviour {
	public GameObject player;
	public float farVisionCone;
	public float farDistance;
	public float closeVisionCone;
	public float closeDistance;
	private Boolean canSee;
	private Boolean canAttack;
	private Vector3 direction;
	void Update() {
		direction = this.GetComponent<AIMovement> ().getDirection ();
		Vector3 targetDir = player.transform.position - transform.position;
		Vector3 forward = transform.right;
		float distance = Vector3.Distance(player.transform.position, transform.position);
		float angle = Vector3.Angle(targetDir, forward);
		if (angle <= closeVisionCone && distance <= closeDistance) {
			canAttack = true;
			canSee = true;
			Debug.Log ("I can attack you");
		} else if (angle <= farVisionCone && distance <= farDistance) {
			canSee = true;
			canAttack = false;
			Debug.Log ("I can see you");
		} 
		else {
			canSee = false;
			canAttack = false;
		}
		Debug.Log (targetDir);
		//Debug.Log (direction);
		Debug.Log (angle); 
	}
	public Boolean getCanAttack(){
		return canAttack;
	}
	public Boolean getCanSee(){
		return canSee;
	}
}
