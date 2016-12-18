using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public GameObject defaultWaypoint;
    private float angleOfRotation = 1 / 360f;
    public float rotationSpeed = 2;
    public LayerMask layermask;
    public Vector3 startPosition;
    public Quaternion startRotaion;
    public bool animEnded;
    private bool transitionFrame = false;


    private Vector3 desiredPosition;
    private Quaternion desiredRotation;

    void Start()
    {
        startPosition = transform.position;
        startRotaion = transform.rotation;
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
                defaultWaypoint = clickedGmObj;
            }
            else
            {
                Debug.Log("click failed");
            }
            //display = true;
            transform.Translate(defaultWaypoint.transform.position);
        }

        transform.RotateAround(defaultWaypoint.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);

        transitionFrame = false;
    }

    public void StartMoving()
    {
        animEnded = true;
        Debug.Log(animEnded);
    }

    private void MoveCamera()
    {

        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime);
    }
}
