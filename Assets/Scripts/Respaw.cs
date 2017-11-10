using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respaw : MonoBehaviour {

	public GameObject enemy;

	private int count;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		count = count + 1;

		if (count == 360) {
			Instantiate (enemy, transform.position, Quaternion.identity, transform);
			count = 0;
		}
	}
}
