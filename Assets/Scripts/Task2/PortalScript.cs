using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Task2
{

    public class PortalScript : MonoBehaviour
    {
        public string SceneToLoad;

        private readonly Color32 _initialColor = Color.gray;
        private readonly Color32 _colorToLerp = Color.green;

        private Renderer _theRenderer;

        private PlayerMover _playerMover;

        private float _distanceToPlayer;
        private float _initialDistanceToPlayer;

        private Vector3 _startPosition;


        private void Start()
        {
            _playerMover = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMover>();
            if (_playerMover != null)
                _initialDistanceToPlayer = Vector3.Distance(transform.position, _playerMover.transform.position);

            _theRenderer = GetComponent<Renderer>();
            _startPosition = transform.position;
        }

        private void Update()
        {
            transform.position = _startPosition + new Vector3(0, Mathf.Sin(Time.time), 0);

            if (_playerMover == null)
                return;

            _distanceToPlayer = Vector3.Distance(transform.position, _playerMover.transform.position);
            // Debug.Log(distanceToPlayer / initialDistanceToPlayer + " | " + distanceToPlayer);
            _theRenderer.material.color = Color.Lerp(_colorToLerp, _initialColor, _distanceToPlayer / _initialDistanceToPlayer);
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                SceneManager.LoadScene(SceneToLoad);
            }
        }
    }
}
