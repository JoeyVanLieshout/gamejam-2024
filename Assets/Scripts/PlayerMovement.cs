using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();        
    }

    void Update()
    {
       movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;      

       if(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
       {
        rb.velocity = new Vector2 (0, 0);
       }      
    }

    void FixedUpdate()
    {
        rb.velocity = movementDirection * movementSpeed;        
    }
  
}
