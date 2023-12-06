using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour
{
    public AudioSource musicBox;

    private bool colision = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PJ"))
        {
            colision = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PJ"))
        {
            colision = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (colision)
        {
            if (musicBox.volume < 1.0f)
            {
                musicBox.volume += Time.deltaTime;
            }
        }
        else
        {
            if (musicBox.volume > 0.0f)
            {
                musicBox.volume -= Time.deltaTime;
            }
        }
    }
}
