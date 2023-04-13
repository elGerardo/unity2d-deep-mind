using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalIntensity : MonoBehaviour
{
    private PlayerController playerController;
    private 

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(gameObject.name == "isComingBoss") playerController.isComingBoss = true;
            if (gameObject.name == "isWithBoss") playerController.isWithBoss = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.name == "isComingBoss") playerController.isComingBoss = false;
            if (gameObject.name == "isWithBoss") playerController.isWithBoss = false;
        }
    }
}
