using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    //private GameObject P;
    //private string PlayerName;
    //private Text texts;
    //int q;

    //Common ������ ->PrintPlayerInfo.cs�� Ŭ���� ����
    PrintPlayerInfo PPI = new PrintPlayerInfo();

    // Start is called before the first frame update
    void Start()
    {
        PPI.SetPlayerInfo("PlayerName_Text");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
