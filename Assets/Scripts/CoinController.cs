using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoinController : MonoBehaviour {

	public AudioSource audioController;
	public AudioClip coinAudio; 

	public bool inVida;
	public LayerMask isPlayer;
	public Text CoinCount;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		inVida = Physics2D.OverlapCircle (transform.position, 0.05f, isPlayer);
		if(inVida){

			CoinCount.text = "" + (System.Int32.Parse(CoinCount.text.ToString()) + 1); 

			audioController.PlayOneShot (coinAudio);


			Destroy (gameObject);



			//SceneManager.LoadScene ("menu");
		}
	}
}