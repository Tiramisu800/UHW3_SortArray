using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nubik : MonoBehaviour
{
    [SerializeField] private NubikData _nubikData;
    [SerializeField] private Material _nubikMaterial;

    void Start()
    {
        _nubikMaterial.color = _nubikData.Color;
        
    }

}


