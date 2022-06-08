using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// GameObject.Find("Canvas").transform.Find("RightScroll_Button").GetComponent<Animator>()
// GameObject.Find("PlayerSkill"+i).transform.GetChild(i-1).gameObject;
public class MyEnemy : MonoBehaviour
{
    //public GameObject canvas;
    //public GameObject prfHpBar;
    Image hpBar;
    //public float height = 1.7f;
    //public float width = -8.0f;

    public int maxHp;
    public int nowHp;
    SpriteRenderer sr;

    void Start()
    {
        hpBar = GameObject.Find("Enemy_bghp_bar")
            .transform.Find("hp_bar")
            .GetComponent<Image>();
        //hpBar = Instantiate(prfHpBar, canvas.transform).GetComponent<RectTransform>();

        maxHp = 50;
        nowHp = maxHp;

        sr = GetComponent<SpriteRenderer>();
    }

    // Enter ������, Stay�ȿ�������, Exit�������
    void OnTriggerStay2D(Collider2D other)
    //void OnTriggerEnter2D(Collider2D other)
    //���⼭ OnTriggerStay2D�� �����ϸ� �ִ� ���� ����.
    {
        Player q = other.GetComponent<Player>();

        if (q != null && q.animator.GetCurrentAnimatorStateInfo(0).IsName("attack_new") && q.attacked)
        {
            sr.flipX = true;
            nowHp = nowHp - q.atkDmg;
            Debug.Log("EnemyHP: " + nowHp);
            q.attacked = false;
            return;
        } //

    }

    void Update()
    {
        //Vector2 _hpBarPos = Camera.main.WorldToScreenPoint(new Vector2(transform.position.x+width, transform.position.y + height));
        //hpBar.position = _hpBarPos;

        //nowHpbar�κ��� hpBar�� fillAmount�� ���� ���� ���� �翡 ���� �޶����� �����߽��ϴ�.
        //nowHpbar.fillAmount = (float)nowHp / (float)maxHp;
        hpBar.fillAmount = (float)nowHp / (float)maxHp;
    }
}

