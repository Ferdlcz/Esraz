using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.GlobalIllumination;

public class PlayerHealth : MonoBehaviour
{

    public float HealthPlayer;

    public GameObject spotLight;

    private Animator anim;

    public Slider healtBar;    
    public AudioSource DeathSong;

    public bool canMove = true; 

    public Camera mainCamera;
    public Camera deathCamera;
    

    void Start()
    {
        anim = GetComponent<Animator>();
        mainCamera.gameObject.SetActive(true);
        deathCamera.gameObject.SetActive(false);
    }

    void Update()
    {

        healtBar.GetComponent<Slider>().value = HealthPlayer;

        if(HealthPlayer <= 0){

            if (!DeathSong.isPlaying) {
                DeathSong.Play();
            }
            
           anim.SetBool("Death", true);

           DisableMovementControls();

           SwitchCamera();

           Invoke("GameEnd", 5f);
        }else{
             if (DeathSong.isPlaying) {
            DeathSong.Pause();
        }
            anim.SetBool("Death", false);
        } 
        
    }

    void DisableMovementControls(){
        canMove = false;
        spotLight.gameObject.SetActive(false);
    }

    void SwitchCamera(){
        mainCamera.gameObject.SetActive(false);
        deathCamera.gameObject.SetActive(true);
    }


     public void GameEnd(){
		SceneManager.LoadScene("DeathScreen");
        Debug.Log("El juego ha terminado");
	}
}
