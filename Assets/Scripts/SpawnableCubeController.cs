using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableCubeController : MonoBehaviour
{
    //TODO boolean onko esine valittu?
    //valittu materiaali
    //ei valittu materiaali
    //camera ar camera
    //tähän scriptiin mitä tapahtuu kun klikataan(jo olemassa olevaa objektia)
    //PlaceObjects vaan ohittaa jos painetaan kohdasta missä on jo esine
    //tai sitten PlaceObjects laittaa aktiiviseksi myös...

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //JOS haluattaisiin tuhota törmäävät cubet.. ei käytössä nyt
    //private void OnTriggerEnter(Collider other)
    //{
    //    //Destroy(gameObject);
    //   //if (other.gameObject.CompareTag("Spawnable")) { Destroy(other.gameObject); }
    //}

    //private void OnTriggerStay(Collider other)
    //{
    //    //Destroy(gameObject);
    //    if (other.gameObject.CompareTag("Spawnable")) { Destroy(other.gameObject); }


    //}
}
