using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthFollowCamera : MonoBehaviour
{
    // Referencia a la c�mara principal de la escena
    public Camera mainCamera;

    // Distancia en unidades del mundo entre el objeto y la esquina de la c�mara
    public float distanciaDesdeEsquina = 1f;

    // Actualiza la posici�n del objeto en cada frame
    void Update()
    {
        // Obtiene la posici�n de la c�mara y la esquina inferior izquierda de la pantalla
        Vector3 camaraPos = mainCamera.transform.position;
        Vector3 esquinaInferiorIzquierda = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, camaraPos.z));

        // Calcula la posici�n del objeto a partir de la posici�n de la c�mara y la distancia deseada
        Vector3 nuevaPosicion = new Vector3(esquinaInferiorIzquierda.x + distanciaDesdeEsquina - 1.5f, esquinaInferiorIzquierda.y + distanciaDesdeEsquina, transform.position.z);

        // Asigna la nueva posici�n al objeto
        transform.position = nuevaPosicion;
    }
}
