using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NubikSorter : MonoBehaviour
{
    [SerializeField] private NubikData[] _nubikdata;
    private GameObject[] _nubiks;
    private int arraysize;

    void Start()
    {
        CreateArray(_nubikdata);
    }

    void Update()
    {
        BubbleSort();
    }

    public void CreateArray(NubikData[] n)
    {
        arraysize = _nubikdata.Length;
        _nubiks = new GameObject[arraysize];
        for (int i = 0; i < arraysize; i++)
        {
            Vector3 pos = new Vector3(n[i].PositionX, n[i].PositionY, 0);
            float scale = n[i].Scale;
            Color color = n[i].Color;

            GameObject nubik = Instantiate(n[i].Shape, pos, Quaternion.identity);
            nubik.transform.localScale = new Vector3(scale, scale, scale);
            nubik.GetComponent<Renderer>().material.color = color;
            _nubiks[i] = nubik;
        }
   
    }

    public void BubbleSort()
    {
        
        for (int i = 0; i < _nubiks.Length - 1; i++)
        {
            for (int j = 0; j < _nubiks.Length - 1 - i; j++)
            {
                if (_nubiks[j].transform.localScale.x > _nubiks[j + 1].transform.localScale.x )
                {
                    GameObject temp = _nubiks[j];
                    _nubiks[j] = _nubiks[j+1];
                    _nubiks[j+1] = temp;
                }
            }
        }
        

        for (int i = 0; i < _nubiks.Length; i++)
        {
            Vector3 newPosition = new Vector3(_nubiks[i].transform.position.x, i * 5.0f , 0f);
            _nubiks[i].transform.position = newPosition;
        }
    }

    
}


