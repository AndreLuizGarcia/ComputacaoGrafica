using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform Naruto;

	private Vector2 velocity;

	public float smooth;

	// Use this for initialization
	void Start () {
		velocity = new Vector2 (0.5f,0.5f);

		smooth = 0.5f;
	}

	// Update is called once per frame
	void Update () {

		Vector3 newPosition = Vector3.zero;

		newPosition.x = Mathf.SmoothDamp (transform.position.x, Naruto.position.x,ref velocity.x,smooth);

		newPosition.y = Mathf.SmoothDamp (transform.position.y, Naruto.position.y+(8/10),ref velocity.y,smooth);

		newPosition.z = transform.position.z;

		transform.position = Vector3.Slerp (transform.position, newPosition, Time.time);


	}
}
