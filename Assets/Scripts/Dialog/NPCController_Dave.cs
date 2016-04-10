using UnityEngine;
using System.Collections;

public class NPCController_Dave : MonoBehaviour {

	public DialogController dialogController;
	public float minimumDistance;

	private string[] dialogLines;
	private GameObject player;
	private bool questInProgress;
	private bool questComplete;

	// Use this for initialization
	void Start() {
		player = GameObject.FindWithTag("Player");
		questInProgress = false;
		questComplete = false;
	}

	void OnMouseDown() {
		if (((Vector2)player.transform.position - (Vector2)this.transform.position).sqrMagnitude < minimumDistance) {
			if (!questComplete && !questInProgress) {
				dialogController.TestYN("Would you like to start this quest?");
			} else if (!questComplete && questInProgress) {
				dialogController.TestOK("Your quest is in progress!");
			} else if (questComplete) {
				dialogController.TestOK("Thanks for completing my quest!");
			}
		}
	}

}
