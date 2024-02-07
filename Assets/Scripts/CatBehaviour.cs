using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBehaviour : MonoBehaviour
{
    public CatSprite spriteScript;
    public Transform player;
    public float speed = 5f;
    public float distanceToScare = 10f;

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < distanceToScare)
        {
            Vector3 runDirection = transform.position - player.position;
            runDirection.Normalize();

            transform.Translate(runDirection * speed * Time.deltaTime);
        }
        spriteScript.UpdateCatSprite(CalculateAngle());
        Debug.Log(CalculateAngle());
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
}
