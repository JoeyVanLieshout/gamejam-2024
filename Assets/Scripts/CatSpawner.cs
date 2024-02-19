using System.Collections;
using UnityEngine;

public class CatSpawner : MonoBehaviour
{
    public GameObject catPrefab;

    private void Start()
    {
        StartCoroutine(SpawnCats());
    }

    IEnumerator SpawnCats()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            int randomValue = Random.Range(1, 40);

            if (randomValue == 1)
            {
                SpawnCat();
            }
        }
    }

    void SpawnCat()
    {
        GameObject newCat = Instantiate(catPrefab, transform.position, Quaternion.identity);
        newCat.transform.parent = transform;
    }
}

