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
        using (var reader = new StreamReader("Assets/Data/crimes_good.csv"))
        {
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line == null)
                    break;

                string[] values = line.Split(',');
                
                float lat = float.Parse(values[1]);
                float lon = float.Parse(values[0]);
                Debug.Log(lat + " " + lon);
                var instance = Instantiate(crimePrefab, parent.transform);
                instance.GetComponent<CesiumGlobeAnchor>().latitude = lat;
                instance.GetComponent<CesiumGlobeAnchor>().longitude = lon;
            }
        }
        
        using (var reader = new StreamReader("Assets/Data/declarations_punaises_de_lit.csv"))
        {
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line == null)
                    break;

                string[] values = line.Split(',');

                //int year = int.Parse(values[8]);
                //if (year != 2021)
                //    continue;

                float lat = float.Parse(values[2]);
                float lon = float.Parse(values[1]);
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
