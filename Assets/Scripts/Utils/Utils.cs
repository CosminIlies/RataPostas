using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static TextMesh GenerateTextMesh(string text, Transform parent, Vector3 localPosition)
    {
        GameObject gameObject = new GameObject("word_text", typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.SetParent(parent, false);

        TextMesh textMesh = new TextMesh();


        return textMesh;
    }
   
}
