using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toplamaManager : MonoBehaviour
{


    [SerializeField]
    bool mucevhermi, kirazmi;

    [SerializeField]
    GameObject toplamaEfekt;

    bool toplandimi;

    levelManager levelManager;
    UIController uiController;
    playerHealthController playerHealthController;



    private void Awake()
    {
        levelManager = Object.FindObjectOfType<levelManager>();
        uiController = Object.FindObjectOfType<UIController>();
        playerHealthController = Object.FindObjectOfType<playerHealthController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !toplandimi )
        {
            if(mucevhermi)
            {
                levelManager.toplananMucevherSayisi++;

                toplandimi = true;
                Destroy(gameObject);

                uiController.MucevherSayisiGuncelleFNC();

                Instantiate(toplamaEfekt, transform.position, transform.rotation);

                sesController.instance.karisikSesEfektiCikar(7);
            } 

            if(kirazmi)
            {
                if(playerHealthController.gecerliSaglik != playerHealthController.maxSaglik)
                {
                    
                    toplandimi = true;
                    Destroy(gameObject);
                    playerHealthController.CaniArttirFNC();
                    Instantiate(toplamaEfekt, transform.position, transform.rotation);

                    sesController.instance.SesEfektiCikar(4);
                }

            }
            
        }
          
    }
}
