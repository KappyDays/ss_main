using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MonsterBattle : MonoBehaviour
{
    public void ChangeScene(int selected)
    {
        switch (selected)
        {
            case 1: // ���� ȭ��(GameMain)���� ���ư���
                Debug.Log("���õ� ����(selected): " + selected);
                SceneManager.LoadScene("GameMain");
                break;
            case 2: // ���� ����
                Debug.Log("���õ� ����(selected): " + selected);
                SceneManager.LoadScene("MonsterBattle");
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
