using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager_05 : MonoBehaviour
{
    [SerializeField]
    Dropdown dropdown;
    [SerializeField]
    InputField inputfield;
    [SerializeField]
    Button btn_Add;
    [SerializeField]
    Button btn_Remove;

    string value;

    void Start()
    {
        btn_Add.onClick.AddListener(Add);
        btn_Remove.onClick.AddListener(Remove);
    }

    void Add()
    {
        if (inputfield.text == null)
            return;

        for (int i = 0; i < dropdown.options.Count; i++)
        {
            if (dropdown.options[i].text == inputfield.text)
                return;
        }

        List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();
        options.Add(new Dropdown.OptionData { text = $"{inputfield.text}" });
        dropdown.AddOptions(options);

    }

    void Remove()
    {
        if (inputfield.text == null)
            return;

        for (int i = 0; i < dropdown.options.Count; i++)
        {
            if (dropdown.options[i].text == inputfield.text)
                dropdown.options.RemoveAt(i);
        }
    }
}
