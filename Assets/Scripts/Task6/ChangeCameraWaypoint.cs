using UnityEngine;

namespace Task6
{
    public class ChangeCameraWaypoint : MonoBehaviour
    {
        private CameraMover cam;
        public bool ThisOnStart;
        public GameObject WaypointToChange;

        void Start()
        {
            cam = FindObjectOfType<CameraMover>();

            if(ThisOnStart)
                cam.ChangeFollowingObject(this.gameObject);
        }

        public void ChangeWaypoint()
        {
            cam.ChangeFollowingObject(WaypointToChange, true);
        }

        public void ChangeWaypoint(GameObject waypoint)
        {
            cam.ChangeFollowingObject(waypoint);
        }
    }
}
