using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Task3
{
    public class LighFlicker : MonoBehaviour
    {
        public GameObject Lamp;

        public float MinTimeFlash;
        public float MaxTimeFlash;

        public float ScarryLampIntencity;
        public float NormalLampIntencity;

        private float _lastTimeFlashed;

        private static bool _flashing = true;

        public float TimeBetwieenFlash;

        public Light LampLight;

        public static bool Flashing
        {
            get
            {
                return _flashing;
            }

            set
            {
                _flashing = value;
            }
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnLevelFinishedLoading;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnLevelFinishedLoading;
        }


        private void Start()
        {
            _lastTimeFlashed = Time.time;
        }

        private void Update()
        {
            if (Flashing)
            {
                if (Time.time - _lastTimeFlashed > TimeBetwieenFlash)
                {
                    Lamp.SetActive(true);
                    _lastTimeFlashed = Time.time;
                    LampLight.intensity = Random.Range(ScarryLampIntencity, NormalLampIntencity);
                    TimeBetwieenFlash = Random.Range(MinTimeFlash, MaxTimeFlash);
                }
                else
                {
                    Lamp.SetActive(false);
                }

                LampLight.intensity = ScarryLampIntencity;
            }
            else
            {
                Lamp.SetActive(true);

                LampLight.intensity = NormalLampIntencity;
            }
        }

        private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
        {
            Debug.Log("Level loaded");
            Debug.Log(scene.name);
            Debug.Log(mode);

            Flashing = true;
        }
    }
}
