using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PesquisaEllgog : MonoBehaviour
{
    public string pesquisaTitle;
    public GameObject semResultado;
    public GameObject Resultado;
    public Image imagemPesquisa;
    public Text descricaoPesquisa;
    public Text pesquisaRelacionada1;
    public Text pesquisaRelacionada2;
    public PesquisaDataBase pesquisaDataBase;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void attInfo(string pesquisaFeita)
    {
        Resultado.SetActive(true);
        switch (pesquisaFeita)
        {
            case "maca":
            case "Maca":
            case "Maça":
            case "Maçã":
                setInfo(0);
                break;
            case "Banana":
            case "banana":
                setInfo(1);
                break;
            case "Poção de cura":
            case "poção de cura":
            case "Pocao de cura":
            case "pocao de cura":
                setInfo(2);
                break;
            case "torfarios":
            case "Torfarios":
                setInfo(3);
                break;
            case null:
                Resultado.SetActive(false);
                semResultado.SetActive(true);
                break;
        }
    }

    void setInfo(int databasePosition)
    {
        imagemPesquisa.sprite = pesquisaDataBase.dadosEllgogs[databasePosition].image;
        descricaoPesquisa.text = pesquisaDataBase.dadosEllgogs[databasePosition].description;
        pesquisaRelacionada1.text = pesquisaDataBase.dadosEllgogs[databasePosition].similarLink.pesquisaTitle;
        pesquisaRelacionada2.text = pesquisaDataBase.dadosEllgogs[databasePosition].similarLink2.pesquisaTitle;
    }
}
