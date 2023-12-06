using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public GameObject MenuPause;
    public bool pause = false;

     private CameraController cameraController;

    // Start is called before the first frame update
    void Start()
    {
        cameraController = GameObject.FindObjectOfType<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){

            if(pause == false){
                MenuPause.SetActive(true);
                pause = true;

                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }else if(pause == true){
                Reanudar();
            } 
        }
    }

    public void Reanudar(){
        MenuPause.SetActive(false);
        pause = false;

        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void MainMenu(string GoMainMenu){
        SceneManager.LoadScene(GoMainMenu);
        MenuPause.SetActive(false);
        pause = false;
        Time.timeScale = 1;
    }

    public void Salir(){
        Application.Quit();
		Debug.Log("Juego cerrado");
    }
}
