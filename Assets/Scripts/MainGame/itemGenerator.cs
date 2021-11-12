using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemGenerator : MonoBehaviour
{
    private float speed = 1f;
    public GameObject[] items = new GameObject[4];
    int nextItemIndex;
    GameObject nextItem;
    GameObject clonedItem;
    Rigidbody2D rb;

    private void Start()
    {
        generateItem();
    }

    private void FixedUpdate()
    {
        if (clonedItem != null)
        {
            rb.velocity = new Vector2(-10*Time.deltaTime*speed, 0f);
        }
    }
    void generateItem()
    {
        nextItemIndex = Random.Range(0, items.Length);
        nextItem = items[nextItemIndex];
        clonedItem = Instantiate(nextItem, transform.position, Quaternion.identity);
        rb = clonedItem.GetComponent<Rigidbody2D>();
    }
}
