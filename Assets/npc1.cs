using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc1 : MonoBehaviour
{


    public GameObject enterbtn2;

    //private GameObject toDestroy;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
       // Instantiate(enterbtn2,
        //    new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
      //  Destroy(enterbtn2);
    }

}
