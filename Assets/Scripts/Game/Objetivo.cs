using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetivo : MonoBehaviour
{

    public GameObject objetiveCanva;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O)){

            if(!objetiveCanva.gameObject.activeSelf){
                showObjetive();
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    public void showObjetive(){
        objetiveCanva.gameObject.SetActive(true);
    }

    public void hideObjetive(){
        objetiveCanva.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
