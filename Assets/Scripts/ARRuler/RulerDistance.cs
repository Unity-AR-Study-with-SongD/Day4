using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RulerDistance : MonoBehaviour
{
    [SerializeField]
    private LineRenderer lineRenderer;
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private Text distText;

    private GameObject startObj;
    private GameObject endObj;

    public void SetPointObjs(GameObject startP, GameObject endP)
    {
        startObj = startP;
        endObj = endP;
    }


    public void UpdateLine()
    {
        Vector3 startP = startObj.transform.position;
        Vector3 endP = endObj.transform.position;

        canvas.transform.LookAt(Camera.main.transform);

        lineRenderer.SetPosition(0, startP);
        lineRenderer.SetPosition(1, endP);

        canvas.transform.position = Vector3.Lerp(startP, endP, 0.5f);
        canvas.transform.position += Vector3.up * 0.1f;

        float dist = Vector3.Distance(startP, endP);
        distText.text = string.Format("{0:0.00}m", dist);
    }
}
