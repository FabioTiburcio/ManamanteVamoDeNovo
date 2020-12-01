using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchScript : MonoBehaviour
{
    public GameObject pesquisaGrande;
    public GameObject pesquisaPequena;
    public Text conclusionText;
    public PlayerQuest player;
    public InputField inputField;
    public InputField inputField2;
    public PesquisaEllgog pesquisaEllgog;
    // Start is called before the first frame update


    private void OnEnable()
    {
        pesquisaEllgog.Resultado.SetActive(false);
        pesquisaEllgog.semResultado.SetActive(false);
        pesquisaPequena.SetActive(false);
        pesquisaGrande.SetActive(true);   
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Search(string info)
    {
        if (info == "Field1")
        {
            pesquisaEllgog.attInfo(inputField.text);
        }
        else if (info == "Field2")
        {
            pesquisaEllgog.attInfo(inputField2.text);
        }
        else if (info == "Relacionada1")
        {
            pesquisaEllgog.attInfo(pesquisaEllgog.pesquisaRelacionada1.text);
        }
        else if (info == "Relacionada2")
        {
            pesquisaEllgog.attInfo(pesquisaEllgog.pesquisaRelacionada2.text);
        }
        player.QuestAtt(inputField.text, true);

    }
}
