using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSprite : MonoBehaviour
{
    private SpriteRenderer catSprite;
    public List<Sprite> cat1 = new List<Sprite>();
    public List<Sprite> cat2 = new List<Sprite>();
    public List<Sprite> cat3 = new List<Sprite>();
    public List<Sprite> cat4 = new List<Sprite>();

    private List<Sprite> currentCat = new List<Sprite>();

    private void Start()
    {
        int randomNumber = Random.Range(1, 5);
        SetRandomCat(randomNumber);

        catSprite = GetComponent<SpriteRenderer>();
    }

    public void UpdateCatSprite(int angle)
    {
        if (angle >= 0 && angle < 90)
        {
            SetSpriteAtIndex(0);
        }
        else if (angle >= 90 && angle < 180)
        {
            SetSpriteAtIndex(2);
        }
        else if (angle >= 180 && angle < 270)
        {
            SetSpriteAtIndex(3);
        }
        else if (angle >= 270 && angle < 360)
        {
            SetSpriteAtIndex(1);
        }
    }
    private void SetSpriteAtIndex(int index)
    {
        if (currentCat.Count > 0 && index >= 0 && index < currentCat.Count)
        {
            catSprite.sprite = currentCat[index];
        }
    }
    public void SetRandomCat(int randomNumber)
    {
        switch (randomNumber)
        {
            case 1:
                currentCat = cat1;
                break;
            case 2:
                currentCat = cat2;
                break;
            case 3:
                currentCat = cat3;
                break;
            case 4:
                currentCat = cat4;
                break;
            default:
                Debug.LogWarning("Invalid random number.");
                break;
        }
    }
}
