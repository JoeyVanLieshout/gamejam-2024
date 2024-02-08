using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatDropoffPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cat"))
        {
            ScoreSystem.instance.AddScore(10); // get score from cat if u want different types to have different scores
            Destroy(collision.gameObject);
        }
    }
}
