using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColorExtensions
{
    /// <summary>
    /// Convert string to Color (if defined as a static property of Color)
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    public static Color ToColor(this string color)
    {
        return (Color)typeof(Color).GetProperty(color.ToLowerInvariant()).GetValue(null, null);
    }
}
