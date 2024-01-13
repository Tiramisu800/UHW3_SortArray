using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NubikSorter : MonoBehaviour
{
    [SerializeField] private NubikData[] _nubikdata;
    private GameObject[] _nubiks;

    void Start()
    {
        int i = 0; 
        foreach (var n in _nubikdata)
        {
            Vector3 pos = new Vector3(n.PositionX, n.PositionY, 0);
            float scale = n.Scale;
            Color color = n.Color;

            GameObject nubik = Instantiate(n.Shape, pos, Quaternion.identity);
            nubik.transform.localScale = new Vector3(scale, scale, scale);
            nubik.GetComponent<Renderer>().material.color = color;
            _nubiks[i] = nubik;
            i++;
        }
    }

    void Update()
    {
        
    }
}


