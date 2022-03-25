using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARRulerEventManager : SingletonBehaviour<ARRulerEventManager>
{
    public Action<RaycastHit> OnRaycastHit;
    public Action OnRayDetectNothing;
    public Action OnTouchScreen;

    private void Start ()
    {
        OnRaycastHit += (value) => OnRayHitUpdate();
    }

    private void OnRayHitUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (OnTouchScreen != null)
            {
                OnTouchScreen.Invoke();
            }
        }
    }
}
