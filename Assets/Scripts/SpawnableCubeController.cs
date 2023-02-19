using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableCubeController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    //Destroy(gameObject);
    //    if (other.gameObject.CompareTag("Spawnable")) { Destroy(other.gameObject); }
    //}

    private void OnTriggerStay(Collider other)
    {
        //Destroy(gameObject);
        if (other.gameObject.CompareTag("Spawnable")) { Destroy(other.gameObject); }


    }
}
