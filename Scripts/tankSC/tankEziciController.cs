using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankEziciController : MonoBehaviour
{

    playerController playerController;
    tankController tankController;
    private void Awake()
    {
        playerController = Object.FindObjectOfType<playerController>();
        tankController = Object.FindObjectOfType<tankController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")&& playerController.transform.position.y > transform.position.y)
        {
            playerController.ZiplaZiplaFNC();

            tankController.darbeAlFNC();

            gameObject.SetActive(false);

        }
    }
}
