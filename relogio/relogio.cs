using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class relogio : MonoBehaviour {

	private enum State
	{
		Start,
		Stop,
		Pause
	};
   
	[Header("CONFIGURAÇÕES")]
	public Text tempo;
    public bool decrementar = false;
	public int tempoHoras;
	public int tempoMinutos;
	public int tempoSegundos;
	public bool stopped;

	private int segundos;
	private int minutos;
	private int horas;
	private int contarTempo;
	private State state;
	private Principal principal;

	void Start () {
		state = State.Stop;
		stopped = false;
		segundos = tempoSegundos;
		minutos = tempoMinutos;
		horas = tempoHoras;
	    principal = GetComponent<Principal> ();
	}
	
	//Contador do tempo
	private IEnumerator Temporizador () {
		while (true) {
			yield return new WaitForSeconds (1);

				if (decrementar == true) {
					segundos = segundos - 1;
		
					if (segundos < 0) {
						minutos -= 1;
						segundos = 59;
					}
					;

				} else {
					segundos = segundos + 1;

					if (segundos == 60) {
						minutos += 1;
						segundos = 0;
					}
				}

			if (minutos != -1){
				if (segundos < 10) {
					tempo.text = "0" + minutos + ":0" + segundos;
				} else {
					tempo.text = "0" + minutos + ":" + segundos;
				}			
			} else {
					tempo.text = "00:00";
				   StopTimer ();
			}
	}
}

	//incrementar ou decrementar tempo do relogio
	public void atualizarTempo(int temp){
		int auxtime = 0;

		if (decrementar == true) {

			auxtime = segundos - temp;

			if (auxtime < 0) {
				minutos -= 1;
				segundos = 60 + auxtime; 
			} else {
				segundos -=  temp; 
			}

		} else {

			auxtime = segundos + temp;

			if (auxtime > 60) {
				minutos += 1;
				segundos = 0 +(60 - auxtime); 
			} else {
				segundos +=  temp; 
			}
			
		}
	}

	public void StartTimer(){
		state = State.Start;
		stopped = false;
		StartCoroutine ("Temporizador");
	}

	public void StopTimer(){
		state = State.Stop;
		stopped = true;
		StopCoroutine ("Temporizador");
	}

	public void ResetTimer(){
		state = State.Stop;
		stopped = false;
		StopCoroutine ("Temporizador");
		segundos = tempoSegundos;
		minutos = tempoMinutos;
	}

}
