using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchScript : MonoBehaviour
{

    public Text conclusionText;
    public PlayerQuest player;
    public InputField inputField;
    public SkillController skills;
    public DiaryInfoController diaryInfoController;
    [TextArea]
    public string description;
    public string title;
    public Sprite torfarios;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Search()
    {
        player.QuestAtt(inputField.text, true);
        if(inputField.text == "Torfarios")
        {
            Debug.Log("pesquisei toda mona");
            diaryInfoController.SetInfo(title, torfarios, description, "Inimigos", "Inimigo");
            skills.canIce = true;
        }
        
    }
}
