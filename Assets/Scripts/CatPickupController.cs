using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPickupController : MonoBehaviour
{

    [SerializeField] private GameObject Target;
    [SerializeField] private float PickupRange;

    [SerializeField] private bool hasCat => PickedUpCat != null;
    [SerializeField] private GameObject PickedUpCat = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F) && !hasCat)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(Target.transform.position, PickupRange);
            foreach(Collider2D col in colliders)
            {
                if (col.CompareTag("Cat"))
                {
                    PickedUpCat = col.gameObject;
                    Debug.Log("cat found, picking up cat");
                }
            }
        }

        if (hasCat)
        {
            PickedUpCat.transform.position = Target.transform.position;
            if (Input.GetKeyDown(KeyCode.E))
            {
                PickedUpCat = null;
            }
        }

        
    }

    public void SetTargetPos(Vector3 pos)
    {
        Target.transform.localPosition = pos;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(Target.transform.position, PickupRange);
    }
}
