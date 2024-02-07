using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBehaviour : MonoBehaviour
{
    public CatSprite spriteScript;
    public Transform player;

    bool catScared = false;
    bool canBeScared = true;

    private float scareCooldownTimer = 10f;
    private float scareChance;
    private float distanceToScare;
    private float startSpeed;
    private float maxSpeed;
    private float scaredSpeed;
    private Rigidbody2D catRigidbody;


    void Start()
    {
        catRigidbody = GetComponent<Rigidbody2D>();

        int randomNumber = Random.Range(1, 5);
        SetCatType(randomNumber);
        spriteScript.SetRandomCat(randomNumber);
    }

    void Update()
    {
        if (catScared)
        {
            CatScaredRun();
        }
        else
        {
            RunFromPlayer();
            spriteScript.UpdateCatSprite(CalculateAngle());
        }
        if (!canBeScared)
        {
            scareCooldownTimer -= Time.deltaTime;
            if (scareCooldownTimer <= 0f)
            {
                canBeScared = true;
                catScared = false;
            }
        }
    }


    public void RunFromPlayer()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < distanceToScare)
        {
            float distanceFactor = 1 - (distanceToPlayer / distanceToScare);

            float adjustedSpeed = startSpeed + (maxSpeed - startSpeed) * distanceFactor;

            Vector2 runDirection = (Vector2)transform.position - (Vector2)player.position;
            runDirection.Normalize();

            catRigidbody.AddForce(runDirection * adjustedSpeed);

            catRigidbody.velocity = Vector2.ClampMagnitude(catRigidbody.velocity, maxSpeed);
            if (distanceFactor > 0.9f && canBeScared)
            {
                if (ScareCheck())
                {
                    catScared = true;
                    canBeScared = false;
                }
                else
                {
                    canBeScared = false;
                }
            }
        }
        else
        {
            // Reset velocity to stop movement when not scared
            catRigidbody.velocity = Vector2.zero;
        }
    }
    public void CatScaredRun()
    {
        Vector2 runDirection = (Vector2)transform.position - (Vector2)player.position;
        runDirection.Normalize();

        runDirection *= -1;

        catRigidbody.velocity = runDirection * scaredSpeed;
    }

    public void SetCatType(int randomNumber)
    {
        switch (randomNumber)
        {
            case 1:
                distanceToScare = 5f;
                maxSpeed = 1.5f;
                startSpeed = 0.5f;
                scareChance = 0.1f;
                scaredSpeed = 3;

                break;
            case 2:
                distanceToScare = 4.5f;
                maxSpeed = 2.2f;
                startSpeed = 0.5f;
                scareChance = 2;
                scaredSpeed = 3;

                break;
            case 3:
                distanceToScare = 4f;
                maxSpeed = 2.8f;
                startSpeed = 0.5f;
                scareChance = 3;
                scaredSpeed = 3;

                break;
            case 4:
                distanceToScare = 3f;
                maxSpeed = 3.5f;
                startSpeed = 2f;
                scareChance = 5;
                scaredSpeed = 3;
                break;
            default:
                Debug.LogWarning("Invalid random number.");
                break;
        }
    }

    int CalculateAngle()
    {
        Vector2 point1 = new Vector2(transform.position.x, transform.position.y);
        Vector2 point2 = new Vector2(player.position.x, player.position.y);

        float angle = Mathf.Atan2(point2.y - point1.y, point2.x - point1.x) * Mathf.Rad2Deg;

        angle = (angle + 360f) % 360f;

        angle = (angle + 270f) % 360f;

        angle = (angle + 45f) % 360f;

        return Mathf.RoundToInt(angle);
    }
    bool ScareCheck()
    {
        /*        float probability = scareChance / 5f;

                float randomValue = Random.value;

                return randomValue <= probability;*/
        return true;
    }
}
