using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public DiceFace face;
    public Sprite[] faceSprites;
    private Image imageRenderer;

    private void Start()
    {
        imageRenderer = GetComponent<Image>();
    }

    public DiceFace Roll()
    {
        // Randomly select a face
        DiceFace[] faces = (DiceFace[])System.Enum.GetValues(typeof(DiceFace));
        int randomVal = UnityEngine.Random.Range(0, faces.Length);
        face = (DiceFace)randomVal;
        DiceUI();

        return faces[randomVal];
        
        
    }

    public void DiceUI()
    {
        switch (face)
        {
            case DiceFace.Orange:
                imageRenderer.sprite = faceSprites[0];
                break;

            case DiceFace.Green:
                imageRenderer.sprite = faceSprites[1];
                break;

            case DiceFace.Yellow:
                imageRenderer.sprite = faceSprites[2];
                break;

            case DiceFace.Blue:
                imageRenderer.sprite = faceSprites[3];
                break;

            case DiceFace.Grey:
                imageRenderer.sprite = faceSprites[4];
                break;

            case DiceFace.Gold:
                imageRenderer.sprite = faceSprites[5];
                break;
        }
    }
}
