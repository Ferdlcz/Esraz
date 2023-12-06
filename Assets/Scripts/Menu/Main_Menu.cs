using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{

	 void Start()
    {

    
    Cursor.visible = true;
    Cursor.lockState = CursorLockMode.None;
        
    }

	public void NuevaPartida(string StartLevel){
		SceneManager.LoadScene(StartLevel);	
	}

	public void Controles(string Controles){
		SceneManager.LoadScene(Controles);
	}

	public void Salir(){
		Application.Quit();
		Debug.Log("Juego cerrado");
	}

}
