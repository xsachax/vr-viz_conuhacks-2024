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
            int girth = 10000;
            while (girth > 0) // (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                string[] values = line.Split(',');
                
                float lat = float.Parse(values[0].Replace("\"", ""));
                float lon = float.Parse(values[1].Replace("\"", ""));
                Debug.Log(lon + " " + lat);
                var instance = Instantiate(prefab , parent.transform);
                instance.GetComponent<CesiumGlobeAnchor>().latitude = lat;
                instance.GetComponent<CesiumGlobeAnchor>().longitude = lon;
                
                girth--;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
