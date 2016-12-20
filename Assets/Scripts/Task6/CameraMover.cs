using UnityEngine;

namespace Assets.Scripts.Task6
{
    public class CameraMover : MonoBehaviour
    {
        public GameObject DefaultWaypoint;
        public PlanetSatellite CurrentWaypoint;
    
        public float RotationSpeed = 2;

        public LayerMask LMask;

        public GameObject InfoPanel;
    
        private bool _transitionFrame = false;
        private bool _defaultPos = true;

        private void Start()
        {
            InfoPanel.SetActive(false);
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


        void Update()
        {

            MoveCamera();

            if (Input.GetMouseButtonDown(0) && !_transitionFrame)
            {
                if (CurrentWaypoint != null)
                {
                    CurrentWaypoint.Watching = false;
                    CurrentWaypoint = null;
                    InfoPanel.SetActive(false);
                }

                var clickedGmObj = GetClickedGameObject();
                if (clickedGmObj != null)
                {
                    Debug.Log(clickedGmObj.name);
                    CurrentWaypoint = clickedGmObj.GetComponent<PlanetSatellite>();

                    CurrentWaypoint.Watching = true;
                    InfoPanel.SetActive(true);
                }
                else
                {
                    Debug.Log("click failed");
                }
           
            
            }

            if (Input.GetMouseButtonDown(1) && CurrentWaypoint !=null)
            {
                CurrentWaypoint.Watching = false;
                InfoPanel.SetActive(false);
                // TODO: Hide Calendar
                CurrentWaypoint = null;
            }

            _defaultPos = CurrentWaypoint == null;

            _transitionFrame = false;
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
    }
}
