using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealthController : MonoBehaviour
{
    
    public int maxSaglik, gecerliSaglik;

    [SerializeField]
    GameObject yokOlmaEfekti;

    UIController uicontroller;

    public float yenilmezlikSuresi;
    float yenilmezlikSayaci;

    SpriteRenderer sr;

    playerController playerController;


    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        uicontroller = Object.FindObjectOfType<UIController>();
        playerController = Object.FindObjectOfType<playerController>();
    }
    private void Start()
    {
        gecerliSaglik = maxSaglik;
    }

    private void Update()
    {
        yenilmezlikSayaci -= Time.deltaTime;

        if(yenilmezlikSayaci <= 0)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
        }
    }

    public void HasarAl()
    { 
        if(yenilmezlikSayaci <= 0)
        {
            gecerliSaglik--;

            if (gecerliSaglik <= 0)
            {
                gecerliSaglik = 0;
                gameObject.SetActive(false);

                Instantiate(yokOlmaEfekti , transform.position , transform.rotation );

                sesController.instance.SesEfektiCikar(2);
            }
            else
            {
                yenilmezlikSayaci = yenilmezlikSuresi;
                sr.color = new Color(sr.color.r , sr.color.g , sr.color.b , 0.5f);

                playerController.GeriTepmeFNC();
                sesController.instance.SesEfektiCikar(1);

            }

            uicontroller.SaglikDurumunuGuncelleFNC();
        }
       

        
    }

    public void CaniArttirFNC()
    {
        gecerliSaglik++;

        if(gecerliSaglik >= maxSaglik)
        {
            gecerliSaglik = maxSaglik;
        }

        uicontroller.SaglikDurumunuGuncelleFNC();
    }

}
