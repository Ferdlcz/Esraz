using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class speaker : MonoBehaviour
{

    private AudioSource audioSource;
    
    private bool enColision = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PJ"))
        {
            enColision = true;
        }
    }

      void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PJ"))
        {
            enColision = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (enColision)
        {
            if (audioSource.volume < 1.0f)
            {
                audioSource.volume += Time.deltaTime;
            }
        }
        else
        {
            if (audioSource.volume > 0.0f)
            {
                audioSource.volume -= Time.deltaTime;
            }
        }
    }
        
    }
