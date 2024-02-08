using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movesimple : MonoBehaviour
{

    [SerializeField] private float movementSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementDirRaw = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movementDirection = movementDirRaw.normalized;

        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            rb.velocity = new Vector2 (0, 0);
        }
    }
}
