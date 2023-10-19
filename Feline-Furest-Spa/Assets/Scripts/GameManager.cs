using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField] bool isOnShowerStep = true;
    [SerializeField] bool isOnGroomStep = false;

    [SerializeField] GameObject waterBucket;
    [SerializeField] GameObject shampooBottle;
    [SerializeField] GameObject towel;

    //[SerializeField] GameObject backButton;
    //[SerializeField] GameObject nextButton;

    // Start is called before the first frame update
    void Start()
    {
        towel.SetActive(false);
        //backButton.GetComponent<Button>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToNextStep()
    {

        if (isOnShowerStep)
        {
            isOnShowerStep = false;
            isOnGroomStep = true;
            waterBucket.SetActive(false);
            shampooBottle.SetActive(false);
            towel.SetActive(true);
            //backButton.enabled = true;
        }
        //logic for any further step switches goes here
    }

    public void GoBackToLastStep()
    {
        if (isOnGroomStep)
        {
            isOnShowerStep = true;
            isOnGroomStep = false;
            waterBucket.SetActive(true);
            shampooBottle.SetActive(true);
            towel.SetActive(false);
        }
    }

    //public void SwitchTools()
    //{
    //    if (isOnShowerStep)
    //    {
    //        isOnShowerStep = false;
    //        waterBucket.SetActive(false);
    //        shampooBottle.SetActive(false);
    //        towel.SetActive(true);
    //        //backButton.enabled = true;
    //    }
    //    else
    //    {
    //        isOnShowerStep = true;
    //        waterBucket.SetActive(true);
    //        shampooBottle.SetActive(true);
    //        towel.SetActive(false);
    //    }
    //}
}
