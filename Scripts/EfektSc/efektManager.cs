using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class efektManager : MonoBehaviour
{
    [SerializeField]
    float yasamSuresi;


    private void Start()
    {
        Destroy(gameObject, yasamSuresi);
    }
}
