using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    [SerializeField] int toolUseCount = 0;

    [SerializeField] bool isPickedUp = false;
    //[SerializeField] bool isInSquare = true;

    [SerializeField] float zPosition = -1.5f;

    [SerializeField] GameObject toolSquare;
    [SerializeField] GameObject cat;
    [SerializeField] BoxCollider2D toolCollider;
    [SerializeField] BoxCollider2D squareCollider;
    [SerializeField] BoxCollider2D catCollider;

    //Bounds toolBounds;
    //Bounds squareBounds;

    // Start is called before the first frame update
    void Start()
    {
        toolCollider = this.GetComponent<BoxCollider2D>();
        squareCollider = toolSquare.GetComponent<BoxCollider2D>();
        cat = GameObject.FindGameObjectWithTag("Cat");
        catCollider = cat.GetComponent<BoxCollider2D>();

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
        else
        {

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
                toolUseCount++;
            }

        }
    }
}
