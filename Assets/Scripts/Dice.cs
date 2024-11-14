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

public class Dice
{
    public DiceFace Roll()
    {
        // Randomly select a face
        DiceFace[] faces = (DiceFace[])System.Enum.GetValues(typeof(DiceFace));
        return faces[UnityEngine.Random.Range(0, faces.Length)];
    }
}
