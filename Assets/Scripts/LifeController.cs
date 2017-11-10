using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeController : MonoBehaviour {


	public bool inVida;
	public LayerMask isPlayer;



	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		inVida = Physics2D.OverlapCircle (transform.position, 0.01f, isPlayer);
		if(inVida){

			SceneManager.LoadScene ("menu");
		}
	}
}
