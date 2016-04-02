using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class TestModalWindow : MonoBehaviour {

	public Sprite icon;
	public Transform spawnPoint;
	public GameObject thingToSpawn;

	private ModalPanel modalPanel;
	private DisplayManager displayManager;

	// private UnityAction myYesAction;
	// private UnityAction myNoAction;
	// private UnityAction myCancelAction;

	void Awake() {
		modalPanel = ModalPanel.Instance();
		displayManager = DisplayManager.Instance();

		// myYesAction = new UnityAction(TestYesFunction);
		// myNoAction = new UnityAction(TestNoFunction);
		// myCancelAction = new UnityAction(TestCancelFunction);
	}

	// Send to the ModalPanel to set up the Buttons and Functions to call

	public void TestOK() {
		modalPanel.Choice("Here is an announcement. Press Cancel to proceed.", TestCancelFunction);
	}

	public void TestYN() {
		modalPanel.Choice("Do you like this dialog box? You can't escape the question!", TestYesFunction, TestNoFunction);
	}

	public void TestYNC() {
		modalPanel.Choice("Would you like a poke in the eye?\nHow about with a sharp stick?", TestYesFunction, TestNoFunction, TestCancelFunction);
	}

	public void TestYNCI() {
		modalPanel.Choice("Do you like this icon?", icon, TestYesFunction, TestNoFunction, TestCancelFunction);
	}

	public void TestLambda() {
		modalPanel.Choice("Do you want to create a sphere?", () => { InstantiateObject(thingToSpawn); }, TestNoFunction);
	}

	public void TestLambda2() {
		modalPanel.Choice("Do you want to create two spheres?", () => { InstantiateObject(thingToSpawn, thingToSpawn); }, TestNoFunction);
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

	void InstantiateObject(GameObject thingToInstantiate) {
		displayManager.DisplayMessage("Here you go!");
		Instantiate(thingToInstantiate, spawnPoint.position, spawnPoint.rotation);
	}

	void InstantiateObject(GameObject thingToInstantiate, GameObject thingToInstantiate2) {
		displayManager.DisplayMessage("Here you go!");
		Instantiate(thingToInstantiate, spawnPoint.position - new Vector3(1, 1, 0), spawnPoint.rotation);
		Instantiate(thingToInstantiate2, spawnPoint.position + new Vector3(1, 1, 0), spawnPoint.rotation);
	}

}
