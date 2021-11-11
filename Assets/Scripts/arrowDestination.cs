using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowDestination : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "arrow")
        {
            Debug.Log("Ho!");
            
        }
    }
}
