using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAnimation : MonoBehaviour
{


    public float scaleFactorMax = 1.2f;    // Factor m�ximo de escala
    public float scaleFactorMin = 1.0f;    // Factor m�nimo de escala
    public float duration = 2.0f;          // Duraci�n de cada ciclo de animaci�n

    private Vector3 originalScale;

    private void Start()
    {
        originalScale = transform.localScale;

        // Inicia la animaci�n autom�ticamente al comienzo del juego
        StartCoroutine(ScaleText());
    }

    private IEnumerator ScaleText()
    {
        while (true) // Esto mantendr� la animaci�n en un bucle infinito
        {
            // Aumenta gradualmente el tama�o
            float elapsedTime = 0f;
            while (elapsedTime < duration)
            {
                float t = elapsedTime / duration;
                Vector3 newScale = Vector3.Lerp(originalScale, originalScale * scaleFactorMax, t);
                transform.localScale = newScale;
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Reduzca gradualmente el tama�o de nuevo
            elapsedTime = 0f;
            while (elapsedTime < duration)
            {
                float t = elapsedTime / duration;
                Vector3 newScale = Vector3.Lerp(originalScale * scaleFactorMax, originalScale * scaleFactorMin, t);
                transform.localScale = newScale;
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Restablece la escala al valor original
            transform.localScale = originalScale;

            // Espera un breve tiempo antes de comenzar el siguiente ciclo
            yield return new WaitForSeconds(0.5f); // Ajusta el tiempo de espera seg�n tus necesidades
        }
    }
}
