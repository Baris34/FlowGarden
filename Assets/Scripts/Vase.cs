using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase : MonoBehaviour
{
    public int sayac;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            sayac++;
            Destroy(other.gameObject);
            if (sayac>=100)
            {
                Debug.Log("Tebrikler");
            }
        }
    }
    
}
