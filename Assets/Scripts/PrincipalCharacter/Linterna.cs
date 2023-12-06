using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linterna : MonoBehaviour
{

    public Light linterna;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)){
            if(linterna.enabled == true){

                linterna.enabled = false;
            
            }else if(linterna.enabled == false){
                
                linterna.enabled = true;
            
            }
        }
    }
}
