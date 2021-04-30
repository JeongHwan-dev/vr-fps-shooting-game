using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleVRTeleporterController : MonoBehaviour {
    public VRTeleporter teleporter;

    void Update()
    {
        if (VRInput.GetVRButtonDown(VRInput.Button.LeftIndex))
        {
            teleporter.Teleport();
            teleporter.ToggleDisplay(true);
        }
    }
}
