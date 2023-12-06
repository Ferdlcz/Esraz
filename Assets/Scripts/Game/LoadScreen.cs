using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScreen : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI progressText;
    [SerializeField] Slider progressSlider;
    
    private bool cargaIniciada = false;
    private void Update(){
       if(!cargaIniciada && Input.anyKeyDown){
        StartCoroutine(Carga());
        cargaIniciada = true;
    }
    }

    IEnumerator Carga(){
        progressSlider.gameObject.SetActive(true);

        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(3);

        while (loadOperation.isDone == false){
            
            float progress = Mathf.Clamp01(loadOperation.progress / 0.5f);
            progressSlider.value = progress;
            progressText.text = "" + progress * 100 + "%";
            yield return null;
        }

        yield return null;
    }
}
