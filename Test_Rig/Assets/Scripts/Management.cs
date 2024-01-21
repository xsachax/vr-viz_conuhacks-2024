using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using CesiumForUnity;

public class Management : MonoBehaviour
{
    
    /**
     * CSV content:
     * lon,lat
     */

    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject parent;
    
    void Awake()
    {
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        using (var reader = new StreamReader("Assets/Data/data.csv"))
        {
            //int numOfPoints = 30000;
            int count = 0;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                string[] values = line.Split(',');
                
                float lat = float.Parse(values[0]);
                float lon = float.Parse(values[1]);
                Debug.Log(lon + " " + lat);
                count++;
                var instance = Instantiate(prefab , parent.transform);
                instance.GetComponent<CesiumGlobeAnchor>().latitude = lat;
                instance.GetComponent<CesiumGlobeAnchor>().longitude = lon;
                
                //numOfPoints--;
            }
            Debug.Log(count);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
