using Assets.Scripts.Task2;
using UnityEngine;

namespace Assets.Scripts.Task3
{
    public class LightSwitch : MonoBehaviour
    {
        private PlayerMover _player;
        private Animator _animator;

        public GameObject SwitcherHint;

        public float MinDistanceToPlayer = 1.8f;

        void Start()
        {
            _animator = GetComponent<Animator>();
            _player = FindObjectOfType<PlayerMover>();

            _animator.SetBool("On", !LighFlicker.Flashing);
        }

        private void Update()
        {
            if (_player != null && Vector3.Distance(transform.position, _player.transform.position) < MinDistanceToPlayer)
            {
                //activate switcher interface
                SwitcherHint.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                    SwitchLight();
            }
            else
            {
                SwitcherHint.SetActive(false);
            }

        }

        public void SwitchLight()
        {
            LighFlicker.Flashing = !LighFlicker.Flashing;
            _animator.SetBool("On", !LighFlicker.Flashing);
        }
    }
}
