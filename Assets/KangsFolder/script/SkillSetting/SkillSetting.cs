using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkillSetting : MonoBehaviour
{
    // ����ϴ� ���� �ʱ�ȭ(Drag.cs���� ���)
    public int[] useSlot = new int[3];
    private int i;

    PrintPlayerInfo PPI = new PrintPlayerInfo();

    public void ChangeScene(int selected)
    {
        switch (selected)
        {
            case 1: // ���� ȭ��(GameMain)���� ���ư���
                Debug.Log("���õ� ����(selected): " + selected);
                SceneManager.LoadScene("GameMain");
                break;
            case 2: // 
                Debug.Log("���õ� ����(selected): " + selected);
                //SceneManager.LoadScene("MonsterBattle");
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

    // Start is called before the first frame update
    void Start()
    {
        for (i = 0; i < 3; i++)
        {
            useSlot[i] = 0;
        }

        // ����� ����(�̸�) ���
        PPI.SetPlayerInfo("PlayerName_Text");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
