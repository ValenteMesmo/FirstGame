using UnityEngine;
using System.Collections;

public class ColorSequence : MonoBehaviour
{
    public Color[] Colors;
    private int currentColor = 0;

    protected void Start()
    {
        var tempColors = Colors;
        Colors = new Color[tempColors.Length];
        for (int i = 0; i < tempColors.Length; i++)
        {
            var color = tempColors[i];
            Colors[i] = new Color(color.r, color.g, color.b);
        }
    }    

    public Color CurrentColor
    {
        get
        {
            return Colors[currentColor];
        }
    }

    public Color FutureColor
    {
        get
        {
            if (currentColor >= Colors.Length)
                return Colors[0];
            return Colors[currentColor+1];
        }
    }

    public void ChangeColor()
    {
        currentColor++;
        if (currentColor >= Colors.Length)
            currentColor = 0;
    }
}
