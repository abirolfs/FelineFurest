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

    [SerializeField] bool isWashDone = false;
    [SerializeField] bool isShampooDone = false;
    public bool isStep1Done = false;

    [SerializeField] bool isTowelDone = false;
    [SerializeField] bool isGroomDone = false;
    public bool isStep2Done = false;

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

    public void SetProgress(string tool, bool progress)
    {
        if(tool == "WaterBucket")
        {
            isWashDone = progress;
        }
        else if (tool == "ShampooBottle")
        {
            isShampooDone = progress;
        }
        else if (tool == "Towel")
        {
            isTowelDone = progress;
        }
    }

    public bool CheckIfCanProceed(string tool)
    {
        if (tool == "WaterBucket")
        {
            return true;
        }
        else if (tool == "ShampooBottle" && isWashDone)
        {
            return true;
        }
        //IMPLEMENT LOGIC FOR STEP 2 HERE
        else
        {
            return false;
        }
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
