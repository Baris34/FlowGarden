using Ricimi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButtonControl : MonoBehaviour
{
    public static NextButtonControl Instance;
    public GameObject levelComplete;
    public GameObject levelUnComplete;
    public int starScore;
    public PlayPopupOpener popups;
    private void Awake()
    {
        if (Instance!=null&&Instance!=this)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        popups=GetComponent<PlayPopupOpener>();
    }

    public void ForwardButton()
    {
        if (starScore>=1)
        {
            popups.starsObtained = starScore;
            popups.popupPrefab = levelComplete;
        }else if (starScore == 0)
        {
            popups.starsObtained = starScore;
            popups.popupPrefab = levelUnComplete;
        }
    }
}
