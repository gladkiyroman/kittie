using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnItem : MonoBehaviour
{

    private void Start()
    {
        if (itemGenerator.sp != null)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = itemGenerator.sp;

        }
    }
}
