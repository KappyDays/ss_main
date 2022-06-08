using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// GameObject.Find("Canvas").transform.Find("RightScroll_Button").GetComponent<Animator>()
// GameObject.Find("PlayerSkill"+i).transform.GetChild(i-1).gameObject;
public class Drag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    public static Vector2 DefaultPos; // �巡�� ���� �� �ʱ� ��ġ ���� ����
    
    private GameObject[] Slot = new GameObject[3]; // ���� ���� �� Player�� Slot ���� ����

    public SkillSetting Setting; // SkillSetting Class�� useSlot ���� ��� ����.

    int i; // �ݺ����� ����

    // �巡�� ���� ��(Ŭ�� ��)
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        DefaultPos = this.transform.position;
    }

    // �巡�� ����, Vector2�� �巡�� ���� ��ġ�� ������ ������Ʈ�� ��ġ�� ����
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = eventData.position;
        this.transform.position = currentPos;
    }

    public bool CheckBoxIn(GameObject target, PointerEventData eventData)
    {
        int rangeNum = 40;

        //Debug.Log("target.transform.position.x: " + target.transform.position.x);
        //Debug.Log("target.transform.position.y: " + target.transform.position.y);

        if (target.transform.position.x - rangeNum <= eventData.position.x &&
            eventData.position.x <= target.transform.position.x + rangeNum &&
            target.transform.position.y - rangeNum <= eventData.position.y &&
            eventData.position.y <= target.transform.position.y + rangeNum)
        {
            return true;
        }
        return false;  
    }

    public bool CheckBoxOut(GameObject target, PointerEventData eventData)
    {
        int rangeNum = 40;

        //Debug.Log("target.transform.position.x: " + target.transform.position.x);
        //Debug.Log("target.transform.position.y: " + target.transform.position.y);

        if (!(target.transform.position.x - rangeNum <= eventData.position.x &&
            eventData.position.x <= target.transform.position.x + rangeNum &&
            target.transform.position.y - rangeNum <= eventData.position.y &&
            eventData.position.y <= target.transform.position.y + rangeNum))
        {
            return true;
        }
        return false;
    }

    // �巡�׸� ������ ��
    private GameObject temp; // ������ ���� ������Ʈ�� ��� ����
    public int[] BoxIndex = new int[] {0, 0, 0}; // PlayerSkill���� ������Ʈ ��������� ���� ���ǿ� ����
    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        for (i = 1; i < 4; i++)
        {
            if (Setting.useSlot[i - 1] == 0) // ������ ������� �ʰ� ���� ���
            {
                if (CheckBoxIn(Slot[i - 1], eventData) == true)
                {
                    Setting.useSlot[i - 1] = 1; // ����� �ڸ��� ���̻� ��� ���ϰ�
                                                
                    BoxIndex[i - 1] = i; // ����� �ڽ� ��ġ ����
                    //����(GameObject, ��ġ, ȸ��, �θ�)
                    Instantiate(this, 
                        Slot[i - 1].transform.position, 
                        Quaternion.identity, 
                        Slot[i - 1].transform);
                    BoxIndex[i - 1] = 0; 
                    this.transform.position = DefaultPos;

                    break;
                }
            }
            else
            {
                this.transform.position = DefaultPos;
            }

            // ������ ����ϰ�, �ڽ��� �ε����� ��ġ�ؾ� ��
            if (Setting.useSlot[i - 1] == 1 && BoxIndex[i - 1] == i)
            {
                if (CheckBoxOut(Slot[i - 1], eventData) == true)
                {
                    Setting.useSlot[i - 1] = 0; // ����� �ڸ� �ʱ�ȭ
                    // GameObject.Find("Canvas").transform.Find("RightScroll_Button").GetComponent<Animator>()
                    temp = GameObject.Find("PlayerSkill" + i)
                        .transform.GetChild(0)
                        .gameObject;
                    Destroy(temp); //�ڱ� ����

                    break;
                }
            }
            else
            {
                this.transform.position = DefaultPos;
            }
        }

        
        //for (i = 1; i < 4; i++)
        //{

        //}

        Debug.Log("�巡�� ��: " + eventData.position);
        Debug.Log("�巡�� ��, useSlot: " + Setting.useSlot[0] + Setting.useSlot[1] + Setting.useSlot[2]);

    }

    void Start()
    {

        Setting = GameObject.Find("SkillSettingManager").GetComponent<SkillSetting>();

        for (i=1; i<4; i++)
        {
            Slot[i-1] = GameObject.Find("PlayerSkill" + i);
        }

    }
    void Update()
    {
        

    }
}