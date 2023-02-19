using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch; 
//nimet‰‰n tarvittava lyhyemm‰ksi

[RequireComponent
    (requiredComponent:typeof(ARRaycastManager),
    requiredComponent2:typeof(ARPlaneManager))
    ]
public class PlaceObject : MonoBehaviour
{

    [SerializeField] GameObject prefab;

    private ARRaycastManager aRRaycastManager;
    private ARPlaneManager aRPlaneManager;

    private List<ARRaycastHit> aHitList = new List<ARRaycastHit>();
   
   private void Awake()
    {
        aRRaycastManager= GetComponent<ARRaycastManager>();

        aRPlaneManager = GetComponent<ARPlaneManager>();
    }

    private void OnEnable()
    {
        EnhancedTouch.TouchSimulation.Enable();
        EnhancedTouch.EnhancedTouchSupport.Enable();

        EnhancedTouch.Touch.onFingerDown += FingerDown;
    }

    private void OnDisable()
    {
        EnhancedTouch.TouchSimulation.Disable();
        EnhancedTouch.EnhancedTouchSupport.Disable();

        EnhancedTouch.Touch.onFingerDown -= FingerDown;
    }

    private void FingerDown(EnhancedTouch.Finger finger)
    {
        if(finger.index != 0) { return; }

        if(aRRaycastManager.Raycast(finger.currentTouch.screenPosition,
                aHitList, TrackableType.PlaneWithinPolygon))
        {
            foreach(ARRaycastHit hit in aHitList) {
                Pose pose = hit.pose;
                GameObject obj =
                    Instantiate(prefab, pose.position, pose.rotation);
            }
        }
    }
}
