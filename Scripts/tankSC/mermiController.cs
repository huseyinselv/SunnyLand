using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mermiController : MonoBehaviour
{
    public float mermiHizi;

    playerHealthController playerHealthController;

    private void Awake()
    {
        playerHealthController = Object.FindObjectOfType<playerHealthController>();
    }

    private void Update()
    {
        transform.position += new Vector3(-mermiHizi  *transform.localScale.x * Time.deltaTime, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerHealthController.HasarAl();
            
        }
        Destroy(gameObject);
    }
}
