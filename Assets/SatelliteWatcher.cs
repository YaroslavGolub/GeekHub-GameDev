using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteWatcher : MonoBehaviour
{

    public GameObject planet;
    private float speed = 0.25f;
    // Use this for initialization
    void Start()
    {
        if(planet ==null)
            planet = transform.parent.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(planet.transform.position);
        transform.RotateAround(planet.transform.position, Vector3.down, Time.deltaTime + speed);
    }
}
