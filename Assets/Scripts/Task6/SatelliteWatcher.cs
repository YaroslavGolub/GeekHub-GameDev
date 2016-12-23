using UnityEngine;

namespace Task6
{
    public class SatelliteWatcher : MonoBehaviour
    {
        public Transform DefaultLookAt;
        public Transform LookAt;

        public Transform DefaultInitPosition;
        public Transform InitPosition;

        public float Speed = 0.25f;
        public float MinDistance;
        public float MaxDistance;

        void Update()
        {
            Move();
        }

        //  Runs in Update method
        private void Move()
        {
            transform.LookAt(DefaultLookAt.position);
        }

        public void ZoomIn(float transition, bool onPlanet = false)
        {
            if (!onPlanet && transition > 0.05f)
            {
                transform.position = Vector3.Lerp(DefaultLookAt.position, DefaultInitPosition.position, transition);
            }
        }

        public void FollowTo(GameObject lookAt, GameObject initPosition)
        {
            this.LookAt = lookAt.transform;
            this.InitPosition = initPosition.transform;
        }

        public void ClearLookAtAndInitPosition()
        {
            this.LookAt = null;
            this.InitPosition = null;
        }
    }

    public enum Planet
    {
        Mercury = 1,
        Venus = 2,
        Earth,
        Mars,
        Jupiter,
        Saturn,
        Uran,
        Neptune,
        Pluto
    }
}