using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class tankController : MonoBehaviour
{

    public enum tankDurumlari {atesEtme, darbeAlma , HareketEtme , tankSonaErdi};
    public tankDurumlari gecerliDurum;





    [SerializeField]
    Transform tankObje;

    public Animator anim;

    [Header("Hareket")]
    public float hareketHizi;
    public Transform solHedef, sagHedef;
    bool yonuSagMi;
    public GameObject mayinObje;
    public Transform mayinMerkezNoktasi;
    public float mayinBirakmaSuresi;
    public float mayinBirakmaSayac;

    [Header("AtesEtme")]
    public GameObject mermi;
    public Transform mermiMerkezi;
    public float mermiAtmaSuresi;
    float mermiAtmaSayaci;

    [Header("Darbe")]
    public float darbeSuresi;
    float darbeSayaci;

    [Header("CanDurumu")]
    public int canDurumu = 5;
    public GameObject tankPatlamaEfekti;
    bool yenildiMi;
    public float mermiSuresiArtir, mayinBirakmaSuresiAtir;


    public GameObject tankEziciKutu;

    private void Start()
    {
        gecerliDurum = tankDurumlari.atesEtme;
    }
    private void Update()
    {
        switch(gecerliDurum)
        {
            case tankDurumlari.atesEtme:
                //ates edildiði zaman olacka durumlar
                mermiAtmaSayaci -= Time.deltaTime;

                if(mermiAtmaSayaci <= 0)
                {
                    mermiAtmaSayaci = mermiAtmaSuresi;

                    var yeniMermi = Instantiate(mermi , mermiMerkezi.position , mermiMerkezi.rotation);

                    yeniMermi.transform.localScale = tankObje.localScale;
                }
                break;
            case tankDurumlari.darbeAlma:
                //darba alýnca o d

                if(darbeSayaci > 0)
                {
                    darbeSayaci -= Time.deltaTime;
                    if(darbeSayaci <=0)
                    {
                        gecerliDurum = tankDurumlari.HareketEtme;
                        mayinBirakmaSayac = 0;

                        if(yenildiMi)
                        {
                            tankObje.gameObject.SetActive(false);
                            Instantiate(tankPatlamaEfekti , transform.position , transform.rotation);

                            gecerliDurum = tankDurumlari.tankSonaErdi;
                        }
                    }
                } 
                break;

            case tankDurumlari.HareketEtme:
                //hareket etme o d

                if(yonuSagMi)
                {
                    tankObje.position += new Vector3(hareketHizi * Time.deltaTime, 0f, 0f);

                    if(tankObje.position.x > sagHedef.position.x)
                    {
                        tankObje.localScale = new Vector3(1, 1, 1);
                        yonuSagMi = false;


                        hareketiDurdurFNC();
                    }
                }
                else
                {
                    tankObje.position -= new Vector3(hareketHizi * Time.deltaTime, 0f, 0f);

                    if (tankObje.position.x < solHedef.position.x)
                    {
                        tankObje.localScale = new Vector3(-1, 1, 1);
                        yonuSagMi = true;

                        hareketiDurdurFNC();
                        
                    }
                }
                mayinBirakmaSayac -= Time.deltaTime;
                if(mayinBirakmaSayac <= 0 )
                {
                    mayinBirakmaSayac = mayinBirakmaSuresi;

                    Instantiate(mayinObje, mayinMerkezNoktasi.position, mayinMerkezNoktasi.rotation);
                }

                break;

  
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            darbeAlFNC();
        }
    }

    public void darbeAlFNC()
    {

        gecerliDurum = tankDurumlari.darbeAlma;
        darbeSayaci = darbeSuresi;

        anim.SetTrigger("vur");

        mayinController[]mayinlar = FindObjectsOfType<mayinController>();

        if(mayinlar.Length > 0 )
        {
            foreach( mayinController bulunanMayin in mayinlar )
            {
                bulunanMayin.PatlamaFNC();
            }
        }
        canDurumu--;

        if(canDurumu <= 0 )
        {
            yenildiMi = true;
        } else
        {
            mermiAtmaSuresi /= mermiSuresiArtir;
            mayinBirakmaSuresi /= mayinBirakmaSuresiAtir;
        }
    }

    void hareketiDurdurFNC()
    {
        tankEziciKutu.SetActive(true);

        gecerliDurum = tankDurumlari.atesEtme;
        mermiAtmaSayaci = mermiAtmaSuresi;
        anim.SetTrigger("hareketiDurdur");
    }
}
