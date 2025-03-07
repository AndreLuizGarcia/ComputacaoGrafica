﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NarutoController : MonoBehaviour {

	public AudioSource audioController;
	public AudioClip coinAudio; 
	public AudioClip narutoAudio; 
	public AudioClip itachiAudio; 

	//Variavel responsavel por referenciar o Animator Controller.
	public Animator animator;

	//Instancia do Rigidbody do personagem.
	public Rigidbody2D body;

	//Transform contendo a posição do objeto floorcheck.
	public Transform floorCheckTransform;

	//Camada do chão.
	public LayerMask isFloor;

	//Intensidade do pulo.
	public int jumpValue;

	//Variavel que indica se o player está no chão.
	public bool onFloor;

	//Variaveis de Controle do Personagem
	public bool jump,chutar,run,socar;

	public int velocity;
	public Text ItachiCount;
	public Text CoinCount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Recebe estado do botao pular
		jump = Input.GetButtonDown ("Jump");

		//Recebe estado do botao chutar
		chutar = Input.GetButtonDown ("Chutar");
		//Passa o estado do botão chutar para a Animation Controller, para o parametro chutar.
		animator.SetBool ("chutar", chutar);

		//Recebe estado do botao correr
		run = Input.GetButton ("Run");

		//Recebe estado do botao socar
		socar = Input.GetButtonDown ("Socar");
		//Passa o estado do botão socar para a Animation Controller, para o parametro socar.
		animator.SetBool ("socar", socar);

		//Cria uma região para verificação, de raio 0.2, situada na mesma posição do objeto
		//groundCheck, verificando a camada isFloor.
		//Salva true caso esteja no chão, e false caso esteja no ar.
		onFloor = Physics2D.OverlapCircle (floorCheckTransform.position, 0.05f, isFloor);



		if (Input.GetAxisRaw ("Horizontal") > 0) {

			transform.Translate(Vector2.right*velocity*Time.deltaTime);
			transform.eulerAngles = new Vector2 (0, 0);
			run = true;


//		}
		//if(run){

		//	audioController.PlayOneShot (coinAudio);
			
		//} else if(jump){
		//	audioController.PlayOneShot (coinAudio);

		//}else if(socar){
		//	audioController.PlayOneShot (coinAudio);
	}else if (Input.GetAxisRaw ("Horizontal") < 0) {

			transform.Translate(Vector2.right*velocity*Time.deltaTime);
			transform.eulerAngles = new Vector2 (0, 180);
			run = true;

		}

		//Verificação se o player está no chão e pressionou o botão jump.
		if (onFloor && jump) {
			body.AddForce (new Vector2 (0, jumpValue));
		}

		if (body.velocity.y == 0) {
		
			onFloor = true;
		}

		//Passa o estado do botão pular para a Animation Controller, para o parametro pular.
		animator.SetBool ("jump", !onFloor);

		//Passa o estado do botão correr para a Animation Controller, para o parametro correr.
		animator.SetBool ("run", run);

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag.Equals ("Enimy")) {
			if (animator.GetBool ("socar") | animator.GetBool("chutar")) {
				Destroy (other.gameObject);
				audioController.PlayOneShot (itachiAudio);
				ItachiCount.text = "" + (System.Int32.Parse(ItachiCount.text.ToString()) + 1);
				if (ItachiCount.text == "5") {
					SceneManager.LoadScene ("scene2");
				}
			} else {
				CoinCount.text = "" + (System.Int32.Parse(CoinCount.text.ToString()) - 1);
				audioController.PlayOneShot (narutoAudio);
				Destroy (other.gameObject);
			}if (CoinCount.text == "0") {
				SceneManager.LoadScene ("gameover");
				animator.SetBool ("dead", true);
			}
		}
	}
}