using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // -> UI 사용하기 위해서

public class UIManager : MonoBehaviour
{
    // 변수를 만드는 방법
    // 정수형 변수 -> [int]
    // 실수형 변수 -> [float]
    // 유니티에서 사용되는 [모든] 컴포넌트(Component)-Class를 변수로 만들수 있다

    // 해당 변수의 보호수준은 유지하면서, 인스펙터 창에서만 노출 시키는 방법
    [SerializeField]
    // 해당 변수의 접근 제한자 = public 형식 이지만,
    // 인스펙터 창에서는 노출을 금지하고 있을 때
    //[HideInInspector]
    public Text ui_Text; // ui-Text 컴포넌트 변수

    // 비밀번호 입력창
    [SerializeField]
    InputField inputField_PW;
    
    // 비밀번호 오픈 여부 토글
    [SerializeField]
    Toggle toggle_PW;

    // 학년 드롭다운 UI
    [SerializeField]
    Dropdown dropDown_Class;

    // 학년 관련된 토글 배열
    [Tooltip("@@순서 중요@@")]
    [SerializeField]
    Toggle[] toggles;

    // 마지막 토글 인덱스
    int last_toggleIdx = 0;

    [SerializeField]
    Button btn_Click;

    // 스킬 클래스
    [System.Serializable]
    public class SkillInfo
    {
        // 버튼 
        public Button btn;
        // 작동 유무
        [HideInInspector]
        public bool isActive;
        // 쿨타임
        float coolTime = 1.0f;

        // 이미지 컴포넌트
        Image img;

        public void Init(float time)
        {
            isActive = false;
            coolTime = time;

            // 이미지 컴포넌트 얻어오기
            img = btn.GetComponent<Image>();
        }

        // 스킬 사용 시작
        public IEnumerator Start()
        {
            // 스킬 사용 여부
            isActive = true;

            float time = 0f;
            while (true)
            {
                // 1 프레임 대기
                yield return null;

                time += Time.deltaTime;
                if(time >= coolTime)
                {
                    Debug.Log("스킬 사용 가능");
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

    // 스킬 버튼
    [SerializeField]
    SkillInfo[] skillInfos;

    // 이미지 알파값 조절 클래스
    [System.Serializable]
    public class ImageAlpha
    {
        // 이미지 컴포넌트
        public Image img;
        // 슬라이더 컴포넌트
        public Slider slider;
        // Color
        Color _color;

        // 초기화 함수 - 1번만 호출
        public void Init()
        {
            _color = img.color;
            // slider 이벤트 등록
            slider.onValueChanged.AddListener(SetSlider);
        }

        // Slider Event 함수
        void SetSlider(float value)
        {
            // Slider Value 값으로 _color.a 변경
            _color.a = value;
            // 이미지의 color 값 변경
            img.color = _color;
        }
    }

    [SerializeField]
    ImageAlpha imgAlpha;

    void Start()
    {
        // UI Event 등록 방법
        // 1. 유니티 인스펙터 팡엥서 직접 등록
        // 2. 스크립트 내에서 등록
        // -> [UI Component 변수].[이벤트 변수].AddListener([함수명]);
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
        // 현재 사용해야 하는 토글 번호 구하기
        toggleIdx %= toggles.Length;

        // 이전 토글 OFF
        int prevIdx = (toggleIdx - 1 + toggles.Length) % toggles.Length;

        // 현재 토글 ON
        toggles[toggleIdx].isOn = true;

        toggleIdx++;
    }

    void DropdownAddOptions()
    {
        List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();
        for (int i = 1; i < 4; i++)
        {
            options.Add(new Dropdown.OptionData { text = $"{i}학년" });
        }

        dropDown_Class.AddOptions(options);
    }

    // DropDown Event 함수
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

    // 비밀번호 On / Off
    void ShowPassword(bool value)
    {
        // 토글 옵션 -> isOn 값
        bool isOn = toggle_PW.isOn;

        // isOn == true -> 비밀번호 보이기
        // isOn == false -> 비밀번호 숨기기
        if (isOn == true)
        {
            // 비밀번호 보이기
            // -> InputField 속성 -> content type -> standard
            inputField_PW.contentType = InputField.ContentType.Standard;
        }
        else
        {
            inputField_PW.contentType = InputField.ContentType.Password;
        }

        // Input Field Label 업데이트
        inputField_PW.ForceLabelUpdate();

        // Input Field 선택
        inputField_PW.ActivateInputField();
    }

    void UI_Text()
    {
        ui_Text.text = $"1. 2022/09/27\n2. 2006/12/25";
        ui_Text.fontStyle = FontStyle.Bold;
        ui_Text.fontSize = 120;
        ui_Text.alignment = TextAnchor.MiddleCenter;
    }

    // 스킬 작동 함수 - 스킬 버튼 이벤트
    void Btn_Skill(int idx)
    {
        // 캐스팅
        SkillInfo current = skillInfos[idx];
        // 1. 상태 확인
        if (current.isActive == true)
        {
            Debug.Log("쿨타임");
            return;
        }

        StartCoroutine(current.Start());
    }
}
