using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CesiumForUnity;

public class Management : MonoBehaviour
{
    
    /**
     * CSV header:
     * JR_SEMN_ACCDN,DT_ACCDN,CD_MUNCP,NB_VEH_IMPLIQUES_ACCDN,NB_MORTS,NB_BLESSES_GRAVES,NB_BLESSES_LEGERS,HEURE_ACCDN,AN,NB_VICTIMES_TOTAL,GRAVITE,LOC_LONG,LOC_LAT
     */

    [SerializeField] private GameObject coyotePrefab;
    [SerializeField] private GameObject crimePrefab;
    [SerializeField] private GameObject parent;
    //[SerializeField] private Slider yearSlider;

    private int chosenYear = 2021;
    
    
    // Start is called before the first frame update
    void Start()
    {
        this.GenerateDataPoints();
    }
    
    void GenerateDataPoints()
    {
        using (var reader = new StreamReader("Assets/Data/crashes.csv"))
        {
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line == null)
                    break;

                string[] values = line.Split(',');
                
                int year = int.Parse(values[8]);
                if (year != 2021)
                    continue;
                
                float lat = float.Parse(values[12]);
                float lon = float.Parse(values[11]);
                Debug.Log(lat + " " + lon);
                var instance = Instantiate(crimePrefab, parent.transform);
                instance.GetComponent<CesiumGlobeAnchor>().latitude = lat;
                instance.GetComponent<CesiumGlobeAnchor>().longitude = lon;
            }
        }
        
        using (var reader = new StreamReader("Assets/Data/comptages_vehicules_cyclistes_pietons.csv"))
        {
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line == null)
                    break;

                string[] values = line.Split(',');

                

                float lat = float.Parse(values[6]);
                float lon = float.Parse(values[5]);
                Debug.Log(lat + " " + lon);
                var instance = Instantiate(coyotePrefab, parent.transform);
                instance.GetComponent<CesiumGlobeAnchor>().latitude = lat;
                instance.GetComponent<CesiumGlobeAnchor>().longitude = lon;
            }
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
