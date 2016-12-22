using UnityEngine;

public class SatelliteWatcher : MonoBehaviour
{
    public Transform defaultLookAt;
    public Transform lookAt;

    public Transform defaultInitPosition;
    public Transform initPosition;

    public float speed = 0.25f;
    public float minDistance;
    public float maxDistance;

    void Start()
    {

    }

    void Update()
    {
        Move();
    }

    //  Runs in Update method
    private void Move()
    {
        transform.LookAt(defaultLookAt.position);
    }

    public void ZoomIn(float transition, bool onPlanet = false)
    {
        if(!onPlanet && transition > 0.05f)
        {
            transform.position = Vector3.Lerp(defaultLookAt.position, defaultInitPosition.position, transition);
        }
    }

    public void FollowTo(GameObject lookAt, GameObject initPosition)
    {
        this.lookAt = lookAt.transform;
        this.initPosition = initPosition.transform;
    }

    public void ClearLookAtAndInitPosition()
    {
        this.lookAt = null;
        this.initPosition = null;
    }
}

public enum Planet
{
    Mercury = 1,
    Venus =2,
    Earth,
    Mars,
    Jupiter,
    Saturn,
    Uran,
    Neptune,
    Pluto
}
