using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mayinController : MonoBehaviour
{
    public GameObject patlamaEfekti;


    playerHealthController playerHealthController;


    private void Awake()
    {
        playerHealthController = Object.FindObjectOfType<playerHealthController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            PatlamaFNC();

            playerHealthController.HasarAl();
        }
    }


    public void PatlamaFNC()
    {
        Destroy(this.gameObject);

        Instantiate(patlamaEfekti, transform.position, transform.rotation);
    }
}
