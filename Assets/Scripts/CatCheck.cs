using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatCheck : MonoBehaviour
{
    private GameObject currentCat = null;

    public bool inRange { get { return currentCat != null; } }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cat"))
        {
            currentCat = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Cat"))
        {
            currentCat = null;
        }
    }

    public GameObject PickUpCat()
    {
        return currentCat;
    }
}
