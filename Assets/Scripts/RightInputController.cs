using UnityEngine;

public class RightInputController : InputController
{
    protected override OVRInput.Axis1D IndexTrigger()
    {
        return OVRInput.Axis1D.SecondaryIndexTrigger;
    }
}
