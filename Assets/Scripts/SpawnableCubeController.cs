using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableCubeController : MonoBehaviour
{
    //TODO boolean onko esine valittu?
    //valittu materiaali
    //ei valittu materiaali
    //camera ar camera
    //t�h�n scriptiin mit� tapahtuu kun klikataan(jo olemassa olevaa objektia)
    //PlaceObjects vaan ohittaa jos painetaan kohdasta miss� on jo esine
    //tai sitten PlaceObjects laittaa aktiiviseksi my�s...

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //JOS haluattaisiin tuhota t�rm��v�t cubet.. ei k�yt�ss� nyt
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
