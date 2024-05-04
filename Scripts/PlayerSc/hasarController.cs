using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hasarController : MonoBehaviour
{
    playerHealthController playerHealthController;
    private void Awake()
    {
        playerHealthController = Object.FindObjectOfType<playerHealthController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            playerHealthController.HasarAl();
        }

    }
}
