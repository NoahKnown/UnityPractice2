using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Renpy : MonoBehaviour
{
    [SerializeField] Image img_BG; // ���
    [SerializeField] Image img_BG2; // ���2
    [SerializeField] Image[] img_Character; // ĳ����

    [SerializeField] TextMeshProUGUI txt_Name; // ĳ���� �̸�
    [SerializeField] TextMeshProUGUI txt_Name_Title; // ĳ���� Ÿ��Ʋ
    [SerializeField] TextMeshProUGUI txt_Chat; // ���

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
        int characterID = SData.GetDialogueData(id).Character; // ��� ���̺��� 1�� ID�� ĳ���� ID �÷��� ������ �´�.
        txt_Name.text = SData.GetCharacterData(characterID).Name; // ĳ���� ���̺��� ĳ���� ID�� �ش��ϴ� �̸��� ������ �´�.
        txt_Name_Title.text = SData.GetCharacterData(characterID).Title; // ĳ���� ���̺��� ĳ���� ID�� Ÿ��Ʋ�� ������ �´�.

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
