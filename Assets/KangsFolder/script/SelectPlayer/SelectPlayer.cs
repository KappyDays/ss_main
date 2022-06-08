using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// DB���� ĳ���� ���� �޾ƿ�.
public class SelectPlayer : MonoBehaviour
{

    public static SelectPlayer Instance;
    // ���� �������� SelectPlayerManager ������Ʈ ����� �� �ֵ���
    public GameObject DontDestroy_Object;
    private void Awake()
    {
        DontDestroy_Object = GameObject.Find("SelectPlayerManager");
        if (Instance != null)
        {
            Destroy(DontDestroy_Object); // �̹� ������Ʈ�� �����ϸ�
            Instance = this; // �����ϰ� �ٽ� ����
            DontDestroyOnLoad(DontDestroy_Object);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(DontDestroy_Object);
    }

    new Text name;
    private GameObject P;
    
    public int maxPlayer = 5;
    public int nowPlayer = 0;
    public int maxView = 3;
    public int mouseSelect = -1;
    int t;

    int InputButtonCount = 0;

    public InputField inputField_Value;

    // DB���� ������ ĳ���� ���� (+status ��) ����� �׽�Ʈ
    public string[] Pname= new string[5] 
    { "������1", 
        "������2", //1
        "������3", //2
        "",  //3
        "" }; //4
    //dd

    //P1.transform.Find("name1").gameObject.SetActive(false); // �ڽ�����
    // Start is called before the first frame update
    public void InputPname(string[] nameArr, int start)
    {
        int k = 0;

        for (t = start; t < maxView+start; t++)
        {
            
            P = GameObject.Find("Player_name" + (k+1));
            name = P.GetComponent<Text>();
            name.text = nameArr[t];

            k += 1;
        }
    }

    public void firstStartButtonPrint()
    {
        if (nowPlayer > maxView)
            GameObject.Find("Canvas").transform.Find("RightScroll_Button").gameObject.SetActive(true);
    }

    public void leftButton()
    {
        //nowPlayerCount();

        InputButtonCount += -1;
        Debug.Log("����!" + InputButtonCount);
        InputPname(Pname, InputButtonCount);

        CheckButtonPrint();
    }

    public void rightButton()
    {
        //nowPlayerCount();

        InputButtonCount += 1;
        Debug.Log("������!" + InputButtonCount);
        InputPname(Pname, InputButtonCount);

        CheckButtonPrint();
    }

    public void CheckButtonPrint()
    {
        Debug.Log("CBP: " + InputButtonCount + " " + nowPlayer);
        if (InputButtonCount > 0) // �������� �� Ƚ���� ���Ҵٸ�
        {
            GameObject.Find("Canvas").transform.Find("LeftScroll_Button").gameObject.SetActive(true);
        }
        else
        {
            GameObject.Find("Canvas").transform.Find("LeftScroll_Button").gameObject.SetActive(false);
        }

        if (InputButtonCount < (nowPlayer - maxView)) // ���������� �� Ƚ���� ���Ҵٸ�
        {
            GameObject.Find("Canvas").transform.Find("RightScroll_Button").gameObject.SetActive(true);
        }
        else
        {
            GameObject.Find("Canvas").transform.Find("RightScroll_Button").gameObject.SetActive(false);
        }
    }

    public void Chch()
    {
        //nowPlayerCount();
        Debug.Log("CBP: " + InputButtonCount + " " + nowPlayer);
        Debug.Log(Pname[0] + Pname[1] + Pname[2] + Pname[3] + Pname[4]);
        Debug.Log(nowPlayer);
    }

    public void OffScroll()
    {
        GameObject.Find("Canvas").transform.Find("LeftScroll_Button").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("RightScroll_Button").gameObject.SetActive(false);
    }

    public void CreateP(InputField inputField_Value)
    {
        Debug.Log("CreateP");

        if (inputField_Value.text == "") // ĳ���� �̸��� �����ϰ��
        {
            GameObject.Find("CreatePlayer_Button").transform.Find("NullNameAlert_PopUp").gameObject.SetActive(true);
            return;
        }

        if (nowPlayer == maxPlayer) // ĳ������ �ִ��� ���
        {
            Debug.Log("ĳ�� ������");
            inputField_Value.text = ""; //�Է��ʵ� �� �������� �ʱ�ȭ

            //��� ȭ�� ���
            GameObject.Find("CreatePlayer_Button").transform.Find("MaxCreateAlert_PopUp").gameObject.SetActive(true);
            return;
        }
        string[] temp = new string[5];
        System.Array.Copy(Pname, 0, temp, 1, nowPlayer);

        temp[0] = inputField_Value.text; // ���γ��� ĳ�� �̸�
        Debug.Log("te������ : " + temp[0] + temp[1] + temp[2] + temp[3] + temp[4]);


        System.Array.Copy(temp, Pname, nowPlayer+1);

        Debug.Log("Pn������ : " + Pname[0] + Pname[1] + Pname[2] + Pname[3] + Pname[4]);
        nowPlayer += 1;

        Debug.Log("nowP? : " + nowPlayer);

        InputPname(Pname, 0);
        CheckButtonPrint();

        inputField_Value.text = ""; //�����Ŀ� �Է��ʵ� �� �������� �ʱ�ȭ
    }

    protected void nowPlayerCount()
    {
        nowPlayer = 0;
        for (t = 0; t < maxPlayer; t++)
        {
            if (Pname[t] != "")
            {
                nowPlayer += 1;
            }
        }
        Debug.Log("�����÷��̾�:" + nowPlayer);
    }

    

    public void SelectedPlayer(int selected)
    {
        mouseSelect = selected + InputButtonCount;
        Debug.Log(Pname[mouseSelect]);
    }

    public void ChangeScene(int selected)
    {
        switch (selected)
        {
            case 1: // ���� ����
                Debug.Log("mouseSelect: " + mouseSelect);
                if (mouseSelect == -1)
                {
                    GameObject.Find("StartGame_Button")
                        .transform.Find("SelectPlayerAlert_PopUp")
                        .gameObject.SetActive(true);
                    OffScroll();
                }
                else
                {
                    SceneManager.LoadScene("GameMain");
                    Debug.Log("���õ� ����(selected): " + selected);
                }

                break;
            case 2: // ���� ȭ��
                SceneManager.LoadScene("Main");
                Debug.Log("���õ� ����(selected): " + selected);
                break;
            case 3: // 
                Debug.Log("���õ� ����(selected): " + selected);
                break;
            case 4: // 
                Debug.Log("���õ� ����(selected): " + selected);
                break;
            case 5: // 
                Debug.Log("���õ� ����(selected): " + selected);
                break;

        }
    }

    void Start()
    {
        mouseSelect = -1;
        Debug.Log("ù���� mouseSelect: " + mouseSelect);
        
        InputPname(Pname, 0);

        //���� �÷��̾� �� ���ϱ�

        //nowPlayerCount();
        nowPlayerCount();
        firstStartButtonPrint();

        Debug.Log("CBP: " + InputButtonCount + " " + nowPlayer + maxPlayer);
        Debug.Log(Pname[0] + Pname[1] + Pname[2] + Pname[3] + Pname[4]);
        Debug.Log(nowPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
