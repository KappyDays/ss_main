using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintPlayerInfo
{
    private GameObject PlayerObj;
    private string PlayerName;
    private int selectedNum;
    private Text texts;

    public void SetPlayerInfo(string Pname_obj)
    {
        PlayerObj = GameObject.Find("SelectPlayerManager");
        Debug.Log("1");
        // 사용자 이름 가져와서 넣기
        selectedNum  = PlayerObj.GetComponent<SelectPlayer>().mouseSelect;
        Debug.Log("2");
        PlayerName = PlayerObj.GetComponent<SelectPlayer>().Pname[selectedNum];
        Debug.Log("3");

        texts = GameObject.Find(Pname_obj).GetComponent<Text>();
        Debug.Log("4");
        texts.text = PlayerName;
    }

}
