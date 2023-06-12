// this script adjusts camera behavior when player enters certain triggers in the game.

using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{

    public HedgeCamera Cam; // assign main camera object
    float InitialDistance; // store initial camera distance

    void Awake()
    {
        InitialDistance = Cam.CameraMaxDistance;
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.tag == "CameraTrigger")
        {
            if (col.GetComponent<CameraTriggerData>() != null)
            {
                if (col.GetComponent<CameraTriggerData>().Type == TriggerType.LockToDirection) // check trigger type
                {
                    Vector3 dir = col.transform.forward; // direction to look at
                    Cam.SetCamera(dir, 2f, col.GetComponent<CameraTriggerData>().CameraAltitude, 5f, 1); // set camera properties
                    Cam.Locked = true; // lock camera position
                    if (col.GetComponent<CameraTriggerData>().changeDistance)
                    {
                        Cam.CameraMaxDistance = col.GetComponent<CameraTriggerData>().ChangeDistance;
                    }
                    else
                    {
                        Cam.CameraMaxDistance = InitialDistance; // restore to original distance
                    }
                }
                else if (col.GetComponent<CameraTriggerData>().Type == TriggerType.SetFree)
                {
                    Cam.CameraMaxDistance = InitialDistance;
                    Cam.Locked = false; // unlock camera position
                }
                else if (col.GetComponent<CameraTriggerData>().Type == TriggerType.SetFreeAndLookTowards)
                {
                    Vector3 dir = col.transform.forward; // direction the prefab collision box is facing
                    Cam.SetCamera(dir, 2.5f, col.GetComponent<CameraTriggerData>().CameraAltitude, 5f, 1); // calls function SetCamera in HedgeCamera script attached to MainCamera.
                    if (!col.GetComponent<CameraTriggerData>().changeDistance)
                    {
                        Cam.CameraMaxDistance = InitialDistance;
                    }
                    else
                    {
                        Cam.CameraMaxDistance = col.GetComponent<CameraTriggerData>().ChangeDistance; // change to given distance
                    }
                    Cam.Locked = false; // unlock camera position
                }
            }
        }

    }

}



