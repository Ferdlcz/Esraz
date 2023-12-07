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
    public GameObject ambientSong;
    public static ObjectManager Instance;
    public GameObject winSound;
    public int conteoObjetos = 0;
    public int objetivoConteo = 5;
    public TextMeshProUGUI mensajeInteraccion;
    public TextMeshProUGUI textoConteo;
    public TextMeshProUGUI textoFinal;
    public TextMeshProUGUI instrucciones;
    private bool dentroAreaVictoria = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ActualizarTextoConteo();
        LimpiarMensajeInteraccion();
        Instrucciones();
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("PJ"))
        {
            if (conteoObjetos < objetivoConteo)
            {
                dentroAreaVictoria = false;
            }
            else
            {
                dentroAreaVictoria = true;
            }

            if (conteoObjetos >= objetivoConteo && dentroAreaVictoria == true)
            {
                FinalizarJuego();
            }
        }
    }

    public void AumentarConteo()
    {
        conteoObjetos++;
        ActualizarTextoConteo();

        if (conteoObjetos >= objetivoConteo)
        {
            textoFinal.text = "Has recogido todos los objetos, vuelve a casa para estar a salvo...";

            Invoke("cleanText", 5);
        }
    }

    public void cleanText()
    {
        textoFinal.text = "";
    }

    void ActualizarTextoConteo()
    {
        textoConteo.text = conteoObjetos.ToString();
    }


    void FinalizarJuego()
    {
        ambientSong.gameObject.SetActive(false);
        winSound.gameObject.SetActive(true);
        winScreen.gameObject.SetActive(true);
        staminaCanva.gameObject.SetActive(false);
        healthCanva.gameObject.SetActive(false);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void exitGame()
    {
        Application.Quit();
        Debug.Log("Juego cerrado");
    }

    public void restartGame()
    {
        winSound.gameObject.SetActive(false);
        ambientSong.gameObject.SetActive(true);
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

    void Instrucciones()
    {
        Invoke("first", 2);
        Invoke("second", 5);
        Invoke("third", 8);
        Invoke("fourth", 11);
        Invoke("fifth", 14);
        Invoke("limpiarInstrucciones", 17);
    }

    void first(){
        instrucciones.text = "Asegurate de encontrar los 5 objetos que se han perdido para poder volver a casa";
    }

    void second(){
        instrucciones.text = "Puedes ver tu objetivo presionando la tecla O";
    }

    void third(){
        instrucciones.text = "Puedes agacharte para recuperar tu resistencia mas rapido";
    }

    void fourth(){
        instrucciones.text = "Presiona V para atacar a tu enemigo, solo puedes hacerle daño cuando esta alzando la mano para atacarte";
    }

    void fifth(){
        instrucciones.text = "SUERTE...";
    }

    void limpiarInstrucciones(){
        instrucciones.text = "";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
