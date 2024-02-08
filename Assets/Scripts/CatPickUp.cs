using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPickUp : MonoBehaviour
{
    GameObject currentCat = null;
    bool hasCat = false;
    public CatCheck catCheck;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !hasCat && catCheck.inRange)
        {
            currentCat = catCheck.PickUpCat();
            hasCat = true;
        }

        if (hasCat)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                currentCat.GetComponent<CatBehaviour>().pickedUp = false;
                currentCat = null;
                hasCat = false;
            }
        }
        if (currentCat != null)
        {
            currentCat.transform.position = transform.position;
            currentCat.GetComponent<CatBehaviour>().pickedUp = true;
        }
    }
}
