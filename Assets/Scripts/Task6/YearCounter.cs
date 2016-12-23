using UnityEngine;

namespace Task6
{
    public class YearCounter : MonoBehaviour {

        private int _year = 0;

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public void CountYear()
        {
            _year++;
        }
    }
}
