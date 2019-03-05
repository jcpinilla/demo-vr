using UnityEngine;

public class LeftInputController : InputController
{
    protected override OVRInput.Axis1D IndexTrigger()
    {
        return OVRInput.Axis1D.PrimaryIndexTrigger;
    }
}
