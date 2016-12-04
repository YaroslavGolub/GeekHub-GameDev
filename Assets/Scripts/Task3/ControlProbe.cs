using UnityEngine;

namespace Assets.Scripts.Task3
{
    public class ControlProbe : MonoBehaviour
    {    
        public GameObject Plane;
        public GameObject Player;

        public float Offset;

        public Direction DirectionFaced;

        private Vector3 _pos = Vector3.zero;



        // Update is called once per frame
        void Update()
        {
            if (DirectionFaced == Direction.X)
            {
                Offset = Plane.transform.position.x - Player.transform.position.x;
                _pos = Player.transform.position;
                _pos.x = Plane.transform.position.x + Offset;
                transform.position = _pos;
            }

            if (DirectionFaced == Direction.Y)
            {
                Offset = Plane.transform.position.y - Player.transform.position.y;
                _pos = Player.transform.position;
                _pos.y = Plane.transform.position.y + Offset;
                transform.position = _pos;
            }

            if (DirectionFaced == Direction.Z)
            {
                Offset = Plane.transform.position.z - Player.transform.position.z;
                _pos = Player.transform.position;
                _pos.z = Plane.transform.position.z + Offset;
                transform.position = _pos;
            }

        }
    }

    public enum Direction
    {
        X,
        Y,
        Z
    }
}