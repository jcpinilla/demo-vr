using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpindleController : MonoBehaviour
{
    public GameObject rightHandAnchor;
    public GameObject leftHandAnchor;
    public GameObject interactionSphere;

    private LineRenderer joinLineRenderer;

    void Start()
    {
        joinLineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        Vector3 R = rightHandAnchor.transform.position;
        Vector3 L = leftHandAnchor.transform.position;
        joinLineRenderer.SetPosition(0, R);
        joinLineRenderer.SetPosition(1, L);

        Vector3 M = 0.5f * (R + L);
        interactionSphere.transform.position = M;
    }
}
