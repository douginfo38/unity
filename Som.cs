using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	public class Som : MonoBehaviour {

		private AudioSource AudioS;

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

		//Inicialização do script
		void Start () {
			AudioS = GetComponent<AudioSource>();
		}

		//Metodo public par tocar o som
		//Parametro name = nome do som a ser tocado
		public void PlaySound(string name){	
			switch (name) {
				case "pulo":
					AudioS.PlayOneShot (pulo);
					break;

				case "pedra":
					AudioS.PlayOneShot (pedra);
					break;

				case "fogo":
					AudioS.PlayOneShot (fogo);
					break;

				case "laser":
					AudioS.PlayOneShot (laser);
					break;

			   case "colisao":
				AudioS.PlayOneShot (player);
				break;
			}
		}
	}