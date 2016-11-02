using UnityEngine;
using System.Collections;

public class UIHelper : MonoBehaviour
{

	[SerializeField] private GameObject helpPanel;

	private void Start()
	{
		if(!helpPanel.activeInHierarchy)
			helpPanel.SetActive(true);
	}	
	void Update () {
		if(Input.GetKeyDown(KeyCode.W))
			helpPanel.SetActive(false);
	}
}
