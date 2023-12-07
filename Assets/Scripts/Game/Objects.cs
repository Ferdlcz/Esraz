using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Objects : MonoBehaviour
{

    private bool puedeRecoger = false;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if(puedeRecoger && Input.GetKeyDown(KeyCode.E)){
            RecogerObjeto();
        }

    }

      private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PJ"))
        {
            puedeRecoger = true;
            ObjectManager.Instance.MostrarMensajeInteraccion("Presiona E para tomar el objeto");            
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.CompareTag("PJ")){
            puedeRecoger = false;
            ObjectManager.Instance.LimpiarMensajeInteraccion();
        }
    }

    void RecogerObjeto(){
        ObjectManager.Instance.AumentarConteo();
        ObjectManager.Instance.LimpiarMensajeInteraccion();
        DestruirObjeto();

    }

    void DestruirObjeto()
{
    Destroy(gameObject);
}

}
