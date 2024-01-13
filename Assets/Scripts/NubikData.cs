using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NubikCubik", menuName = "Nubiks/CreateCubik")]
public class NubikData : ScriptableObject
{
    public string Name;
    public float Scale;
    public float PositionX;
    public float PositionY;
    public Color Color;
    public GameObject Shape;
}
