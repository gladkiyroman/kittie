using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame : MonoBehaviour
{
    public float speed = 1f;
    public GameObject[] arrows = new GameObject[4];
    GameObject selectedArrow;
    public static GameObject spawned;

    // Start is called before the first frame update
    void Start()
    {
        spawnArrow();
    }

    // Update is called once per frame
    void Update()
    {
        moveArrow();
    }

    void spawnArrow()
    {
        int arrowIndex = Random.Range(0, arrows.Length);
        selectedArrow = arrows[arrowIndex];
        spawned = Instantiate(selectedArrow, GameObject.FindGameObjectWithTag("arrowSpawner").transform.position, Quaternion.identity);
    }
    void moveArrow()
    {
        spawned.transform.position = Vector3.MoveTowards(spawned.transform.position, GameObject.FindGameObjectWithTag("arrowDestination").transform.position, speed * Time.deltaTime);
    }

}
