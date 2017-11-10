using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public AudioSource audioController;
	public AudioClip menuAudio; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		bool start = Input.GetButtonDown ("Jump");

		if(start){
			SceneManager.LoadScene("scene1");
			audioController.PlayOneShot (menuAudio);
		}
	}
}
