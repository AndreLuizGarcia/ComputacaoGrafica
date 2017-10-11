using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeController : MonoBehaviour {

	public LayerMask maskSpike;

	public Transform groundCheck;

	//public Animator animator;

	public bool dead, inSpike;

	public int aux;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//se o groundcheck encostar na camada do espinho
		inSpike = Physics2D.OverlapCircle (groundCheck.position, 0.005f, maskSpike);
		if (inSpike) {
			//animator.SetBool ("dead", dead);

			//StartCoroutine (waitDeadAnimation ());
			SceneManager.LoadScene ("gameover");
			}

		}
	IEnumerator waitDeadAnimation(){
	
		yield return new WaitForSeconds (8f);
		//SceneManager.LoadScene ("gameover");
	}
}
