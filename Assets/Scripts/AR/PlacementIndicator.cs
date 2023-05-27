using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour
{


    [SerializeField]
    private GameObject m_ObjectToPlace;
    private GameObject m_ObjectPlaced;
    private ARRaycastManager m_ARRaycastManager;
    private GameObject m_PlacementIndicator;
    private Vector2 m_ScreenCenterPosition = new Vector2(0.5f, 0.5f);
    private Pose m_CurrentPlacementIndicatorPose;
    private bool m_PlaneDetected;
   

    private void Awake()
    {
        m_ARRaycastManager = FindObjectOfType<ARRaycastManager>();
        m_PlacementIndicator = gameObject.transform.GetChild(0).gameObject;
    }

    void Start()
    {
        m_PlacementIndicator.SetActive(false);
        m_ObjectPlaced = null;
        EventManager.placeObject += AnchorObject;
        EventManager.reanchor += Reanchor;
    }


    private void OnDestroy()
    {
        EventManager.placeObject -= AnchorObject;
        EventManager.reanchor -= Reanchor;
    }
    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicatorPosition();
    }

    private void UpdatePlacementPose()
    {

        if (m_ObjectPlaced == null)
        {
            Vector3 centerCameraWorldPosition = Camera.main.ViewportToScreenPoint(m_ScreenCenterPosition);
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            m_ARRaycastManager.Raycast(centerCameraWorldPosition, hits, TrackableType.Planes);

            if (hits.Count > 0)
            {
                m_PlaneDetected = true;
                m_CurrentPlacementIndicatorPose = hits[0].pose;
                Vector3 camerDirection = Camera.main.transform.forward;
                camerDirection.y = 0;
                m_CurrentPlacementIndicatorPose.rotation = Quaternion.LookRotation(camerDirection.normalized);
            }
            else
            {
                m_PlaneDetected = false;
            }
        }
        else
        {
            m_PlaneDetected= false;
        }
       
    }

    public void AnchorObject()
    {
        if (m_PlaneDetected)
        {
           m_ObjectPlaced =  Instantiate(m_ObjectToPlace, m_CurrentPlacementIndicatorPose.position,
              m_CurrentPlacementIndicatorPose.rotation);
        }
    }

    public void Reanchor()
    {
        if (m_ObjectPlaced!= null && !m_PlaneDetected)
        {
            Destroy(m_ObjectPlaced);
            m_ObjectPlaced = null;
        }
    }
    
    private void UpdatePlacementIndicatorPosition()
    {
        if (m_PlaneDetected)
        {
            m_PlacementIndicator.SetActive(true);
            m_PlacementIndicator.transform.SetPositionAndRotation(m_CurrentPlacementIndicatorPose.position, m_CurrentPlacementIndicatorPose.rotation);
        }
        else
        {
            m_PlacementIndicator.SetActive(false);
        }
    }


}
