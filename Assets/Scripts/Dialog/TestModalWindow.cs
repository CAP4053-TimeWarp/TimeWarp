﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class TestModalWindow : MonoBehaviour {

	private ModalPanel modalPanel;
	private DisplayManager displayManager;

	private UnityAction myYesAction;
	private UnityAction myNoAction;
	private UnityAction myCancelAction;

	void Awake() {
		modalPanel = ModalPanel.Instance();
		displayManager = DisplayManager.Instance();

		myYesAction = new UnityAction(TestYesFunction);
		myNoAction = new UnityAction(TestNoFunction);
		myCancelAction = new UnityAction(TestCancelFunction);
	}

	// Send to the ModalPanel to set up the Buttons and Functions to call
	public void TestYNC() {
		modalPanel.Choice("Would you like a poke in the eye?\nHow about with a sharp stick?", myYesAction, myNoAction, myCancelAction);
	}

	// These are wrapped into UnityActions
	void TestYesFunction() {
		displayManager.DisplayMessage("Yuuup");
	}

	void TestNoFunction() {
		displayManager.DisplayMessage("Noooo");
	}

	void TestCancelFunction() {
		displayManager.DisplayMessage("What?");
	}

}
