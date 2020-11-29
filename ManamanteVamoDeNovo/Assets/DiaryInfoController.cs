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
            case "Coletaveis":
                switch (Tipo)
                {
                    case "Fruta":
                        for (int i = 0; i < 4; i++)
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
                        for (int i = 4; i < 6; i++)
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
                        for (int i = 6; i < 9; i++)
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
                        for (int i = 9; i < 19; i++)
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
                        for (int i = 19; i < 36; i++)
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
                for (int i = 36; i < 54; i++)
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
                for (int i = 54; i < 66; i++)
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
