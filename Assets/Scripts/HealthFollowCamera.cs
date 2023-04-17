using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthFollowCamera : MonoBehaviour
{
    // Referencia a la cámara principal de la escena
    public Camera mainCamera;

    // Distancia en unidades del mundo entre el objeto y la esquina de la cámara
    public float distanciaDesdeEsquina = 1f;

    // Actualiza la posición del objeto en cada frame
    void Update()
    {
        // Obtiene la posición de la cámara y la esquina inferior izquierda de la pantalla
        Vector3 camaraPos = mainCamera.transform.position;
        Vector3 esquinaInferiorIzquierda = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, camaraPos.z));

        // Calcula la posición del objeto a partir de la posición de la cámara y la distancia deseada
        Vector3 nuevaPosicion = new Vector3(esquinaInferiorIzquierda.x + distanciaDesdeEsquina - 1.5f, esquinaInferiorIzquierda.y + distanciaDesdeEsquina, transform.position.z);

        // Asigna la nueva posición al objeto
        transform.position = nuevaPosicion;
    }
}
