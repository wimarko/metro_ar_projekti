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
    private GameObject selectedObj;

    private List<ARRaycastHit> aHitList = new List<ARRaycastHit>();
    private Vector2 touchPos = default;
    Camera camera;
   
   private void Awake()
    {
        aRRaycastManager= GetComponent<ARRaycastManager>();

        aRPlaneManager = GetComponent<ARPlaneManager>();
    }
    private void Start()
    {
        camera = Camera.main;
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

        //otetaan kai eka (sormen)osuma
        Touch touch = Input.GetTouch(0);
        touchPos = touch.position;

        if (touch.phase == TouchPhase.Began)
        {
            //ammutaan ray, ett‰ saadaan sijainti selville kameran suhteen
            Ray ray = camera.ScreenPointToRay(touchPos);
            RaycastHit hitObject;

            //osuma
            if (Physics.Raycast(ray, out hitObject)) {
                //jos osutaan mutta EI OLE "Spawnable"-tagilla oleva objekti ..
                if(!hitObject.collider.CompareTag("Spawnable"))
                {
                    // Niin sitten luodaan uusi objekti
                    if (aRRaycastManager.Raycast(finger.currentTouch.screenPosition,
               aHitList, TrackableType.PlaneWithinPolygon))
                    {
                        foreach (ARRaycastHit hit in aHitList)
                        {
                            Pose pose = hit.pose;
                            GameObject obj =
                                Instantiate(prefab, pose.position, pose.rotation);
                        }
                    }
                }
                //Jos osuttiin "Spawnable"-tagilliseen objektiin, niin sitten
                //voidaan siirrell‰ sit‰ kunhan sormi on ruudussa kiinni
            }
        }
        //koodia jostain foorumilta/googlesta/youtubesta
        //if(aRRaycastManager.Raycast(finger.currentTouch.screenPosition,
        //        aHitList, TrackableType.PlaneWithinPolygon))
        //{
        //    //foreach(ARRaycastHit hit in aHitList) {
        //    //    Pose pose = hit.pose;
        //    //    GameObject obj =
        //    //        Instantiate(prefab, pose.position, pose.rotation);
        //    //}
        //}
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPos = touch.position;
            if(touch.phase== TouchPhase.Began)
            {
                Ray ray =  camera.ScreenPointToRay(touchPos);
                RaycastHit hitObject;

                if (Physics.Raycast(ray, out hitObject)) { }
            }
    
        }
    }

    
}
