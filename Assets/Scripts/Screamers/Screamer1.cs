using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screamer1 : MonoBehaviour
{

    public GameObject imgScreamer;

    public AudioSource SoundScreamer;

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "PJ"){
            imgScreamer.SetActive(true);
            SoundScreamer.Play();
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "PJ"){
            imgScreamer.SetActive(false);
            Destroy(this);
        }
    }

}
