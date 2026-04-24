using System.Collections.Generic;
using UnityEngine;

public class ChickenManager : MonoBehaviour
{
    private List<GameObject> Children = new List<GameObject>();
    private GOInteraction myGOI;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.tag == "Information")
            {
                Children.Add(child.gameObject);
                Debug.Log("Found Information child: " + child.name);
            }
        }

        Debug.Log("Total Information children found: " + Children.Count);

        myGOI = GetComponent<GOInteraction>();
        if (myGOI == null)
        {
            Debug.Log("No GOInteraction attached to this object.");
        }
        else
        {
            Debug.Log("GOInteraction found!");
        }

        // Default children to invisible.
        foreach (GameObject child in Children)
        {
            child.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (myGOI == null)
        {
            Debug.LogError("myGOI is NULL!");
            return;
        }

        if (myGOI.Interaction == true)
        {
            Debug.Log("Chicken clicked! Toggling " + Children.Count + " children");

            foreach (GameObject child in Children)
            {
                if (child.activeSelf)
                {
                    child.SetActive(false);
                    Debug.Log("Hid: " + child.name);
                }
                else
                {
                    child.SetActive(true);
                    Debug.Log("Showed: " + child.name);
                }
            }
            myGOI.Interaction = false;
        }
    }
}