using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpindleController : MonoBehaviour
{
    public GameObject rightHandAnchor;
    public GameObject leftHandAnchor;

    private LineRenderer joinLineRenderer;

    private Vector3? pickedObjectInitialScale = null;
    private float? lineInitialMagnitude = null;

    void Start()
    {
        joinLineRenderer = GetComponent<LineRenderer>();
    }

    void DrawLine()
    {
        joinLineRenderer.enabled = true;
        Vector3 R = rightHandAnchor.transform.position;
        Vector3 L = leftHandAnchor.transform.position;
        joinLineRenderer.SetPosition(0, R);
        joinLineRenderer.SetPosition(1, L);
    }

    void RemoveLine()
    {
        joinLineRenderer.enabled = false;
    }

    float GetLineMagnitude()
    {
        Vector3 R = rightHandAnchor.transform.position;
        Vector3 L = leftHandAnchor.transform.position;
        return (R - L).magnitude;
    }

    public void OnScaleObjectEnter(GameObject pickedObject)
    {
        if (!pickedObjectInitialScale.HasValue)
        {
            pickedObjectInitialScale = pickedObject.transform.localScale;
            lineInitialMagnitude = GetLineMagnitude();
        }
        float lineMagnitude = GetLineMagnitude();
        float lineRatio = lineMagnitude / lineInitialMagnitude.Value;
        pickedObject.transform.localScale = pickedObjectInitialScale.Value * lineRatio;
        DrawLine();
    }

    public void OnScaleObjectExit()
    {
        pickedObjectInitialScale = null;
        lineInitialMagnitude = null;
        RemoveLine();
    }
}
