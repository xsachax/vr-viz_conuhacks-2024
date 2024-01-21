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

    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject parent;
    [SerializeField] private Material deathMat;
    [SerializeField] private Material injuryMat;
    [SerializeField] private Material fineMat;
    [SerializeField] private Slider yearSlider;

    private int chosenYear = 2021;
    
    
    // Start is called before the first frame update
    void Start()
    {
        this.GenerateDataPoints();
    }

    void GenerateDataPoints()
    {
        using (var reader = new StreamReader("Assets/Data/data.csv"))
        {
            //int numOfPoints = 3000;
            Material currentPointType; // 0 = death, 1 = injury, 2 = fine
            while (!reader.EndOfStream) //(numOfPoints > 0)
            {
                var line = reader.ReadLine();
                if (line == null)
                    break;
                
                string[] values = line.Split(',');

                int year = int.Parse(values[8]);
                if (year != this.chosenYear)
                    continue;

                int deaths = int.Parse(values[4]);
                int injuries = int.Parse(values[5]);
                if (deaths > 0)
                    currentPointType = this.deathMat;
                else if (injuries > 0)
                    currentPointType = this.injuryMat;
                else
                    currentPointType = this.fineMat;

                prefab.GetComponent<MeshRenderer>().material = currentPointType;
                
                float lat = float.Parse(values[12]);
                float lon = float.Parse(values[11]);
                Debug.Log(lat + " " + lon);
                var instance = Instantiate(prefab, parent.transform);
                instance.GetComponent<CesiumGlobeAnchor>().latitude = lat;
                instance.GetComponent<CesiumGlobeAnchor>().longitude = lon;
                
                //numOfPoints--;
            }
        }
    }
    
    void DestroyDataPoints()
    {
        foreach (Transform child in parent.transform)
        {
            Destroy(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnSliderChange()
    {
        
    }
    
    public void OnConfirm()
    {
        Debug.Log("Confirm");
        this.chosenYear = (int) this.yearSlider.value;
        this.DestroyDataPoints();
        this.GenerateDataPoints();
    }
}
