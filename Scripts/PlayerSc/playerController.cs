using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField]
    float hareketHizi;

    [SerializeField]
    float ziplamaGucu;

    Rigidbody2D rb;

    Animator anim;

    bool yerdemi;
    public Transform zeminKontrolNoktasi;
    public LayerMask zeminLayer;
    bool ikiKezZiplayabilirMi;

    public float geriTepmeSuresi, geriTepmeGucu;
    float geriTepmeSayaci;
    bool yonSagmi;

    public float ziplaZiplaGucu;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(geriTepmeSayaci <= 0)
        {
            HareketEttirFNC();
            ZiplaFNC();
            YonuDegistirFNC();
        } else
        {
            geriTepmeSayaci -= Time.deltaTime;

            if(yonSagmi)
            {
                rb.velocity = new Vector2 (-geriTepmeGucu, rb.velocity.y);
            } else
            {
                rb.velocity = new Vector2 (geriTepmeGucu , rb.velocity.y);
            }
        }

        anim.SetFloat("hareketHizi", Mathf.Abs(rb.velocity.x));
        anim.SetBool("yerdemi", yerdemi);

    }

    void HareketEttirFNC ()
    {
        float h = Input.GetAxis("Horizontal");
        float hiz = h * hareketHizi;

        rb.velocity = new Vector2 (hiz , rb.velocity.y);
    }

    void ZiplaFNC()
    {
        yerdemi = Physics2D.OverlapCircle(zeminKontrolNoktasi.position, .2f , zeminLayer);
        if(yerdemi)
        {
            ikiKezZiplayabilirMi = true;
        }

        if(Input.GetButtonDown("Jump"))
        {
            if (yerdemi)
            {
                rb.velocity = new Vector2(rb.velocity.x, ziplamaGucu);
                sesController.instance.SesEfektiCikar(3);

            }
            else
            {
                if (ikiKezZiplayabilirMi)
                {
                    rb.velocity = new Vector2(rb.velocity.x, ziplamaGucu);
                    ikiKezZiplayabilirMi = false;
                    sesController.instance.SesEfektiCikar(3);

                }
            }
            
        }

       
    }

    void YonuDegistirFNC()
    {
        Vector2 geciciScale = transform.localScale;

        if(rb.velocity.x > 0)
        {
            yonSagmi = true;
            geciciScale.x = 1f;
        } else if (rb.velocity.x < 0)
        {
            yonSagmi = false;
            geciciScale.x = -1f;
        }
  
       transform.localScale = geciciScale;
    }

    public void GeriTepmeFNC()
    {
        geriTepmeSayaci = geriTepmeSuresi;
        rb.velocity = new Vector2(0,rb.velocity.y);

        anim.SetTrigger("hasar");
    }

    public void ZiplaZiplaFNC()
    {
        rb.velocity = new Vector2(rb.velocity.x, ziplaZiplaGucu);
        sesController.instance.SesEfektiCikar(3);

    }
}

