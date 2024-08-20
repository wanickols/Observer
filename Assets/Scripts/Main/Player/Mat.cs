using System;
using UnityEngine;

[Serializable]
public enum colorLayers
{
    white = 6,
    black = 7,
    red = 8,
    green = 9,
    blue = 10,
}


[Serializable]
public class Mat
{
    public colorLayers layer;
    public string name;
    public Material material;
}