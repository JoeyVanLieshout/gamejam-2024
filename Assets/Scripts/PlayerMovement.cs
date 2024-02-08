using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    private CatPickupController pickup;

    [SerializeField] private EDirection direction;
    Vector2 directionTarget;
    [SerializeField] float targetDistance;
    private Animator playerAnimator;
    public EDirection Direction
    {
        get { return direction; }
        set
        {
            if(direction != value)
            {
                direction = value;
                pickup.SetTargetPos(directionTarget * targetDistance);
            }
        }
    }

    public enum EDirection
    {
        North,
        East,
        South,
        West
    }
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pickup = GetComponent<CatPickupController>();
        playerAnimator = GetComponent<Animator>();
        
    }

    void Update()
    {
       Vector2 movementDirRaw = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
       movementDirection = movementDirRaw.normalized;

       if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
       {
        rb.velocity = new Vector2 (0, 0);
       }

        (float, float) moveDir = (movementDirRaw.x, movementDirRaw.y);
        directionTarget = movementDirRaw;

        switch (moveDir)
        {
            case (0f, 1f):
                Direction = EDirection.North;
                playerAnimator.SetBool("WalkBack", true);
                playerAnimator.SetBool("WalkStraight", false);
                playerAnimator.SetBool("WalkLeft", false);
                playerAnimator.SetBool("WalkRight", false);
                break;
            case (1f, 0f):
                Direction = EDirection.East;
                playerAnimator.SetBool("WalkRight", true);
                playerAnimator.SetBool("WalkStraight", false);
                playerAnimator.SetBool("WalkLeft", false);
                playerAnimator.SetBool("WalkBack", false);
                break;
            case (0f, -1f):
                Direction = EDirection.South;
                playerAnimator.SetBool("WalkLeft", false);
                playerAnimator.SetBool("WalkStraight", true);
                playerAnimator.SetBool("WalkRight", false);
                playerAnimator.SetBool("WalkBack", false);
                break;
            case (-1f, 0f):
                Direction = EDirection.West;
                playerAnimator.SetBool("WalkStraight", false);
                playerAnimator.SetBool("WalkLeft", true);
                playerAnimator.SetBool("WalkRight", false);
                playerAnimator.SetBool("WalkBack", false);
                break;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = movementDirection * movementSpeed;        
    }
  
}
