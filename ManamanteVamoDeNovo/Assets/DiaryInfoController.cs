using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiaryInfoController : MonoBehaviour
{
    public PrefabInfos[] infosInPagesPrefabs;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetInfo(string title , Sprite image, string description, string Pagina, string Tipo)
    {
        switch (Pagina)
        {
            case "Anotacoes":
                for (int i = 0; i < 12; i++)
                {
                    if (infosInPagesPrefabs[i].imageSprite.sprite == null)
                    {
                        infosInPagesPrefabs[i].Title.text = title;
                        infosInPagesPrefabs[i].imageSprite.sprite = image;
                        infosInPagesPrefabs[i].Description.text = description;
                        infosInPagesPrefabs[i].gameObject.SetActive(true);
                        break;
                    }
                    else
                    {
                        if (infosInPagesPrefabs[i].Title.text == title)
                        {
                            break;
                        }
                    }
                }
                break;
            case "Tarefas":
                switch (Tipo)
                {
                    case "Primaria":
                        for (int i = 12; i < 24; i++)
                        {
                            if (infosInPagesPrefabs[i].imageSprite.sprite == null)
                            {
                                infosInPagesPrefabs[i].Title.text = title;
                                infosInPagesPrefabs[i].imageSprite.sprite = image;
                                infosInPagesPrefabs[i].Description.text = description;
                                infosInPagesPrefabs[i].gameObject.SetActive(true);
                                break;
                            }
                            else
                            {
                                if (infosInPagesPrefabs[i].Title.text == title)
                                {
                                    break;
                                }
                            }
                        }

                        break;
                    case "Secundaria":
                        break;
                }
                break;
            case "Coletaveis":
                switch (Tipo)
                {
                    case "Fruta":
                        for (int i = 24; i < 27; i++)
                        {
                            if (infosInPagesPrefabs[i].imageSprite.sprite == null)
                            {
                                infosInPagesPrefabs[i].Title.text = title;
                                infosInPagesPrefabs[i].imageSprite.sprite = image;
                                infosInPagesPrefabs[i].Description.text = description;
                                infosInPagesPrefabs[i].gameObject.SetActive(true);
                                break;
                            }
                            else
                            {
                                if (infosInPagesPrefabs[i].Title.text == title)
                                {
                                    break;
                                }
                            }
                        }
                        break;
                    case "Flor":
                        for (int i = 27; i < 30; i++)
                        {
                            if (infosInPagesPrefabs[i].imageSprite.sprite == null)
                            {
                                infosInPagesPrefabs[i].Title.text = title;
                                infosInPagesPrefabs[i].imageSprite.sprite = image;
                                infosInPagesPrefabs[i].Description.text = description;
                                infosInPagesPrefabs[i].gameObject.SetActive(true);
                                break;
                            }
                            else
                            {
                                if (infosInPagesPrefabs[i].Title.text == title)
                                {
                                    break;
                                }
                            }
                        }
                        break;
                    case "Cogumelo":
                        for (int i = 30; i < 33; i++)
                        {
                            if (infosInPagesPrefabs[i].imageSprite.sprite == null)
                            {
                                infosInPagesPrefabs[i].Title.text = title;
                                infosInPagesPrefabs[i].imageSprite.sprite = image;
                                infosInPagesPrefabs[i].Description.text = description;
                                infosInPagesPrefabs[i].gameObject.SetActive(true);
                                break;
                            }
                            else
                            {
                                if (infosInPagesPrefabs[i].Title.text == title)
                                {
                                    break;
                                }
                            }
                        }
                        break;
                    case "Partes":
                        for (int i = 33; i < 45; i++)
                        {
                            if (infosInPagesPrefabs[i].imageSprite.sprite == null)
                            {
                                infosInPagesPrefabs[i].Title.text = title;
                                infosInPagesPrefabs[i].imageSprite.sprite = image;
                                infosInPagesPrefabs[i].Description.text = description;
                                infosInPagesPrefabs[i].gameObject.SetActive(true);
                                break;
                            }
                            else
                            {
                                if (infosInPagesPrefabs[i].Title.text == title)
                                {
                                    break;
                                }
                            }
                        }
                        break;
                    case "Pocao":
                        for (int i = 45; i < 48; i++)
                        {
                            if (infosInPagesPrefabs[i].imageSprite.sprite == null)
                            {
                                infosInPagesPrefabs[i].Title.text = title;
                                infosInPagesPrefabs[i].imageSprite.sprite = image;
                                infosInPagesPrefabs[i].Description.text = description;
                                infosInPagesPrefabs[i].gameObject.SetActive(true);
                                break;
                            }
                            else
                            {
                                if (infosInPagesPrefabs[i].Title.text == title)
                                {
                                    break;
                                }
                            }
                        }
                        break;
                }
                break;
            case "Inimigos":
                for (int i = 48; i < 66; i++)
                {
                    if (infosInPagesPrefabs[i].imageSprite.sprite == null)
                    {
                        infosInPagesPrefabs[i].Title.text = title;
                        infosInPagesPrefabs[i].imageSprite.sprite = image;
                        infosInPagesPrefabs[i].Description.text = description;
                        infosInPagesPrefabs[i].gameObject.SetActive(true);
                        break;
                    }
                    else
                    {
                        if (infosInPagesPrefabs[i].Title.text == title)
                        {
                            break;
                        }
                    }
                }
                break;
            case "Mapa":
                break;
            case "Dicas":
                for (int i = 72; i < 84; i++)
                {
                    if (infosInPagesPrefabs[i].imageSprite.sprite == null)
                    {
                        infosInPagesPrefabs[i].Title.text = title;
                        infosInPagesPrefabs[i].imageSprite.sprite = image;
                        infosInPagesPrefabs[i].Description.text = description;
                        infosInPagesPrefabs[i].gameObject.SetActive(true);
                        break;
                    }
                    else
                    {
                        if (infosInPagesPrefabs[i].Title.text == title)
                        {
                            break;
                        }
                    }
                }
                break;
        }
    }
}
