using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tool : MonoBehaviour
{
    [SerializeField] int toolUseCount = 0;

    [SerializeField] bool isPickedUp = false;

    [SerializeField] float zPosition = -1.5f;

    [SerializeField] GameObject toolSquare;
    [SerializeField] GameObject cat;
    [SerializeField] BoxCollider2D toolCollider;
    [SerializeField] BoxCollider2D squareCollider;
    [SerializeField] BoxCollider2D catCollider;

    [SerializeField] TextMeshProUGUI progressText;
    [SerializeField] TextMeshProUGUI currStepCompleteText;

    [SerializeField] GameManager gameManager;

    //Bounds toolBounds;
    //Bounds squareBounds;

    // Start is called before the first frame update
    void Start()
    {
        toolCollider = this.GetComponent<BoxCollider2D>();
        squareCollider = toolSquare.GetComponent<BoxCollider2D>();
        cat = GameObject.FindGameObjectWithTag("Cat");
        catCollider = cat.GetComponent<BoxCollider2D>();

        currStepCompleteText.enabled = false;

        //toolBounds = toolCollider.bounds;
        //toolBounds.extents += 10;
    }

    // Update is called once per frame
    void Update()
    {

        if (isPickedUp == true)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, zPosition);
        }

    }

    private void OnMouseDown()
    {

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, zPosition);

        if (isPickedUp == true && squareCollider.bounds.Contains(new Vector3(mousePosition.x, mousePosition.y, toolSquare.transform.position.z)))
        {
            Debug.Log("Mouse intersecting Tool Square!");
            transform.position = new Vector3(toolSquare.transform.position.x, toolSquare.transform.position.y, zPosition);
            isPickedUp = false;
        }
        else if (isPickedUp == false)
        {
            isPickedUp = true;
        }
        //logic for the tool being clicked outside of toolsquare - AKA actually using the tool
        else
        {

            if (catCollider.bounds.Contains(new Vector3(mousePosition.x, mousePosition.y, cat.transform.position.z)))
            {
                Debug.Log("Used tool on cat!");
                if (gameManager.CheckIfCanProceed(this.tag))
                {
                    toolUseCount++;
                }
                if (toolUseCount == 5)
                {
                    progressText.text = "100% Complete";
                    if (this.tag == "WaterBucket")
                    {
                        gameManager.SetProgress("WaterBucket", true);
                    }
                    else if (this.tag == "ShampooBottle")
                    {
                        gameManager.SetProgress("ShampooBottle", true);
                        StartCoroutine(ShowAndHideText(currStepCompleteText, 3.0f));
                    }
                    else if (this.tag == "Towel")
                    {
                        gameManager.SetProgress("Towel", true);
                    }
                    else if (this.tag == "Flower")
                    {
                        gameManager.SetProgress("Flower", true);
                        StartCoroutine(ShowAndHideText(currStepCompleteText, 3.0f));
                        //activate game finished text here
                    }
                }
            }

        }
    }

    IEnumerator ShowAndHideText(TextMeshProUGUI text, float time)
    {
        text.enabled = true;
        yield return new WaitForSeconds(time);
        text.enabled = false;
    }


}
