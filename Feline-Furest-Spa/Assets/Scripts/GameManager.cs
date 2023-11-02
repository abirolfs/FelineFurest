using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] bool isOnShowerStep = true;
    [SerializeField] bool isOnGroomStep = false;

    [SerializeField] GameObject waterBucket;
    [SerializeField] GameObject shampooBottle;
    [SerializeField] GameObject towel;
    [SerializeField] GameObject flower;

    [SerializeField] bool isWashDone = false;
    [SerializeField] bool isShampooDone = false;
    [SerializeField] bool isStep1Done = false;

    [SerializeField] bool isTowelDone = false;
    [SerializeField] bool isGroomDone = false;
    //public bool isStep2Done = false;

    [SerializeField] TextMeshProUGUI tool1Text;
    [SerializeField] TextMeshProUGUI tool2Text;

    [SerializeField] TextMeshProUGUI washProgressText;
    [SerializeField] TextMeshProUGUI shampooProgressText;
    [SerializeField] TextMeshProUGUI towelProgressText;
    [SerializeField] TextMeshProUGUI groomProgressText;

    //[SerializeField] GameObject backButton;
    //[SerializeField] GameObject nextButton;

    // Start is called before the first frame update
    void Start()
    {
        towel.SetActive(false);
        flower.SetActive(false);
        //backButton.GetComponent<Button>().enabled = false;

        towelProgressText.enabled = false;
        groomProgressText.enabled = false;
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
        else if (tool == "Flower")
        {
            isGroomDone = progress;
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
        else if (tool == "Towel" && isShampooDone)
        {
            return true;
        }
        else if (tool == "Flower" && isTowelDone)
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
            flower.SetActive(true);

            tool1Text.text = "Towel: ";
            tool2Text.text = "Groom: ";

            washProgressText.enabled = false;
            shampooProgressText.enabled = false;
            towelProgressText.enabled = true;
            groomProgressText.enabled = true;

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
            flower.SetActive(false);

            tool1Text.text = "Wash: ";
            tool2Text.text = "Shampoo: ";

            washProgressText.enabled = true;
            shampooProgressText.enabled = true;
            towelProgressText.enabled = false;
            groomProgressText.enabled = false;

        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
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
