using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Task6
{
    public class PlanetSatellite : MonoBehaviour
    {

        public Transform Waypoint;
        private int _day = 0;

        public YearCounter TheYearCounter;

        public bool Watching;

        private Text _nameText;
        private Text _dayText;
        private Text _yearText;

        void Awake()
        {
            Watching = false;
            _nameText = GameObject.Find("NameTxt").GetComponent<Text>();
            _dayText = GameObject.Find("DayTxt").GetComponent<Text>();
            _yearText = GameObject.Find("YearTxt").GetComponent<Text>();
        }


        void Update()
        {
            if (!Watching)
                return;

            UpdateText();

        }

        public void UpdateText()
        {
            _nameText.text = "Name : " + gameObject.name;
            _dayText.text = "Days : " + _day;
            _yearText.text = "Year : " + TheYearCounter.GetCurrentYear();
        }

        public void CountDay()
        {
            _day++;
        }
    }
}
