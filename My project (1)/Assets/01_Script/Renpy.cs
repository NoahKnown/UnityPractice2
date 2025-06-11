using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Renpy : MonoBehaviour
{
    [SerializeField] Image img_BG; // 배경
    [SerializeField] Image img_BG2; // 배경2
    [SerializeField] Image[] img_Character; // 캐릭터

    [SerializeField] TextMeshProUGUI txt_Name; // 캐릭터 이름
    [SerializeField] TextMeshProUGUI txt_Name_Title; // 캐릭터 타이틀
    [SerializeField] TextMeshProUGUI txt_Chat; // 대사

    int id = 1;

    // Start is called before the first frame update
    void Start()
    {
        RefreshUI();
    }

    public void OnClickButton()
    {
        id++;
        RefreshUI(); 
    }

    void RefreshUI()
    {
        int characterID = SData.GetDialogueData(id).Character; // 대사 테이블의 1번 ID의 캐릭터 ID 컬럼을 가지고 온다.
        txt_Name.text = SData.GetCharacterData(characterID).Name; // 캐릭터 테이블에서 캐릭터 ID에 해당하는 이름을 가지고 온다.
        txt_Name_Title.text = SData.GetCharacterData(characterID).Title; // 캐릭터 테이블에서 캐릭터 ID에 타이틀을 가지고 온다.

        txt_Chat.text = SData.GetDialogueData(id).Dialogue;
        img_BG.sprite = Resources.Load<Sprite>("Img/Character/" + SData.GetDialogueData(id).BG);

        for (int i = 1; i <= img_Character.Length; i++)
        {
            if (i == SData.GetDialogueData(i).Position)
            {
                img_Character[i].sprite = Resources.Load<Sprite>("Img/Character/" + SData.GetCharacterData(characterID).Image);
            }
                
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
