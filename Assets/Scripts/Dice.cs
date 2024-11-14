using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DiceFace
{
    Orange,
    Green,
    Yellow,
    Blue,
    Grey, //colorless, gives 2
    Gold  //Gives gold resources
}

public class Dice : MonoBehaviour
{
    public DiceFace Roll()
    {
        Array faces = Enum.GetValues(typeof(DiceFace));
        return (DiceFace)faces.GetValue(UnityEngine.Random.Range(0, faces.Length));
    }
}
