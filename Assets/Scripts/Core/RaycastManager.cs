using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastManager : MonoBehaviour
{
    [SerializeField]
    private Transform rayOriginObj;
    [SerializeField]
    private LayerMask mask;

    private Ray ray = new Ray();
    private RaycastHit hitPoint = new RaycastHit();
    

    private void Update ()
    {
        FireRay();
    }

    private void FireRay ()
    {
        ray.origin = rayOriginObj.transform.position;
        ray.direction = rayOriginObj.transform.forward;

        if (Physics.Raycast(ray.origin, ray.direction, out hitPoint, Mathf.Infinity, mask))
        {
            if (ARRulerEventManager.inst.OnRaycastHit != null)
            {
                ARRulerEventManager.inst.OnRaycastHit.Invoke(hitPoint);
            }
        }
        else
        {
            if (ARRulerEventManager.inst.OnRayDetectNothing != null)
            {
                ARRulerEventManager.inst.OnRayDetectNothing.Invoke();
            }
        }
    }
}