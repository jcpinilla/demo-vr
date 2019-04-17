using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaysManagerController : MonoBehaviour
{
    public GameObject rightHandAnchor;
    public GameObject leftHandAnchor;
    public GameObject interactionSphere;

    private LineRenderer rightLineRenderer;
    private LineRenderer leftLineRenderer;
    private LineRenderer joinLineRenderer;

    void Start()
    {
        joinLineRenderer = GetComponent<LineRenderer>();
        rightLineRenderer = rightHandAnchor.GetComponent<LineRenderer>();
        leftLineRenderer = leftHandAnchor.GetComponent<LineRenderer>();
    }

    void Update()
    {
        //Debug.Log("Left: " + leftLineRenderer.GetPosition(0) + ", " + leftLineRenderer.GetPosition(1));
        //Debug.Log("Right: " + rightLineRenderer.GetPosition(0) + ", " + rightLineRenderer.GetPosition(1));

        // L1
        Vector3 A = leftLineRenderer.GetPosition(0);
        //Vector3 A = new Vector3(0, 2, -1);
        float a1 = A.x;
        float a2 = A.y;
        float a3 = A.z;

        Vector3 u = leftLineRenderer.GetPosition(1) - A;
        //Vector3 u = new Vector3(1, 1, 2);
        float u1 = u.x;
        float u2 = u.y;
        float u3 = u.z;

        // L2
        Vector3 B = rightLineRenderer.GetPosition(0);
        //Vector3 B = new Vector3(1, 0, -1);
        float b1 = B.x;
        float b2 = B.y;
        float b3 = B.z;

        Vector3 v = rightLineRenderer.GetPosition(1) - B;
        //Vector3 v = new Vector3(1, 1, 3);
        float v1 = v.x;
        float v2 = v.y;
        float v3 = v.z;

        // Eq 1
        float e = u1*v1 + u2*v2 + u3*v3;
        float f = -(Mathf.Pow(u1, 2) + Mathf.Pow(u2, 2) + Mathf.Pow(u3, 2));
        float g = u1*a1 + u2*a1 + u3*a3 - u1*b1 - u2*b2 - u3*b3;

        // Eq 2
        float l = Mathf.Pow(v1, 2) + Mathf.Pow(v2, 2) + Mathf.Pow(v3, 2);
        float k = -(v1*u1 + v2*u2 + v3*u3);
        float m = v1*a1 + v2*a2 + v3*a3 - v1*b1 - v2*b2 - v3*b3;

        float s = (f*m - k*g) / (f*l - k*e);
        float t = (g - e*s) / f;

        Vector3 P = new Vector3(a1 + t*u1, a2 + t*u2, a3 + t*u3);
        Vector3 Q = new Vector3(b1 + s*v1, b2 + s*v2, b3 + s*v3);

        joinLineRenderer.SetPosition(0, P);
        joinLineRenderer.SetPosition(1, Q);
        Debug.Log("P=" + P + ", Q=" + Q);

        //Vector3 PIP = new Vector3((P.x + Q.x) / 2f, (P.y + Q.y) / 2f, (P.z + Q.z) / 2f);

        //interactionSphere.transform.position = PIP;

        Vector3 PQ = Q - P;
        //Debug.Log("|PQ|=" + (PQ.magnitude));
    }
}
