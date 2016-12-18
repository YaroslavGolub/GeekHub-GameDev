using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YearCounter : MonoBehaviour {

	int year = 0;

	public void CountYear()
	{
		year++;
	}

	public int GetCurrentYear()
	{
		return year;
	}
}
