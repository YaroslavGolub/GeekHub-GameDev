using UnityEngine.UI;
using UnityEngine;
using Assets.Scripts.Task6;

public class PlanetContainer : MonoBehaviour
{ 
    private Text planetName;
    private Button btn;

    public Planet planet;
    private PlanetSatellite satellite;

    private void Awake()
    {
        Initialize();
    }
    // Use this for initialization
    void Start()
    {
        //planetName = this.gameObject.GetComponentInChildren<Text>();
        //btn = this.gameObject.GetComponentInChildren<Button>();
        //planetName.text = satellite.name;
        //btn.onClick.AddListener(OnBtnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBtnClick()
    {
        FindObjectOfType<CameraMover>().ChangeCurrentWaypoint(satellite);

    }

    private void Initialize()
    {
        PlanetSatellite[] satellites = FindObjectsOfType<PlanetSatellite>();
        for (int i = 0; i < satellites.Length; i++)
        {
            if(satellites[i].name == planet.ToString())
            {
                satellite = satellites[i];
                break;
            }
        }

        planetName = this.gameObject.GetComponentInChildren<Text>();
        btn = this.gameObject.GetComponentInChildren<Button>();
        planetName.text = satellite.name;
        btn.onClick.AddListener(OnBtnClick);
        //foreach(var t in satellites)
        //{
        //    if(t.name == planet.ToString())
        //    {
        //        satellite = t;
        //    }

        //    Debug.Log(t.name);
        //}
    }
}
