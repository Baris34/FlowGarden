using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vase : MonoBehaviour
{
    
    public int sayac;
    public GameObject[] Graystars;
    public GameObject[] YellowStars;
    public Slider Slider;

    private bool isGetFirstStars;
    private bool isGetSecondStars;
    private bool isGetThirdStars;
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Water"))
        {
            sayac++;
            Destroy(other.gameObject);
            if (sayac >= 30 && !isGetFirstStars)
            {
                YellowStars[0].SetActive(true);
                NextButtonControl.Instance.starScore++;
                isGetFirstStars = true;
            }
            if (sayac >= 70 && !isGetSecondStars)
            {
                YellowStars[1].SetActive(true);
                NextButtonControl.Instance.starScore++;
                isGetSecondStars = true;
            }
            if (sayac >= 100 && !isGetThirdStars)
            {
                YellowStars[2].SetActive(true);
                NextButtonControl.Instance.starScore++;
                isGetThirdStars = true;
            }
            
        }
    }
    private void Update()
    {
        Slider.value = sayac;
    }

}
