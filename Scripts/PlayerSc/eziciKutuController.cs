using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eziciKutuController : MonoBehaviour
{
    [SerializeField]
    GameObject yokOlmaEfekti;

    playerController playerController;


    public float kirazinCikmaSansi;

    public GameObject KirazObje;

    private void Awake()
    {
        playerController = Object.FindObjectOfType<playerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Kurbaga"))
        {
           other.transform.parent.gameObject.SetActive(false);
            Instantiate(yokOlmaEfekti, transform.position , transform.rotation);

            playerController.ZiplaZiplaFNC();

            float cikmaAraligi = Random.Range(0, 100f);

            sesController.instance.SesEfektiCikar(0);

            if(cikmaAraligi <= kirazinCikmaSansi)
            {
                Instantiate(KirazObje, other.transform.position , other.transform.rotation);
            }
        }
    }
}
