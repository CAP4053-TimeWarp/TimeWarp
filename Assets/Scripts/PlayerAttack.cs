using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	private float attackSpeed;
	private float damage;
	private float nextAttack;
	private GameObject hitText;
	private Color color;
	public Camera mainCamera;
	void Start () {
		hitText = new GameObject ();
		mainCamera = GetComponentInChildren<Camera> ();
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = mainCamera.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit)){
				if (hit.transform.tag == "Enemy") {
					print ("I'm an enemy");

					float distance = Vector3.Distance(hit.transform.gameObject.transform.position, transform.position);
					print (distance); 
					print (this.GetComponent<Stats> ().AttackRange);
					if (distance <= this.GetComponent<Stats> ().AttackRange) {
						print ("you can attack me");
					}
				}
			}
		}
	}
}
