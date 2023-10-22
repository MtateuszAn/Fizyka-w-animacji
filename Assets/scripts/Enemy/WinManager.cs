using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinManager : MonoBehaviour
{
    [SerializeField] Canvas WinText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //wykonuje sie jezeli ilosc obiektow do zniszczenia jest rowna 0
        if(gameObject.transform.childCount == 0)
        {
            WinText.gameObject.SetActive(true);
        }
    }
}
