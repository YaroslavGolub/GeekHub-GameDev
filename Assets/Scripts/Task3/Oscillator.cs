using UnityEngine;

namespace Assets.Scripts.Task3
{
    public class Oscillator : MonoBehaviour
    {
        private float _timeCounter;

        public float Speed;
        public float Amplitude;

        private Vector3 _position;
        private Vector3 _startPosition;

        private void Start()
        {
            _startPosition = _position = transform.position;
        }
        void Update()
        {
            if (LighFlicker.Flashing)
            {
                _timeCounter += Time.deltaTime * Speed;
                _position.x += Amplitude * Mathf.Cos(_timeCounter);
                transform.position = _position;
            }
            else
            {
                transform.position = _startPosition;
            }
        }
    }
}
