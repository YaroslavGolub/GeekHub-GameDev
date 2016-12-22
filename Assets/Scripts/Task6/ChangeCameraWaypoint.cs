using Assets.Scripts.Task6;
using UnityEngine;

public class ChangeCameraWaypoint : MonoBehaviour
{
    private CameraMover cam;
    public bool thisOnStart;
    public GameObject waypointToChange;

    void Start()
    {
        cam = FindObjectOfType<CameraMover>();

        if(thisOnStart)
            cam.ChangeFollowingObject(this.gameObject);
    }

    public void ChangeWaypoint()
    {
        cam.ChangeFollowingObject(waypointToChange, true);
    }

    public void ChangeWaypoint(GameObject waypoint)
    {
        cam.ChangeFollowingObject(waypoint);
    }
}
