using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameTime());

    }

    public void RestartGame(){
		SceneManager.LoadScene("TimeOverScreen");
        Debug.Log("El juego ha terminado");
	}

    IEnumerator GameTime(){
        yield return new WaitForSeconds(1800); //30min
        RestartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
