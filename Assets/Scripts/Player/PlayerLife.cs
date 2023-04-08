using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class PlayerLife : MonoBehaviour
{
    public int lifes;
    public GameObject Player; // Referencia al objeto del jugador que se destruirá al perder todas las vidas

    // Update is called once per frame
    void Update()
    {
        if(lifes <= 0)
        {
            Destroy(Player);
        }
    }
}
