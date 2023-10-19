using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    [SerializeField] bool isPickedUp = false;
    [SerializeField] float zPosition = -1.5f;

    [SerializeField] GameObject toolSquare;
    [SerializeField] BoxCollider toolCollider;
    [SerializeField] BoxCollider squareCollider;
    Bounds toolBounds;
    Bounds squareBounds;

    // Start is called before the first frame update
    void Start()
    {
        toolCollider = this.GetComponent<BoxCollider>();
        squareCollider = toolSquare.GetComponent<BoxCollider>();

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

        if (isPickedUp == false)
        {
            isPickedUp = true;
        }
        //else if (isPickedUp = true && toolCollider.bounds.Intersects(squareCollider.bounds))
        //{
        //    Debug.Log("Tool intersecting Tool Square!");
        //    transform.position = new Vector3(toolSquare.transform.position.x, toolSquare.transform.position.y, zPosition);
        //    isPickedUp = false;
        //}
        else
        {
            //logic for the tool being picked up but not in bounds of tool square goes here
            isPickedUp = false;
        }
    }
}
