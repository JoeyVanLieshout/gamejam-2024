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
        if (Input.GetMouseButtonDown(0) && !hasCat && catCheck.inRange)
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
            Vector3 newPosition = transform.position;
            newPosition.y -= 0.7f;

            currentCat.transform.position = newPosition;

            CatBehaviour catBehaviourScript = currentCat.GetComponent<CatBehaviour>();
            if (catBehaviourScript != null)
            {
                catBehaviourScript.pickedUp = true;
            }
        }
    }
}
