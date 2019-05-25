using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableController : MonoBehaviour
{
    const string targetTag = "Target";

    void OnTriggerEnter(Collider other)
    {
        GameObject gameObject = other.gameObject;
        if (gameObject.CompareTag(targetTag))
        {
            TargetController targetController = gameObject.GetComponent<TargetController>();
            targetController.OnTargetMatch();
        }
    }

    void OnTriggerExit(Collider other)
    {
        GameObject gameObject = other.gameObject;
        if (gameObject.CompareTag(targetTag))
        {
            TargetController targetController = gameObject.GetComponent<TargetController>();
            targetController.OnTargetUnmatch();
        }
    }
}
