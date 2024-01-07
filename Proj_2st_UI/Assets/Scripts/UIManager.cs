using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // -> UI ����ϱ� ���ؼ�

public class UIManager : MonoBehaviour
{
    // ������ ����� ���
    // ������ ���� -> [int]
    // �Ǽ��� ���� -> [float]
    // ����Ƽ���� ���Ǵ� [���] ������Ʈ(Component)-Class�� ������ ����� �ִ�

    // �ش� ������ ��ȣ������ �����ϸ鼭, �ν����� â������ ���� ��Ű�� ���
    [SerializeField]
    // �ش� ������ ���� ������ = public ���� ������,
    // �ν����� â������ ������ �����ϰ� ���� ��
    //[HideInInspector]
    public Text ui_Text; // ui-Text ������Ʈ ����

    // ��й�ȣ �Է�â
    [SerializeField]
    InputField inputField_PW;
    
    // ��й�ȣ ���� ���� ���
    [SerializeField]
    Toggle toggle_PW;

    // �г� ��Ӵٿ� UI
    [SerializeField]
    Dropdown dropDown_Class;

    // �г� ���õ� ��� �迭
    [Tooltip("@@���� �߿�@@")]
    [SerializeField]
    Toggle[] toggles;

    // ������ ��� �ε���
    int last_toggleIdx = 0;

    [SerializeField]
    Button btn_Click;

    // ��ų Ŭ����
    [System.Serializable]
    public class SkillInfo
    {
        // ��ư 
        public Button btn;
        // �۵� ����
        [HideInInspector]
        public bool isActive;
        // ��Ÿ��
        float coolTime = 1.0f;

        // �̹��� ������Ʈ
        Image img;

        public void Init(float time)
        {
            isActive = false;
            coolTime = time;

            // �̹��� ������Ʈ ������
            img = btn.GetComponent<Image>();
        }

        // ��ų ��� ����
        public IEnumerator Start()
        {
            // ��ų ��� ����
            isActive = true;

            float time = 0f;
            while (true)
            {
                // 1 ������ ���
                yield return null;

                time += Time.deltaTime;
                if(time >= coolTime)
                {
                    Debug.Log("��ų ��� ����");
                    isActive = false;
                    img.fillAmount = 0f;
                    yield break;
                }
                else
                {
                    img.fillAmount += Time.deltaTime / coolTime;
                }
            }
        }
    }

    // ��ų ��ư
    [SerializeField]
    SkillInfo[] skillInfos;

    // �̹��� ���İ� ���� Ŭ����
    [System.Serializable]
    public class ImageAlpha
    {
        // �̹��� ������Ʈ
        public Image img;
        // �����̴� ������Ʈ
        public Slider slider;
        // Color
        Color _color;

        // �ʱ�ȭ �Լ� - 1���� ȣ��
        public void Init()
        {
            _color = img.color;
            // slider �̺�Ʈ ���
            slider.onValueChanged.AddListener(SetSlider);
        }

        // Slider Event �Լ�
        void SetSlider(float value)
        {
            // Slider Value ������ _color.a ����
            _color.a = value;
            // �̹����� color �� ����
            img.color = _color;
        }
    }

    [SerializeField]
    ImageAlpha imgAlpha;

    void Start()
    {
        // UI Event ��� ���
        // 1. ����Ƽ �ν����� �ο��� ���� ���
        // 2. ��ũ��Ʈ ������ ���
        // -> [UI Component ����].[�̺�Ʈ ����].AddListener([�Լ���]);
        //toggle_PW.onValueChanged.AddListener(ShowPassword);

        //DropdownAddOptions();

        //dropDown_Class.onValueChanged.AddListener(DropDownEvent);

        //for (int i = 0; i < toggles.Length; i++)
        //{
        //    toggles[i].onValueChanged.AddListener(ToggleEvent);
        //}

        //btn_Click.onClick.AddListener(OnClickToToggle);

        //for (int i = 0; i < skillInfos.Length; i++)
        //{
        //    int idx = i;
        //    float time = (float)System.Math.Round(Random.Range(1.0f, 3.0f), 1);
        //    skillInfos[i].Init(time);
        //    skillInfos[i].btn.onClick.AddListener(() => { Btn_Skill(idx); });
        //}

        imgAlpha.Init();
    }

    int toggleIdx = 0;
    void OnClickToToggle()
    {
        // ���� ����ؾ� �ϴ� ��� ��ȣ ���ϱ�
        toggleIdx %= toggles.Length;

        // ���� ��� OFF
        int prevIdx = (toggleIdx - 1 + toggles.Length) % toggles.Length;

        // ���� ��� ON
        toggles[toggleIdx].isOn = true;

        toggleIdx++;
    }

    void DropdownAddOptions()
    {
        List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();
        for (int i = 1; i < 4; i++)
        {
            options.Add(new Dropdown.OptionData { text = $"{i}�г�" });
        }

        dropDown_Class.AddOptions(options);
    }

    // DropDown Event �Լ�
    void DropDownEvent(int value)
    {
        if (value <= 0)
        {
            toggles[last_toggleIdx].isOn = false;
            return;
        }

        last_toggleIdx = value - 1;
        toggles[last_toggleIdx].isOn = true;
    }

    void ToggleEvent(bool value)
    {
        if (value == false)
        {
            dropDown_Class.value = 0;
            return;
        }

        for (int i = 0; i < toggles.Length; i++)
        {
            if (toggles[i].isOn)
                dropDown_Class.value = i + 1;
        }
    }

    // ��й�ȣ On / Off
    void ShowPassword(bool value)
    {
        // ��� �ɼ� -> isOn ��
        bool isOn = toggle_PW.isOn;

        // isOn == true -> ��й�ȣ ���̱�
        // isOn == false -> ��й�ȣ �����
        if (isOn == true)
        {
            // ��й�ȣ ���̱�
            // -> InputField �Ӽ� -> content type -> standard
            inputField_PW.contentType = InputField.ContentType.Standard;
        }
        else
        {
            inputField_PW.contentType = InputField.ContentType.Password;
        }

        // Input Field Label ������Ʈ
        inputField_PW.ForceLabelUpdate();

        // Input Field ����
        inputField_PW.ActivateInputField();
    }

    void UI_Text()
    {
        ui_Text.text = $"1. 2022/09/27\n2. 2006/12/25";
        ui_Text.fontStyle = FontStyle.Bold;
        ui_Text.fontSize = 120;
        ui_Text.alignment = TextAnchor.MiddleCenter;
    }

    // ��ų �۵� �Լ� - ��ų ��ư �̺�Ʈ
    void Btn_Skill(int idx)
    {
        // ĳ����
        SkillInfo current = skillInfos[idx];
        // 1. ���� Ȯ��
        if (current.isActive == true)
        {
            Debug.Log("��Ÿ��");
            return;
        }

        StartCoroutine(current.Start());
    }
}
