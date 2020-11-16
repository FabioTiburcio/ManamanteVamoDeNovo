using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PesquisaEllgog : MonoBehaviour
{
    public string pesquisaTitle;
    public GameObject semResultado;
    public GameObject Resultado;
    public GameObject downloadButton;
    public Image imagemPesquisa;
    public Text descricaoPesquisa;
    public Text pesquisaRelacionada1;
    public Text pesquisaRelacionada2;
    public PesquisaDataBase pesquisaDataBase;
    public SkillController skillController;
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
        semResultado.SetActive(false);
        switch (pesquisaFeita)
        {
            case "maca":
            case "Maca":
            case "Maça":
            case "Maçã":
                downloadButton.SetActive(false);
                setInfo(0);
                break;
            case "Banana":
            case "banana":
                downloadButton.SetActive(false);
                setInfo(1);
                break;
            case "Poção de cura":
            case "poção de cura":
            case "Pocao de cura":
            case "pocao de cura":
                downloadButton.SetActive(false);
                setInfo(2);
                break;
            case "torfarios":
            case "Torfarios":
                downloadButton.SetActive(false);
                setInfo(3);
                break;
            case "floresta sombralida":
            case "Floresta sombralida":
            case "Floresta Sombralida":
                downloadButton.SetActive(false);
                setInfo(4);
                break;
            case "Speilctre":
            case "speilctre":
                downloadButton.SetActive(false);
                setInfo(5);
                break;
            case "gelo":
            case "Gelo":
                downloadButton.SetActive(true);
                skillController.habilityToUnlock = 1;
                setInfo(6);
                break;
            case "raio":
            case "Raio":
                downloadButton.SetActive(true);
                skillController.habilityToUnlock = 2;
                setInfo(7);
                break;
            case "veneno":
            case "Veneno":
                downloadButton.SetActive(true);
                skillController.habilityToUnlock = 3;
                setInfo(8);
                break;
            default:
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
