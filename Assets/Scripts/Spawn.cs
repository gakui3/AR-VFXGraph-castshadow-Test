using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class Spawn : MonoBehaviour
{
    [SerializeField]
    GameObject ParticleobjectPrefab;

    [SerializeField]
    GameObject objectPrefab;

    public TrackableType type;

    ARRaycastManager raycastManager;
    List<ARRaycastHit> hitResults = new List<ARRaycastHit>();

    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (raycastManager.Raycast(Input.GetTouch(0).position, hitResults, TrackableType.All))
            {
                Instantiate(ParticleobjectPrefab, hitResults[0].pose.position, Quaternion.identity);
            }
        }
    }
}