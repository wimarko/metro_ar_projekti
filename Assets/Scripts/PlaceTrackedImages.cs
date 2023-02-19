using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation; //UNityn xr toolit
using UnityEngine.XR.ARSubsystems;  // xr tooleja


[RequireComponent(typeof(ARTrackedImageManager))]
public class PlaceTrackedImages : MonoBehaviour
{

    private ARTrackedImageManager trackedImageManager;

    public GameObject[] ArPrefabs;
    private readonly Dictionary<string, GameObject> instantiatedPrefabs = new Dictionary<string, GameObject>(); //readonly toimii myös, annetaan olla

    private void Awake()
    {
        trackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }
    
    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        //kaikki loopit kattoo eventArgsin

        //jos lisätty uusi kuva, haetaan kuvan nimi
        foreach (var trackedImage in eventArgs.added) { //kaikista tunnsitetuista kuvista  
            var imageName = trackedImage.referenceImage.name;

            //verrataan uuden kuvan nimeä prefabin nimeen, jos matchaa, mutta ei ole jo insatntioitu, luodaan objekti
            foreach(var curPrefab in ArPrefabs)
            {
                if(string.Compare(curPrefab.name, imageName, System.StringComparison.OrdinalIgnoreCase) == 0 
                    && !instantiatedPrefabs.ContainsKey(imageName)) { //katotaAn onko nimellä, ei luoda samaa uudestaan

                    //luodaan jos ei ole
                    var newPrefab = Instantiate(curPrefab, trackedImage.transform);
                    instantiatedPrefabs[imageName] = newPrefab;
                }
            }
        }
        //jos olemassaoleviin kuviin tulee muutoksia, haetaan jo instantioitu prefabi, aktivoidaan tai deaktivoidaan sen mukaan..
        foreach(var trackedImage in eventArgs.updated)
        {
            instantiatedPrefabs[trackedImage.referenceImage.name].
                SetActive(trackedImage.trackingState == TrackingState.Tracking); //asetataan sen mukaan onko aktiivinen tms..
        }
        //jos softa päättelee ,että objekti katosi kauas,eikä tule takaisin enää, tuhotaan se
        foreach(var trackedImage in eventArgs.removed)
        {
            Destroy(instantiatedPrefabs[trackedImage.referenceImage.name]);
            instantiatedPrefabs.Remove(trackedImage.referenceImage.name);   //poistetaan se myös listalta
        }
    }
}
