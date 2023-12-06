using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ObjectManager : MonoBehaviour
{

    public GameObject winScreen;
    public GameObject staminaCanva;
    public GameObject healthCanva;
    public static ObjectManager Instance;

    public int conteoObjetos = 0;
    public int objetivoConteo = 5;
    public TextMeshProUGUI mensajeInteraccion;
    public TextMeshProUGUI textoConteo;
    public TextMeshProUGUI textoFinal;
    private bool dentroAreaVictoria = false;

    private void Awake(){
        if (Instance == null){
            Instance = this;
        }else{
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ActualizarTextoConteo();
        LimpiarMensajeInteraccion();
    }

    void OnTriggerEnter(Collider other)
{

    if (other.CompareTag("PJ")) 
    {
        if(conteoObjetos < objetivoConteo){
            dentroAreaVictoria = false;
        }
        else{
            dentroAreaVictoria = true;
        }

        if(conteoObjetos >= objetivoConteo && dentroAreaVictoria == true){
            FinalizarJuego();
        }
    }
}

    public void AumentarConteo(){
        conteoObjetos++;
        ActualizarTextoConteo();
        
        if(conteoObjetos >= objetivoConteo){
            textoFinal.text = "Has recogido todos los objetos, vuelve a casa para estar a salvo...";

            Invoke("cleanText", 5);
        }
    }

    public void cleanText(){
        textoFinal.text = "";
    }

    void ActualizarTextoConteo(){
        textoConteo.text = conteoObjetos.ToString();
    }


    void FinalizarJuego(){
        winScreen.gameObject.SetActive(true);
        staminaCanva.gameObject.SetActive(false);
        healthCanva.gameObject.SetActive(false);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void exitGame (){
        Application.Quit();
		Debug.Log("Juego cerrado");
    }

    public void restartGame (){
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        staminaCanva.gameObject.SetActive(true);
        healthCanva.gameObject.SetActive(true);
    }

    public void MostrarMensajeInteraccion(string mensaje)
    {
        mensajeInteraccion.text = mensaje;
    }

        public void LimpiarMensajeInteraccion()
    {
        mensajeInteraccion.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
