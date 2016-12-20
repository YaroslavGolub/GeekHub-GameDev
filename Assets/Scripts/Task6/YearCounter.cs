using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YearCounter : MonoBehaviour {

	int _year = 0;

	public void CountYear()
	{
		_year++;
	}

	public int GetCurrentYear()
	{
		return _year;
	}
}
