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

    [SerializeField] TextMeshProUGUI tool1Text;
    [SerializeField] TextMeshProUGUI tool2Text;

    [SerializeField] TextMeshProUGUI washProgressText;
    [SerializeField] GameObject washProgressBar;
    [SerializeField] GameObject washGreenBar;
    [SerializeField] TextMeshProUGUI shampooProgressText;
    [SerializeField] GameObject shampooProgressBar;
    [SerializeField] GameObject shampooGreenBar;
    [SerializeField] TextMeshProUGUI towelProgressText;
    [SerializeField] GameObject towelProgressBar;
    [SerializeField] GameObject towelGreenBar;
    [SerializeField] TextMeshProUGUI groomProgressText;
    [SerializeField] GameObject groomProgressBar;
    [SerializeField] GameObject groomGreenBar;

    // Start is called before the first frame update
    void Start()
    {
        towel.SetActive(false);
        flower.SetActive(false);

        towelProgressText.enabled = false;
        groomProgressText.enabled = false;

        towelProgressBar.SetActive(false);
        towelGreenBar.SetActive(false);
        groomProgressBar.SetActive(false);
        groomGreenBar.SetActive(false);
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

            washProgressBar.SetActive(false);
            washGreenBar.SetActive(false);
            shampooProgressBar.SetActive(false);
            shampooGreenBar.SetActive(false);

            towelProgressBar.SetActive(true);
            towelGreenBar.SetActive(true);
            groomProgressBar.SetActive(true);
            groomGreenBar.SetActive(true);

        }
        
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

            washProgressBar.SetActive(true);
            washGreenBar.SetActive(true);
            shampooProgressBar.SetActive(true);
            shampooGreenBar.SetActive(true);

            towelProgressBar.SetActive(false);
            towelGreenBar.SetActive(false);
            groomProgressBar.SetActive(false);
            groomGreenBar.SetActive(false);

        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }

  
}
