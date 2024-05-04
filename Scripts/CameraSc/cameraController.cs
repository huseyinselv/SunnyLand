using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    [SerializeField]
    Transform hedefTransform;

    [SerializeField]
    float minY, maxY;

    Vector2 sonPos;

    [SerializeField]
    Transform altZemin, ortaZemin;

    private void Start()
    {
        sonPos = transform.position;
    }




    private void Update()
    {
        KemerayiSinirlaFNC();
        ZeminleriHareketEttirFNC();
    }

    void KemerayiSinirlaFNC()
    {
        transform.position = new Vector3(hedefTransform.position.x,
          Mathf.Clamp(hedefTransform.position.y, minY, maxY),
          transform.position.z);
    }
    void ZeminleriHareketEttirFNC()
    {
        Vector2 aradakiMiktar = new Vector2(transform.position.x-sonPos.x , transform.position.y-sonPos.y);

        altZemin.position += new Vector3(aradakiMiktar.x, aradakiMiktar.y, 0f);
        ortaZemin.position += new Vector3(aradakiMiktar.x, aradakiMiktar.y, 0f)*.5f;

        sonPos = transform.position;

    }




        
}
