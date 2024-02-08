using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatCheck : MonoBehaviour
{
    public bool inRange = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cat"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Cat"))
        {
            inRange = false;
        }
    }

    public GameObject PickUpCat()
    {
        return GameObject.FindGameObjectWithTag("Cat");
    }
}