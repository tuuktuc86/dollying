using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TechTweaking.Bluetooth; // BT 제어 
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Animations")]
    public Animator[] menu_animators;

    [Header("Timer")]
    public int timer;
    public int maxTimer;
    public Image timerGuage;
    public Text timerTxt;

    [Header("Direction")]
    // 0 : 순방향 , 1 : 역방향 , 2 : 왕복
    public int dirType1 = 0;
    public int dirType2 = 0;
    public int dirType3 = 0;

    [Header("Direction Buttons")]
    public Image[] dirTypeBtns1;
    public Image[] dirTypeBtns2;
    public Image[] dirTypeBtns3;

    [Header("Active Colors")]
    public Color deactiveColor;
    public Color activeColor;

    [Header("Moving Info")]
    public int _distance;
    public int _time;

    [Header("Moving Clips")]
    public GameObject[] movingClipsArr1;
    public GameObject[] movingClipsArr2;
    public GameObject[] movingClipsArr3;

    [Header("Context")]
    public string prevContextName; // 직전 화면 이름
    public GameObject[] contextArr; // 콘텐츠 배열

    public Text[] inputField;

    private BluetoothDevice device;

    public int menu;
    public int mode;

    //public Text t;


    #region BT연결 설정
    private void Awake()
    {
        BluetoothAdapter.enableBluetooth(); //Force Enabling Bluetooth
        device = new BluetoothDevice();
        device.Name = "BT1"; // 내 블루투스 이름
    }

    public void connect()
    {
        device.connect();
    }

    public void disconnect()
    {
        device.close();
    }
    #endregion

    #region Unity Func
    // Start is called before the first frame update
    void Start()
    {
        ContextChanger("1Page1"); // 앱 실행시 로고 출력

        // 2초 후 2Page2 내용 출력
        Invoke("ShowFirstContext", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        SetDirBtnBg1(); // 이동방향 버튼 UI 변경
        SetMovingClips1(); // 이동 애니메이션 미리보기

        SetDirBtnBg2(); // 이동방향 버튼 UI 변경
        SetMovingClips2(); // 이동 애니메이션 미리보기

        SetDirBtnBg3(); // 이동방향 버튼 UI 변경
        SetMovingClips3(); // 이동 애니메이션 미리보기

        // 타이머 감소 UI 처리
        if (timer >= 0 && contextArr[5].activeSelf == true)
        {
            timerTxt.text = timer.ToString();
            // Mathf.Lerp(현재값, 목표값, 변화속도); // 변화속도에는 Time.deltaTime * (배속f)
            //timerGuage.fillAmount = (float)timer / (float)maxTimer;
            timerGuage.fillAmount = Mathf.Lerp(timerGuage.fillAmount, (float)timer / (float)maxTimer, Time.deltaTime);
        }else if (timer >= -1 && timerGuage.fillAmount > 0 && contextArr[5].activeSelf == true)
        {
            timerGuage.fillAmount = Mathf.Lerp(timerGuage.fillAmount, 0f, Time.deltaTime);
        }
    }


    #endregion

    #region Context
    public void ShowFirstContext()
    {
        ContextChanger("2Page2");
    }

    /// <summary>
    /// 콘텐츠 활성화 및 비활성화 처리
    /// </summary>
    /// <param name="conName">콘텐츠 활성화 시킬 게임오브젝트 이름</param>
    public void ContextChanger(string conName)
    {
        for (int i = 0; i < contextArr.Length; i++)
        {
            if (contextArr[i].name == conName)
            {
                if (i != 5) prevContextName = conName;

                contextArr[i].SetActive(true);

                if (i < 5) menu = i;

                switch (i)
                {
                    case 2:
                        mode = dirType1;
                        break;
                    case 3:
                        mode = dirType2;
                        break;
                    case 4:
                        mode = dirType3;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                contextArr[i].SetActive(false);
            }
        }



    }

    // 직전 설정 화면으로 이동
    public void BackToModify()
    {
        ContextChanger(prevContextName);
    }


    #endregion

    #region Direction
    // 이동방향 버튼 UI 변경
    public void SetDirBtnBg1()
    {
        for (int i = 0; i < dirTypeBtns1.Length; i++)
        {
            if (i == dirType1)
            {
                dirTypeBtns1[i].color = activeColor;
                //mode = i;
            }
            else
            {
                dirTypeBtns1[i].color = deactiveColor;
            }
        }
    }

    // 이동 애니메이션 미리보기
    public void SetMovingClips1()
    {
        Animator anim = menu_animators[0];

        switch (dirType1)
        {
            case 0:
                anim.SetBool("menu1_act1", true);
                anim.SetBool("menu1_act2", false);
                anim.SetBool("menu1_act3", false);
                break;
            case 1:
                anim.SetBool("menu1_act1", false);
                anim.SetBool("menu1_act2", true);
                anim.SetBool("menu1_act3", false);
                break;
            case 2:
                anim.SetBool("menu1_act1", false);
                anim.SetBool("menu1_act2", false);
                anim.SetBool("menu1_act3", true);
                break;
            default:
                break;
        }

        /*
        for (int i = 0; i < movingClipsArr1.Length; i++)
        {
            if (i == dirType1)
            {
                movingClipsArr1[i].SetActive(true);

            }
            else
            {
                movingClipsArr1[i].SetActive(false);
            }
        }
        */
    }

    // 버튼 클릭시 dirType 변경
    public void SetDirValue1(int dirNum)
    {
        dirType1 = dirNum;
        mode = dirNum;
    }

    //---------------------------------------------------
    // 이동방향 버튼 UI 변경
    public void SetDirBtnBg2()
    {
        for (int i = 0; i < dirTypeBtns2.Length; i++)
        {
            if (i == dirType2)
            {
                dirTypeBtns2[i].color = activeColor;
                //mode = i;
            }
            else
            {
                dirTypeBtns2[i].color = deactiveColor;
            }
        }


    }

    // 이동 애니메이션 미리보기
    public void SetMovingClips2()
    {
        Animator anim = menu_animators[1];

        switch (dirType2)
        {
            case 0:
                anim.SetBool("menu2_act1", true);
                anim.SetBool("menu2_act2", false);
                anim.SetBool("menu2_act3", false);
                break;
            case 1:
                anim.SetBool("menu2_act1", false);
                anim.SetBool("menu2_act2", true);
                anim.SetBool("menu2_act3", false);
                break;
            case 2:
                anim.SetBool("menu2_act1", false);
                anim.SetBool("menu2_act2", false);
                anim.SetBool("menu2_act3", true);
                break;
            default:
                break;
        }

        /*
        for (int i = 0; i < movingClipsArr2.Length; i++)
        {
            if (i == dirType2)
            {
                movingClipsArr2[i].SetActive(true);
            }
            else
            {
                movingClipsArr2[i].SetActive(false);
            }
        }
        */
    }

    // 버튼 클릭시 dirType 변경
    public void SetDirValue2(int dirNum)
    {
        dirType2 = dirNum;
        mode = dirNum;
    }

    //---------------------------------------------------

    // 이동방향 버튼 UI 변경
    public void SetDirBtnBg3()
    {
        for (int i = 0; i < dirTypeBtns3.Length; i++)
        {
            if (i == dirType3)
            {
                dirTypeBtns3[i].color = activeColor;
                //mode = i;
            }
            else
            {
                dirTypeBtns3[i].color = deactiveColor;
            }
        }
    }

    // 이동 애니메이션 미리보기
    public void SetMovingClips3()
    {
        Animator anim = menu_animators[2];

        switch (dirType3)
        {
            case 0:
                anim.SetBool("menu3_act1", true);
                anim.SetBool("menu3_act2", false);
                anim.SetBool("menu3_act3", false);
                break;
            case 1:
                anim.SetBool("menu3_act1", false);
                anim.SetBool("menu3_act2", true);
                anim.SetBool("menu3_act3", false);
                break;
            case 2:
                anim.SetBool("menu3_act1", false);
                anim.SetBool("menu3_act2", false);
                anim.SetBool("menu3_act3", true);
                break;
            default:
                break;
        }

        /*
        for (int i = 0; i < movingClipsArr3.Length; i++)
        {
            if (i == dirType3)
            {
                movingClipsArr3[i].SetActive(true);
            }
            else
            {
                movingClipsArr3[i].SetActive(false);
            }
        }
        */
    }

    // 버튼 클릭시 dirType 변경
    public void SetDirValue3(int dirNum)
    {
        dirType3 = dirNum;
        mode = dirNum;
    }

    //---------------------------------------------------

    #endregion


    public void SendDataToBt()
    {
        if (device != null)
        {


            // 혼합 이동을 위한 분기 처리
            string distance1;
            string time1;
            string distance2;
            string time2;
            string angle2;

            if (menu == 4)
            {
                distance1 = inputField[7].text;
                time1 = inputField[8].text;
                distance2 = inputField[9].text;
                time2 = inputField[10].text;
                angle2 = inputField[11].text;
            }
            else
            {
                distance1 = inputField[0].text;
                time1 = inputField[1].text;
                distance2 = inputField[2].text;
                time2 = inputField[3].text;
                angle2 = inputField[4].text;
            }


            string distance3 = inputField[5].text;

            string time3 = inputField[6].text;

            string menu1 = menu.ToString();
            string mode1 = mode.ToString();

            string resultStr = "<" + menu1 + "," + distance1 + "," + time1 + "," + distance2 + "," + time2 + "," + angle2 + "," + distance3 + "," + time3 + "," + mode1 + ">";
            device.send(System.Text.Encoding.ASCII.GetBytes(resultStr));
            Debug.Log(resultStr);
            //t.GetComponent<Text>().text = resultStr;

            // 타이머 설정
            timer = 0;
            switch (menu)
            {
                case 2:
                    timer = int.Parse(time1);
                    if (mode == 2)
                    {
                        timer *= 2;
                    }
                    break;
                case 3:
                    timer = int.Parse(time2);
                    if (mode == 2)
                    {
                        timer *= 2;
                    }
                    break;
                case 4:
                    timer = int.Parse(time1) + int.Parse(time2) + int.Parse(time3);
                    if (mode == 2)
                    {
                        timer *= 2;
                    }
                    break;
                default:
                    break;
            }

            maxTimer = timer;
            timerGuage.fillAmount = 1f;
            // 타이머 UI 실행 및 타이머 감소
            StartCoroutine(TimerCoroutine());
        }


    }

    IEnumerator TimerCoroutine()
    {
        while (timer >= 0)
        {
            timer--;
            yield return new WaitForSeconds(1f);
        }
        StopCoroutine(TimerCoroutine());
    }

}
