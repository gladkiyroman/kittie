using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemGenerator : MonoBehaviour
{
    public static float speed = 20f;
    public GameObject[] items = new GameObject[4];
    int nextItemIndex;
    GameObject nextItem;
    GameObject clonedItem;

    public static Sprite sp;

    Rigidbody2D rb;

    private void Start()
    {
        generateItem();
        locateItem();
        sp = clonedItem.GetComponent<SpriteRenderer>().sprite;
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


    void locateItem()
    {
        GameObject.FindGameObjectWithTag(clonedItem.name).GetComponent<npc1>().enabled = true;
        GameObject.FindGameObjectWithTag(clonedItem.name).GetComponent<Npc1Wrong>().enabled = false;

        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].name + "(Clone)" != clonedItem.name)
            {
                GameObject.FindGameObjectWithTag(items[i].name + "(Clone)").GetComponent<npc1>().enabled = false;
                GameObject.FindGameObjectWithTag(items[i].name + "(Clone)").GetComponent<Npc1Wrong>().enabled = true;
            }
            
            
        }
    }
}
