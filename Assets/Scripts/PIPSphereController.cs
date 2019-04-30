using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIPSphereController : MonoBehaviour
{
    public Material PIPActive;
    public Material PIPInactive;

    private GameObject pickable;
    private Renderer renderer;

    void Start()
    {
        pickable = null;
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        bool one = OVRInput.Get(OVRInput.Button.One);
        bool three = OVRInput.Get(OVRInput.Button.Three);
        bool pickAction = one || three;
        if (pickAction && pickable != null)
        {
            AnchorToPickable();
        }
    }

    void AnchorToPickable()
    {
        pickable.transform.position = transform.position;
    }

    void ChangePipLook(bool active)
    {
        Material newMaterial = active ? PIPActive : PIPInactive;
        Material[] materials = renderer.materials;
        materials[0] = newMaterial;
        renderer.materials = materials;
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject gameObject = other.gameObject;
        if (gameObject.CompareTag("Pickable"))
        {
            pickable = gameObject;
            ChangePipLook(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        GameObject gameObject = other.gameObject;
        if (gameObject.CompareTag("Pickable"))
        {
            pickable = null;
            ChangePipLook(false);
        }
    }
}
