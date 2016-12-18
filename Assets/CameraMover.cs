using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public GameObject defaultWaypoint;
    public PlanetSatellite currentWaypoint;
    
    public float rotationSpeed = 2;

    public LayerMask layermask;    
    
    
    private bool transitionFrame = false;
    private bool defaultPos = true;
    private Vector3 desiredPosition;
    private Quaternion desiredRotation;

    void Start()
    {
        
    }


    private GameObject GetClickedGameObject()
    {
        // Builds a ray from camera point of view to the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        // Casts the ray and get the first game object hit
        //Debug.DrawRay(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), Color.blue);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layermask))
            return hit.transform.gameObject;
        else
            return null;
    }


    void Update()
    {

        MoveCamera();

        GameObject clickedGmObj = null;
        if (Input.GetMouseButtonDown(0) && !transitionFrame)
        {
            clickedGmObj = GetClickedGameObject();
            if (clickedGmObj != null)
            {
                Debug.Log(clickedGmObj.name);
                currentWaypoint = clickedGmObj.GetComponent<PlanetSatellite>();

                currentWaypoint.watching = true;
            }
            else
            {
                Debug.Log("click failed");
            }
            //display = true;
            
        }

        if (Input.GetMouseButtonDown(1))
        {
            currentWaypoint.watching = false;
            // TODO: Hide Calendar
            currentWaypoint = null;
        }

        defaultPos = currentWaypoint == null;

       // transform.RotateAround(defaultWaypoint.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);

        transitionFrame = false;
    }

    private void MoveCamera()
    {
        if (!defaultPos)
        {


            transform.position = Vector3.Lerp(transform.position, currentWaypoint.Waypoint.position, Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, currentWaypoint.Waypoint.rotation, Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, defaultWaypoint.transform.position, Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, defaultWaypoint.transform.rotation, Time.deltaTime);
        }
    }
}
