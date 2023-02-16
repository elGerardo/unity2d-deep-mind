using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public string nombreDeLaEscena;  // Nombre de la escena donde se encuentra el Timeline
    public string nombreDelTimeline; // Nombre del objeto que contiene el PlayableDirector del Timeline

    void Start()
    {
        CargarEscenaYReproducirTimeline();
    }

    public void CargarEscenaYReproducirTimeline()
    {
        SceneManager.LoadScene(nombreDeLaEscena);

        GameObject timelineObjeto = GameObject.Find(nombreDelTimeline);
        if (timelineObjeto != null)
        {
            PlayableDirector timelineDirector = timelineObjeto.GetComponent<PlayableDirector>();
            if (timelineDirector != null)
            {
                timelineDirector.Play();
            }
        }
    }
}
