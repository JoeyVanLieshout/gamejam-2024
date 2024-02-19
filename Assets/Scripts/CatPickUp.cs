using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            if (Input.GetMouseButtonDown(1))
            {
                currentCat.GetComponent<CatBehaviour>().pickedUp = false;
                currentCat.GetComponent<CircleCollider2D>().enabled = true;
                currentCat = null;
                hasCat = false;
            }
        }
        if (currentCat != null)
        {
            Vector3 newPosition = transform.position;
            newPosition.y -= 0.7f;

            currentCat.transform.position = newPosition;
            CircleCollider2D catHitBox = currentCat.GetComponent<CircleCollider2D>();
            CatBehaviour catBehaviourScript = currentCat.GetComponent<CatBehaviour>();
            if (catBehaviourScript != null)
            {
                catHitBox.enabled = false;
                catBehaviourScript.pickedUp = true;
            }
        }
    }
   
}
