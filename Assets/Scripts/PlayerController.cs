using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//Variables
	public float speed = 1.0f;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		var vertical = Input.GetAxis("Vertical");
		var horizontal = Input.GetAxis("Horizontal");

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			animator.SetInteger("Direction", 3);
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			animator.SetInteger("Direction", 1);
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			animator.SetInteger("Direction", 2);
			transform.position += Vector3.up * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			animator.SetInteger("Direction", 0);
			transform.position += Vector3.down * speed * Time.deltaTime;
		}
	}
}
