using UnityEngine;
using UnityEngine.UI;

namespace Task6
{
    public class PlanetContainer : MonoBehaviour
    { 
        private Text _planetName;
        private Button _btn;

        public Planet ThePlanet;
        private PlanetSatellite _satellite;

        private void Awake()
        {
            Initialize();
        }
        
        public void OnBtnClick()
        {
            FindObjectOfType<CameraMover>().ChangeCurrentWaypoint(_satellite);
        }

        private void Initialize()
        {
            PlanetSatellite[] satellites = FindObjectsOfType<PlanetSatellite>();
            for (int i = 0; i < satellites.Length; i++)
            {
                if(satellites[i].name == ThePlanet.ToString())
                {
                    _satellite = satellites[i];
                    break;
                }
            }

            _planetName = this.gameObject.GetComponentInChildren<Text>();
            _btn = this.gameObject.GetComponentInChildren<Button>();
            _planetName.text = _satellite.name;
            _btn.onClick.AddListener(OnBtnClick);
        }
    }
}
