﻿using UnityEngine;
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
	void Update() {
		Vector2 targetDir = player.transform.position - transform.position;
		Vector2 forward = transform.right;;
		float distance = Vector3.Distance(player.transform.position, transform.position);
		float angle = Vector3.Angle(targetDir, forward);
		if (angle <= closeVisionCone && distance <= closeDistance) {
			canAttack = true;
			canSee = true;
		} else if (angle <= farVisionCone && distance <= farDistance) {
			canSee = true;
			canAttack = false;
		} 
		else {
			canSee = false;
			canAttack = false;
		}
	}
	public Boolean getCanAttack(){
		return canAttack;
	}
	public Boolean getCanSee(){
		return canSee;
	}
}
