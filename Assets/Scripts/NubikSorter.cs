using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

        for (int i = 0; i < arraysize - 1; i++)
        {
            for (int j = 0; j < arraysize - 1 - i; j++)
            {
                if (_nubiks[j].transform.localScale.x > _nubiks[j + 1].transform.localScale.x)
                {
                    Swap(j,j+1);
                }
            }
        }

        Visualize();
    }

    public void InsertionSort()
    {
        for (int i = 1; i < arraysize; i++)
        {
            GameObject key = _nubiks[i];
            for (int j = i - 1; j >= 0;)
            {
                if (key.transform.localScale.x < _nubiks[j].transform.localScale.x)
                {
                    _nubiks[j + 1] = _nubiks[j];
                    j--;
                    _nubiks[j + 1] = key;
                }
                else
                {
                    break;
                }
            }
        }

        Visualize();
    }

    public void SelectionSort()
    {
        for (int i = 0; i < arraysize - 1; i++)
        {
            int min = i;
            for (int j = i + 1; j < arraysize; j++)
            {
                if (_nubiks[j].transform.localScale.x < _nubiks[min].transform.localScale.x)
                {
                    min = j;
                }
            }

            Swap(min,i);
        }

        Visualize();
    }

    public void CallQuickSort()
    {
        QuickSort(0, arraysize - 1);

        Visualize();
    }

    public void QuickSort(int left, int right)
    {
        int i = left;
        int j = right;
        var pivot = _nubiks[left].transform.localScale.x;
        while (i <= j)
        {
            while (_nubiks[i].transform.localScale.x < pivot)
            {
                i++;
            }

            while (_nubiks[j].transform.localScale.x > pivot)
            {
                j--;
            }
            if (i <= j)
            {
                Swap(i, j);

                i++;
                j--;
            }
        }

        if (left < j)
            QuickSort(left, j);
        if (i < right)
            QuickSort(i, right);
    }

    public void Visualize()
    {
        for (int i = 0; i < _nubiks.Length; i++)
        {
            _nubiks[i].transform.position = new Vector3(_nubiks[i].transform.position.x, i * 5.0f, 0f);
        }
    }

    void Swap(int i, int j)
    {
        GameObject temp = _nubiks[i];
        _nubiks[i] = _nubiks[j];
        _nubiks[j] = temp;
    }



}


