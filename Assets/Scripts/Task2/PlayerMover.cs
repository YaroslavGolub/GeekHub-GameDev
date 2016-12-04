using UnityEngine;

namespace Assets.Scripts.Task2
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField]
        protected float PlayerSpeed;

        private float _rotation;

        private Vector3 _moveDirection;

        private void Start()
        {
           // DontDestroyOnLoad(this.gameObject);
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            _moveDirection.z = Input.GetAxis("Vertical") * PlayerSpeed * Time.deltaTime;
            _rotation = Input.GetAxis("Horizontal") * PlayerSpeed/2 ;

            transform.Translate(_moveDirection);
            transform.Rotate(0, _rotation, 0);
        }
    }
}
