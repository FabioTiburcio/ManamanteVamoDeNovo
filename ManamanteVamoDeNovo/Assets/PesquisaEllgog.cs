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
    public DiaryInfoController diaryInfoController;

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
            case "abelhuda":
            case "Abelhuda":
                escreverNoDiario(0,"Inimigos");
                downloadButton.SetActive(false);
                setInfo(0);
                break;
            case "abominacao":
            case "Abominacao":
            case "Abominação":
            case "abominacao de veneno":
            case "Abominacao de veneno":
            case "Abominação de veneno":
                escreverNoDiario(1, "Inimigos");
                downloadButton.SetActive(false);
                setInfo(1);
                break;
            case "antidoto de fogo":
            case "Antidoto de fogo":
            case "antídoto de fogo":
            case "Antídoto de fogo":
                escreverNoDiario(2, "Coletaveis");
                downloadButton.SetActive(false);
                setInfo(2);
                break;
            case "antidoto de gelo":
            case "Antidoto de gelo":
            case "antídoto de gelo":
            case "Antídoto de gelo":
                escreverNoDiario(3, "Coletaveis");
                downloadButton.SetActive(false);
                setInfo(3);
                break;
            case "antidoto de veneno":
            case "Antidoto de veneno":
            case "antídoto de veneno":
            case "Antídoto de veneno":
                escreverNoDiario(4, "Coletaveis");
                downloadButton.SetActive(false);
                setInfo(4);
                break;
            case "antidoto eletrico":
            case "Antidoto eletrico":
            case "Antidoto elétrico":
            case "antídoto elétrico":
            case "Antídoto elétrico":
                escreverNoDiario(5, "Coletaveis");
                downloadButton.SetActive(false);
                setInfo(5);
                break;
            case "Arnim Zola":
                downloadButton.SetActive(false);
                setInfo(6);
                break;
            case "asa de inseto":
            case "Asa de inseto":
            case "asas de inseto":
            case "Asas de inseto":
                escreverNoDiario(7, "Coletaveis");
                downloadButton.SetActive(false);
                setInfo(7);
                break;
            case "asa de morcego":
            case "Asa de morcego":
            case "asas de morcego":
            case "Asas de morcego":
                escreverNoDiario(8, "Coletaveis");
                downloadButton.SetActive(false);
                setInfo(8);
                break;
            case "banana":
            case "Banana":
                escreverNoDiario(9, "Coletaveis");
                downloadButton.SetActive(false);
                setInfo(9);
                break;
            case "rafael":
            case "Rafael":
            case "baroli":
            case "Baroli":
            case "alcolatra":
            case "Alcolatra":
            case "ama a cor vinho":
            case "Ama a cor vinho":
            case "Baroli, Rei do submundo":
                downloadButton.SetActive(false);
                setInfo(10);
                break;
            case "brayni":
            case "Brayni":
                escreverNoDiario(11, "Inimigos");
                downloadButton.SetActive(false);
                setInfo(11);
                break;
            case "caveira vermelha":
            case "Caveira vermelha":
                downloadButton.SetActive(false);
                setInfo(12);
                break;
            case "claudemir":
            case "Claudemir":
                downloadButton.SetActive(false);
                setInfo(13);
                break;
            case "cobra":
            case "Cobra":
                escreverNoDiario(14, "Inimigos");
                downloadButton.SetActive(false);
                setInfo(14);
                break;
            case "cogumelo amarelo":
            case "Cogumelo amarelo":
                escreverNoDiario(15, "Coletaveis");
                downloadButton.SetActive(false);
                setInfo(15);
                break;
            case "cogumelo azul":
            case "Cogumelo azul":
                escreverNoDiario(16, "Coletaveis");
                downloadButton.SetActive(false);
                setInfo(16);
                break;
            case "cogumelo venenoso":
            case "Cogumelo venenoso":
                escreverNoDiario(17, "Coletaveis");
                downloadButton.SetActive(false);
                setInfo(17);
                break;
            case "cordilheiras":
            case "Cordilheiras":
            case "cordilheiras criogênicas":
            case "Cordilheiras criogenicas":
            case "Cordilheiras Criogênicas":
                downloadButton.SetActive(false);
                setInfo(18);
                break;
            case "cryogolem":
            case "Cryogolem":
            case "CryoGolem":
                escreverNoDiario(19, "Inimigos");
                downloadButton.SetActive(false);
                setInfo(19);
                break;
            case "cryoquebra":
            case "Cryoquebra":
            case "CryoQuebra":
                escreverNoDiario(20, "Inimigos");
                downloadButton.SetActive(false);
                setInfo(20);
                break;
            case "cyborgue":
            case "Cyborgue":
                escreverNoDiario(21, "Inimigos");
                downloadButton.SetActive(false);
                setInfo(21);
                break;
            case "elixir de fogo":
            case "Elixir de fogo":
            case "Elixir de Fogo":
                escreverNoDiario(22, "Coletaveis");
                downloadButton.SetActive(false);
                setInfo(22);
                break;
            case "elixir de gelo":
            case "Elixir de gelo":
            case "Elixir de Gelo":
                escreverNoDiario(23, "Coletaveis");
                downloadButton.SetActive(false);
                setInfo(23);
                break;
            case "elixir de veneno":
            case "Elixir de veneno":
            case "Elixir de Veneno":
                escreverNoDiario(24, "Coletaveis");
                downloadButton.SetActive(false);
                setInfo(24);
                break;
            case "elixir eletrico":
            case "Elixir eletrico":
            case "Elixir Eletrico":
            case "Elixir elétrico":
            case "Elixir Elétrico":
                escreverNoDiario(25, "Coletaveis");
                downloadButton.SetActive(false);
                setInfo(25);
                break;
            case "essencia de fogo":
            case "Essencia de fogo":
            case "essência de fogo":
            case "Essência de fogo":
            case "Essencia de Fogo":
                escreverNoDiario(26, "Coletaveis");
                downloadButton.SetActive(false);
                setInfo(26);
                break;
            case "essencia de gelo":
            case "Essencia de gelo":
            case "essência de gelo":
            case "Essência de gelo":
            case "Essencia de Gelo":
                escreverNoDiario(27, "Coletaveis");
                downloadButton.SetActive(false);
                setInfo(27);
                break;
            case "essencia de veneno":
            case "Essencia de veneno":
            case "essência de veneno":
            case "Essência de veneno":
            case "Essencia de Veneno":
                escreverNoDiario(28, "Coletaveis");
                downloadButton.SetActive(false);
                setInfo(28);
                break;
            case "essencia eletrica":
            case "Essencia eletrica":
            case "essência eletrica":
            case "Essência elétrica":
            case "Essencia Eletrica":
                escreverNoDiario(29, "Coletaveis");
                downloadButton.SetActive(false);
                setInfo(29);
                break;
            case "Fabio":
            case "Tibas":
            case "fabin":
            case "ReiTibas":
            case "Rei Tibas":
                downloadButton.SetActive(false);
                setInfo(30);
                break;
            case "flor eletrica":
            case "Flor eletrica":
            case "Flor Eletrica":
            case "flor elétrica":
            case "Flor elétrica":
            case "Flor Elétrica":
                escreverNoDiario(31, "Coletaveis");
                downloadButton.SetActive(false);
                setInfo(31);
                break;
            case "flor":
            case "Flor":
                escreverNoDiario(32, "Coletaveis");
                downloadButton.SetActive(false);
                setInfo(32);
                break;
            case "floresta":
            case "Floresta":
                downloadButton.SetActive(false);
                setInfo(33);
                break;
            case "garras":
            case "Garras":
                escreverNoDiario(34, "Coletaveis");
                downloadButton.SetActive(false);
                setInfo(34);
                break;
            case "geraldo":
            case "Geraldo":
                downloadButton.SetActive(false);
                setInfo(35);
                break;
            case "italo":
            case "Italo":
                downloadButton.SetActive(false);
                setInfo(36);
                break;
            case "julio":
            case "Julio":
            case "julin":
            case "Julin":
            case "juliao":
            case "Juliao":
            case "julião":
            case "Julião":
            case "julio menes":
            case "Julio menes":
            case "Julio Menes":
                downloadButton.SetActive(false);
                setInfo(37);
                break;
            case "kael":
            case "Kael":
            case "kaelzada":
            case "Kaelzada":
                downloadButton.SetActive(false);
                setInfo(38);
                break;
            case "magmarus":
            case "Magmarus":
                escreverNoDiario(39, "Inimigos");
                downloadButton.SetActive(false);
                setInfo(39);
                break;
            case "matheus":
            case "Matheus":
            case "matheuzin":
            case "Matheuzin":
            case "Matheus, O Contraventor":
                
                downloadButton.SetActive(false);
                setInfo(40);
                break;
            case "maca":
            case "maça":
            case "maçã":
            case "Maca":
            case "Maça":
            case "Maçã":
                escreverNoDiario(41, "Coletaveis");
                downloadButton.SetActive(false);
                setInfo(41);
                break;
            case "mirtilo":
            case "Mirtilo":
                escreverNoDiario(42, "Coletaveis");
                downloadButton.SetActive(false);
                setInfo(42);
                break;
            case "morcego":
            case "Morcego":
            case "morcegos":
            case "Morcegos":
                escreverNoDiario(43, "Inimigos");
                downloadButton.SetActive(false);
                setInfo(43);
                break;
            case "nero":
            case "Nero":
                downloadButton.SetActive(false);
                setInfo(44);
                break;
            case "o alquimista":
            case "O alquimista":
            case "O Alquimista":
                downloadButton.SetActive(false);
                setInfo(45);
                break;
            case "olho":
            case "Olho":
            case "olhos":
            case "Olhos":
                escreverNoDiario(46, "Coletaveis");
                downloadButton.SetActive(false);
                setInfo(46);
                break;
            case "osso":
            case "Osso":
            case "ossos":
            case "Ossos":
                escreverNoDiario(47, "Coletaveis");
                downloadButton.SetActive(false);
                setInfo(47);
                break;
            case "pedregulho":
            case "Pedregulho":
                escreverNoDiario(48, "Inimigos");
                downloadButton.SetActive(false);
                setInfo(48);
                break;
            case "pimenta":
            case "Pimenta":
                escreverNoDiario(49, "Coletaveis");
                downloadButton.SetActive(false);
                setInfo(49);
                break;
            case "pompiros":
            case "Pompiros":
                downloadButton.SetActive(false);
                setInfo(50);
                break;
            case "pocao de cogumelos":
            case "Pocao de cogumelos":
            case "poção de cogumelos":
            case "Poção de cogumelos":
                escreverNoDiario(51, "Coletaveis");
                downloadButton.SetActive(false);
                setInfo(51);
                break;
            case "pocao de nectar":
            case "Pocao de nectar":
            case "poção de nectar":
            case "Poção de nectar":
                escreverNoDiario(52, "Coletaveis");
                downloadButton.SetActive(false);
                setInfo(52);
                break;
            case "eletromancia":
            case "Eletromancia":
                downloadButton.SetActive(true);
                setInfo(53);
                break;
            case "cryomancia":
            case "Cryomancia":
                downloadButton.SetActive(true);
                setInfo(54);
                break;
            case "toccyo ":
            case "Toccyo ":
                downloadButton.SetActive(true);
                setInfo(55);
                break;
            case "pantano":
            case "Pantano":
            case "pântano":
            case "Pântano":
                downloadButton.SetActive(false);
                setInfo(56);
                break;
            case "reagente":
            case "Reagente":
                escreverNoDiario(57, "Coletaveis");
                downloadButton.SetActive(false);
                setInfo(57);
                break;
            case "trovao aliado":
            case "Trovao aliado":
            case "trovão aliado":
            case "Trovão aliado":
                downloadButton.SetActive(true);
                setInfo(58);
                break;
            case "pyroprotecao":
            case "PyroProtecao":
            case "PyroProteção":
                downloadButton.SetActive(true);
                setInfo(59);
                break;
            //case "pão de batata":
            //    downloadButton.SetActive(true);
            //    setInfo(60);
            //    break;
            case "VenenoBoom":
            case "venenoboom":
                downloadButton.SetActive(true);
                setInfo(61);
                break;
            case "slime":
            case "Slime":
                escreverNoDiario(62, "Inimigos");
                downloadButton.SetActive(false);
                setInfo(62);
                break;
            case "sombralida":
            case "Sombralida":
                downloadButton.SetActive(false);
                setInfo(63);
                break;
            case "speilctre":
            case "Speilctre":
                escreverNoDiario(64, "Inimigos");
                downloadButton.SetActive(false);
                setInfo(64);
                break;
            case "suco de fruta":
            case "Suco de fruta":
            case "Suco de Fruta":
            case "Suco de frutas":
                escreverNoDiario(65, "Coletaveis");
                downloadButton.SetActive(false);
                setInfo(65);
                break;
            case "torfarios":
            case "Torfarios":
                escreverNoDiario(66, "Inimigos");
                downloadButton.SetActive(false);
                setInfo(66);
                break;
            case "U-800":
                downloadButton.SetActive(false);
                setInfo(67);
                break;
            case "U-800X":
                downloadButton.SetActive(false);
                setInfo(68);
                break;
            case "vila":
            case "Vila":
                downloadButton.SetActive(false);
                setInfo(69);
                break;
            case "vinicius":
            case "Vinicius":
            case "hirose":
            case "Hirose":
                downloadButton.SetActive(false);
                setInfo(70);
                break;
            case "vitor":
            case "vitin":
            case "o morto":
            case "O morto":
                downloadButton.SetActive(false);
                setInfo(71);
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
    void escreverNoDiario(int databasePosition, string lugar)
    {
        if (pesquisaDataBase.dadosEllgogs[databasePosition].itemObject != null)
        {
            diaryInfoController.SetInfo(pesquisaDataBase.dadosEllgogs[databasePosition].itemObject.nome,
            pesquisaDataBase.dadosEllgogs[databasePosition].itemObject.uiDisplay,
            pesquisaDataBase.dadosEllgogs[databasePosition].itemObject.description,
            lugar,
            pesquisaDataBase.dadosEllgogs[databasePosition].itemObject.type == ItemType.Crafting ? pesquisaDataBase.dadosEllgogs[databasePosition].itemObject.craftingItemType.ToString() : "Pocao");
        }
        else
        {
            diaryInfoController.SetInfo(pesquisaDataBase.dadosEllgogs[databasePosition].pesquisaTitle, 
                pesquisaDataBase.dadosEllgogs[databasePosition].image, 
                pesquisaDataBase.dadosEllgogs[databasePosition].description, lugar, "");        
        }
        
    }
}
