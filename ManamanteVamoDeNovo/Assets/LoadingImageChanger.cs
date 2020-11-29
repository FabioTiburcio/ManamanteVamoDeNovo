using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingImageChanger : MonoBehaviour
{
    public Image FundoImage;
    public Sprite fundoSombralida;
    public Sprite fundoFloresta;
    public Sprite fundoVila;
    public Sprite fundoCriogenicas;
    public Sprite fundoPompiros;
    public Sprite fundoPantano;

    public void changeImage(string fundo)
    {
        switch (fundo)
        {
            case "Sombralida":
                FundoImage.sprite = fundoSombralida;
                break;
            case "Floresta":
                FundoImage.sprite = fundoFloresta;
                break;
            case "Vila":
                FundoImage.sprite = fundoVila;
                break;
            case "Criogenicas":
                FundoImage.sprite = fundoCriogenicas;
                break;
            case "Pompiros":
                FundoImage.sprite = fundoPompiros;
                break;
            case "Pantano":
                FundoImage.sprite = fundoPantano;
                break;
        }
    }

}
