using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sesController : MonoBehaviour
{
    public static sesController instance;

    public AudioSource[] sesEfektleri;

    private void Awake()
    {
        instance = this;
    }

    public void SesEfektiCikar(int hangiSes)
    {
        sesEfektleri[hangiSes].Stop();

        sesEfektleri[hangiSes].Play();
    }

    public void karisikSesEfektiCikar(int hangiSes)
    {
        sesEfektleri[hangiSes].Stop();
        sesEfektleri[hangiSes].pitch = Random.Range(0.8f, 1.3f);
        sesEfektleri[hangiSes].Play();
    }
}
