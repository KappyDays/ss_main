using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMain : MonoBehaviour
{
    //private GameObject P;
    //private string PlayerName;
    //private Text texts; 
    //int a;
    //int q;

    // ����� �̸� ��������
    PrintPlayerInfo PPI = new PrintPlayerInfo();

    public void arB()
    {
        SceneManager.LoadScene("GameMain");
    }
    public void skillManage()
    {
        SceneManager.LoadScene("skillManage");
    }
    public void LoadBattleScene()
    {
        SceneManager.LoadScene("Battle");
    }

    public void ChangeScene(int selected)
    {
        switch (selected)
        {
            case 1: // Main���� ���ư���
                Debug.Log("���õ� ����(selected): " + selected);
                SceneManager.LoadScene("Main");
                break;
            case 2: // ���� ����
                Debug.Log("���õ� ����(selected): " + selected);
                SceneManager.LoadScene("MonsterBattle");
                break;
            case 3: // ��ų ����
                Debug.Log("���õ� ����(selected): " + selected);
                SceneManager.LoadScene("SkillSetting");
                break;
            case 4: // 
                Debug.Log("���õ� ����(selected): " + selected);
                break;
            case 5: // 
                Debug.Log("���õ� ����(selected): " + selected);
                break;

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //P = GameObject.Find("SelectPlayerManager");
        //a = P.GetComponent<SelectPlayer>().nowPlayer;
        ////Debug.Log("���� Scene�� Object���� ������ nowPlayer ��: " + a);

        //// ����� �̸� �����ͼ� �ֱ�
        //q = P.GetComponent<SelectPlayer>().mouseSelect;
        //PlayerName = P.GetComponent<SelectPlayer>().Pname[q];
        
        //texts = GameObject.Find("PlayerName_Text").GetComponent<Text>();
        //texts.text = PlayerName;

        // ����� ����(�̸�) ���
        PPI.SetPlayerInfo("PlayerName_Text");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
