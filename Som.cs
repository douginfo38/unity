using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	public class Som : MonoBehaviour {

		private AudioSource audioS;

		//Sons do personagem
		[Header("PERSONAGEM")]
	    [SerializeField]
		private AudioClip pulo;

		//Sons dos npcs e objetos
		[Header("NPC / OBJETOS")]
	    [SerializeField]
		private AudioClip pedra;
	    [SerializeField]   
		private AudioClip fogo;
	    [SerializeField]
		private AudioClip serra;

		//sons de colisão do player
		[Header("COLISÕES")]
	    [SerializeField]   
		private AudioClip player;
	    [SerializeField]
		private AudioClip laser;

		[Header("MUSICAS")]
		[SerializeField]   
		private AudioClip abertura;
		[SerializeField]
		private AudioClip fase1;
		[SerializeField]
		private AudioClip final;

		//Inicialização do script
		void Start () {
			audioS = GetComponent<AudioSource>();
		}

		//Metodo public par tocar o som
		//Parametro name = nome do som a ser tocado
		public void PlaySound(string name){	
			switch (name) {
				case "pulo":
					audioS.PlayOneShot (pulo);
					break;

				case "pedra":
					audioS.PlayOneShot (pedra);
					break;

				case "fogo":
					audioS.PlayOneShot (fogo);
					break;

				case "laser":
					audioS.PlayOneShot (laser);
					break;

			   case "colisao":
					audioS.PlayOneShot (player);
					break;
			}
		}

	//Metodo public para tocar as musicas
	//Parametro name = nome da musica a ser tocada
	public void PlayMusic(string nameMusic){	

		if (audioS.isPlaying) {
			audioS.Stop();
		}

		switch (nameMusic) {
			case "abertura":
				audioS.clip  = abertura;
				break;

			case "fase1":
				audioS.clip = fase1;
				break;

			case "final":
				audioS.clip = final;
				break;		
			}

		if (audioS.clip != null) {
			audioS.Play ();
		}
	  }
	}