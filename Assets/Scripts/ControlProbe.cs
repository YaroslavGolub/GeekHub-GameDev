using UnityEngine;
using System.Collections;

public class ControlProbe : MonoBehaviour
{    
    public GameObject plane;
    public GameObject player;

    public float offset;

    public Direction directionFaced;

    private Vector3 pos = Vector3.zero;



    // Update is called once per frame
    void Update()
    {
        if (directionFaced == Direction.X)
        {
            offset = plane.transform.position.x - player.transform.position.x;
            pos = player.transform.position;
            pos.x = plane.transform.position.x + offset;
            transform.position = pos;
        }

        if (directionFaced == Direction.Y)
        {
            offset = plane.transform.position.y - player.transform.position.y;
            pos = player.transform.position;
            pos.y = plane.transform.position.y + offset;
            transform.position = pos;
        }

        if (directionFaced == Direction.Z)
        {
            offset = plane.transform.position.z - player.transform.position.z;
            pos = player.transform.position;
            pos.z = plane.transform.position.z + offset;
            transform.position = pos;
        }

    }
}

public enum Direction
{
    X,
    Y,
    Z
}
