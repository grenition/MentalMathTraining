using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableComponent : MonoBehaviour
{
    public Text text;
    public Image image;

    public void SetText(string _text)
    {
        if (text == null)
            return;
        text.text = _text;
    }
    public string GetText()
    {
        if (text == null)
            return null;
        return text.text;
    }
    public int GetInt32FromText()
    {
        if (text == null)
            return 0;
        return System.Convert.ToInt32(text.text);
    }
    public void SetColor(Color _color)
    {
        if (image == null)
            return;
        image.color = _color;
    }
}
