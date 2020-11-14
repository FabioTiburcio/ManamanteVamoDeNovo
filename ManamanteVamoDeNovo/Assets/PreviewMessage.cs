using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviewMessage : MonoBehaviour
{

    public Image fotoTela;
    public Text assuntoTela;
    public Text nomeTela;
    public int questNumber;
    public EmailScreen email;
    


    // Start is called before the first frame update
    void Start()
    {

        
        
    }

    // Update is called once per frame
    void Update()
    {
        fotoTela.sprite = email.quests[questNumber].quest.npcFoto;
        assuntoTela.text = email.quests[questNumber].quest.title;
        nomeTela.text = email.quests[questNumber].quest.description;
    }
}
