using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARSessionOrigin))]
public class RulerObjectManager : MonoBehaviour
{
    [SerializeField]
    private GameObject rulerPointObjPrefab;
    [SerializeField]
    private GameObject rulerDistObjPrefab;

    [SerializeField]
    private List<GameObject> rulerPoints = new List<GameObject>();
    [SerializeField]
    private RulerDistance rulerDist = null;

    private void Start ()
    {
        ARRulerEventManager.inst.OnRaycastHit += SetLatestPoint;
        ARRulerEventManager.inst.OnRayDetectNothing += DeactiveLatestPoint;
        ARRulerEventManager.inst.OnTouchScreen += CreateNewPoint;

        CreateNewPoint();
    }

    private void CreateNewPoint ()
    {
        GameObject newPoint = Instantiate(rulerPointObjPrefab.gameObject);
        rulerPoints.Add(newPoint);
        newPoint.transform.parent = transform;

        if (rulerPoints.Count == 4)
        {
            Destroy(rulerDist.gameObject);
            rulerDist = null;
            Destroy(rulerPoints[0]);
            rulerPoints.RemoveAt(0);
            Destroy(rulerPoints[0]);
            rulerPoints.RemoveAt(0);
        }

        if (rulerPoints.Count == 2)
        {
            rulerDist = Instantiate(rulerDistObjPrefab).GetComponent<RulerDistance>();
            rulerDist.SetPointObjs(rulerPoints[0], rulerPoints[1]);
        }
    }

    private void SetLatestPoint (RaycastHit hitInfo)
    {
        rulerPoints[rulerPoints.Count - 1].SetActive(true);
        rulerPoints[rulerPoints.Count - 1].transform.position = hitInfo.point;

        if (rulerDist != null)
        {
            rulerDist.gameObject.SetActive(true);
            rulerDist.UpdateLine();
        }
    }

    private void DeactiveLatestPoint ()
    {
        rulerPoints[rulerPoints.Count - 1].SetActive(false);
        if(rulerDist != null)
        {
            rulerDist.gameObject.SetActive(false);
        }
    }
}
