using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager_01 : MonoBehaviour
{
    [SerializeField]
    Text id;

    [SerializeField]
    Text name;

    [SerializeField]
    Toggle toggle;

    void Start()
    {
        toggle.onValueChanged.AddListener(Set);
    }

    void Set(bool isOn)
    {
        if (isOn)
        {
            id.fontSize = 150;
            id.fontStyle = FontStyle.Bold;
            id.color = Color.red;
            name.fontSize = 100;
            name.fontStyle = FontStyle.Normal;
            name.color = Color.white;
        }
        else
        {
            id.fontSize = 130;
            id.fontStyle = FontStyle.Italic;
            id.color = Color.green;
            name.fontSize = 120;
            name.fontStyle = FontStyle.Normal;
            name.color = Color.blue;
        }
    }
}
