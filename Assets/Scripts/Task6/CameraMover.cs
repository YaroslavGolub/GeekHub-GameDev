using UnityEngine;
using UnityEngine.UI;

namespace Task6
{
    public class CameraMover : MonoBehaviour
    {
        public GameObject DefaultWaypoint;
        public PlanetSatellite CurrentWaypoint;
        public SatelliteWatcher StWatcher;

        public float RotationSpeed = 2;

        public LayerMask LMask;

        public GameObject InfoPanel;
        public GameObject Orbits;

        public Scrollbar ThScrollbar;

        private bool _canZoom;
        private bool _defaultPos = true;

        private void Start()
        {
            InfoPanel.SetActive(false);
            ThScrollbar.transform.parent.gameObject.SetActive(false);
            Orbits.SetActive(true);
        }

        private GameObject GetClickedGameObject()
        {
            // Builds a ray from camera point of view to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // Casts the ray and get the first game object hit
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, LMask))
                return hit.transform.gameObject;
            else
                return null;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var clickedGmObj = GetClickedGameObject();

                if (clickedGmObj != null)
                {
                    Debug.Log(clickedGmObj.name);
                    ChangeCurrentWaypoint(clickedGmObj.GetComponent<PlanetSatellite>());
                }
                else
                {
                    Debug.Log("click failed");
                }
            }

            // Returns to the default waypoint.position
            if (Input.GetMouseButtonDown(1))
            {
                ClearWaypointData();
            }

            _defaultPos = CurrentWaypoint == null;

            if (_canZoom)
            {
                ThScrollbar.transform.parent.gameObject.SetActive(!InfoPanel.activeInHierarchy);
                Orbits.SetActive(!InfoPanel.activeInHierarchy);
                StWatcher.ZoomIn(ThScrollbar.value);
            }

            MoveCamera();
        }
        public void ChangeCurrentWaypoint(PlanetSatellite waypoint)
        {
            if (CurrentWaypoint != null)
                ClearWaypointData();
            // if true updates current day/year info
            CurrentWaypoint = waypoint;

            CurrentWaypoint.Watching = true;
            InfoPanel.SetActive(true);
        }

        // Clears current waypoint beore reach next
        private void ClearWaypointData()
        {
            if (CurrentWaypoint != null)
            {
                CurrentWaypoint.Watching = false;
                CurrentWaypoint = null;
                InfoPanel.SetActive(false);
            }
        }

        private void MoveCamera()
        {
            if (!_defaultPos)
            {
                transform.position = Vector3.Lerp(transform.position, CurrentWaypoint.Waypoint.position, Time.deltaTime);
                transform.rotation = Quaternion.Lerp(transform.rotation, CurrentWaypoint.Waypoint.rotation, Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, DefaultWaypoint.transform.position, Time.deltaTime);
                transform.rotation = Quaternion.Lerp(transform.rotation, DefaultWaypoint.transform.rotation, Time.deltaTime);
            }
        }

        public void ChangeFollowingObject(GameObject followTo, bool allowZoom = false)
        {
            if (followTo != null)
                DefaultWaypoint = followTo;

            _canZoom = allowZoom;
        }

        public void FollowDefault(GameObject followTo)
        {
            ClearWaypointData();
        }

        public void TogleActiveStateOfGameobject(GameObject go)
        {
            if(go!=null)
                go.SetActive(!go.activeInHierarchy);
        }
    }
}
