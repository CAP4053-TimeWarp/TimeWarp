using UnityEngine;
using System.Collections;
using System.Xml.Linq;
using UnityEditor;

public class AIMovement : MonoBehaviour {

	public GameObject player;
	public float speed;
	private VisionCone vision;
	private Attack attack;
	private Vector3 pos;
	private bool atTarget;
	private Vector3 target;
	private float nextPath;
	private bool xAxis;
	private bool yAxis;
	void Start () {
		vision = this.GetComponent<VisionCone> ();
		attack = this.GetComponent<Attack> ();
		atTarget = true;
		target = new Vector3 (0, 0, 0);
		nextPath = Time.time;
	}

	void Update () {
		float rand = Random.value;
		if (!this.gameObject.GetComponent<Rigidbody2D> ().IsAwake ()) {
			pos = this.transform.position;
		}
		if(vision.getCanSee ()){
			target = player.transform.position;
			nextPath = Time.time + 2;
		}
		else if(rand <= .25 && !this.gameObject.GetComponent<Rigidbody2D> ().IsAwake () && Time.time > nextPath) {
			target = pos + new Vector3 (0, 5, 0);
			atTarget = false;
			nextPath = Time.time + 2;
		}
		else if(rand <= .50 && !this.gameObject.GetComponent<Rigidbody2D> ().IsAwake () && Time.time > nextPath) {
			target = pos + new Vector3 (5, 0, 0);
			atTarget = false;
			nextPath = Time.time + 2;
		}
		else if(rand <= .75 && !this.gameObject.GetComponent<Rigidbody2D> ().IsAwake () && Time.time > nextPath) {
			target = pos + new Vector3 (0, -5, 0);
			atTarget = false;
			nextPath = Time.time + 2;
		}
		else if(rand <= 1.0 && !this.gameObject.GetComponent<Rigidbody2D> ().IsAwake () && Time.time > nextPath) {
			target = pos + new Vector3 (-5, 0, 0);
			atTarget = false;
			nextPath = Time.time + 2;
		}
		transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
	}
	public bool xAxisMovement(){
		return xAxis;
	}
	public bool yAxisMovement(){
		return yAxis;
	}
}
