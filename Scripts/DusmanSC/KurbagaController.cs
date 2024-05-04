using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KurbagaController : MonoBehaviour
{
    public float hareketHizi;

    public Transform solHedef, sagHedef;

    bool sagTarafta;


    Rigidbody2D rb;

    public SpriteRenderer sr;

    public float hareketSuresi, beklemeSuresi;
    float hareketSayaci , beklemeSayaci ;

    Animator anim;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        solHedef.parent = null;
        sagHedef.parent = null;

        sagTarafta = true;

        hareketSayaci = hareketSuresi;
    }

    private void Update()
    {
        if (hareketSayaci > 0)
        {
            hareketSayaci -= Time.deltaTime;


            if (sagTarafta)
            {
                rb.velocity = new Vector2(hareketHizi, rb.velocity.y);
                sr.flipX = true;

                if (transform.position.x > sagHedef.position.x)
                {
                    sagTarafta = false;
                }
            }
            else
            {
                rb.velocity = new Vector2(-hareketHizi, rb.velocity.y);
                sr.flipX = false;

                if (transform.position.x < solHedef.position.x)
                {
                    sagTarafta = true;
                }

            }
            if(hareketSayaci <= 0)
            {
                beklemeSayaci = Random.Range(beklemeSuresi * 0.7f, beklemeSuresi * 1.2f);
            }

            anim.SetBool("hareketEdiyor", true);
        } else if(beklemeSayaci > 0)
        {
            beklemeSayaci -= Time.deltaTime;
            rb.velocity = new Vector2 (0 , rb.velocity.y);

            if(beklemeSayaci <= 0)
            {
                hareketSayaci = Random.Range(hareketSuresi * 0.7f, hareketSuresi * 1.2f);
            }

            anim.SetBool("hareketEdiyor", false);
        }
    }
}
