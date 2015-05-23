using UnityEngine;
using System.Collections;

public class GameInfo : MonoBehaviour
{
    public static Color CurrentColor
    {
        get
        {
            if (ColorSequence != null)
                return ColorSequence.CurrentColor;
            else
                return default(Color);
        }
    }

    public static void ChangeColor()
    {
        //Debug.Log(CurrentColor.ToString());
        if (ColorSequence != null)
            ColorSequence.ChangeColor();
       // Debug.Log(CurrentColor.ToString());

    }

    private static ColorSequence ColorSequence;

    void Start()
    {
        ColorSequence = GetComponent<ColorSequence>();
    }
}
