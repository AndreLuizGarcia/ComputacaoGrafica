using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnimySript : MonoBehaviour {

	public int velocity;
	public Rigidbody2D body2;
	public int jumpValue;
	public int count = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.right*velocity*Time.deltaTime);


		count = count + 1;

		if (count == 60) {
			body2.AddForce (new Vector2 (0, jumpValue));
			count = 0;
		}

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag.Equals ("KillItachi")) {
			Destroy (gameObject);
			}

		}
}
