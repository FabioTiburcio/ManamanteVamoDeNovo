using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryController : MonoBehaviour
{
    public GameObject diary;

    public GameObject[] capasCostas;
    public GameObject[] capasFrente;
    public GameObject[] paginas;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < capasCostas.Length; i++)
        {
            capasCostas[i].SetActive(false);
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (diary.activeSelf)
            {
                diary.SetActive(false);
            }
            else
            {
                diary.SetActive(true);
                for (int i = 0; i < capasCostas.Length; i++)
                {
                    capasCostas[i].SetActive(false);
                }
            }
        }
    }

    public void Anotacoes()
    {
        for (int i = 0; i < paginas.Length; i++)
        {
            paginas[i].SetActive(false);
        }

        for (int i = 0; i < capasCostas.Length; i++)
        {
            capasCostas[i].SetActive(false);
        }
        for (int i = 0; i < capasFrente.Length; i++)
        {
            capasFrente[i].SetActive(true);
        }
    }

    public void Tarefas()
    {
        for (int i = 0; i < paginas.Length; i++)
        {
            paginas[i].SetActive(false);
        }

        for (int i = 0; i < capasCostas.Length; i++)
        {
            if (i == 0)
            {
                capasCostas[i].SetActive(true);
            }
            else
            {
                capasCostas[i].SetActive(false);
            }
        }

        for (int i = 0; i < capasFrente.Length; i++)
        {
            if (i == 5)
            {
                capasFrente[i].SetActive(false);
            }
            else
            {
                capasFrente[i].SetActive(true);
            }
        }
    }
    public void Coletaveis()
    {
        for (int i = 0; i < paginas.Length; i++)
        {
            paginas[i].SetActive(false);
        }

        for (int i = 0; i < capasCostas.Length; i++)
        {
            if (i == 0 || i == 1)
            {
                capasCostas[i].SetActive(true);
            }
            else
            {
                capasCostas[i].SetActive(false);
            }
        }
        for (int i = 0; i < capasFrente.Length; i++)
        {
            if (i == 5 || i == 4)
            {
                capasFrente[i].SetActive(false);
            }
            else
            {
                capasFrente[i].SetActive(true);
            }
        }
    }
    public void Inimigos()
    {
        for (int i = 0; i < paginas.Length; i++)
        {
            paginas[i].SetActive(false);
        }

        for (int i = 0; i < capasCostas.Length; i++)
        {
            if (i == 0 || i == 1 || i == 2)
            {
                capasCostas[i].SetActive(true);
            }
            else
            {
                capasCostas[i].SetActive(false);
            }
        }
        for (int i = 0; i < capasFrente.Length; i++)
        {
            if (i == 5 || i == 4 || i == 3)
            {
                capasFrente[i].SetActive(false);
            }
            else
            {
                capasFrente[i].SetActive(true);
            }
        }
    }
    public void Mapa()
    {
        for (int i = 0; i < paginas.Length; i++)
        {
            paginas[i].SetActive(false);
        }

        for (int i = 0; i < capasCostas.Length; i++)
        {
            if (i == 0 || i == 1 || i == 2 || i == 3)
            {
                capasCostas[i].SetActive(true);
            }
            else
            {
                capasCostas[i].SetActive(false);
            }
        }
        for (int i = 0; i < capasFrente.Length; i++)
        {
            if (i == 5 || i == 4 || i == 3 || i == 2)
            {
                capasFrente[i].SetActive(false);
            }
            else
            {
                capasFrente[i].SetActive(true);
            }
        }
    }
    public void Dicas()
    {
        for (int i = 0; i < paginas.Length; i++)
        {
            paginas[i].SetActive(false);
        }

        for (int i = 0; i < capasCostas.Length; i++)
        {
            if (i == 0 || i == 1 || i == 2 || i == 3 || i == 4)
            {
                capasCostas[i].SetActive(true);
            }
            else
            {
                capasCostas[i].SetActive(false);
            }
        }
        for (int i = 0; i < capasFrente.Length; i++)
        {
            if (i == 5 || i == 4 || i == 3 || i == 2 || i == 1)
            {
                capasFrente[i].SetActive(false);
            }
            else
            {
                capasFrente[i].SetActive(true);
            }
        }
    }

    public void AllLeft()
    {
        for (int i = 0; i < paginas.Length; i++)
        {
            paginas[i].SetActive(false);
        }

        for (int i = 0; i < capasCostas.Length; i++)
        {
            capasCostas[i].SetActive(true);
        }
        for (int i = 0; i < capasFrente.Length; i++)
        {
            capasFrente[i].SetActive(false);
        }
    }

    public void PageChanger(string pageClicked)
    {
        switch (pageClicked)
        {
            case "Anotacoes":
                Tarefas();
                for (int i = 0; i < paginas.Length; i++)
                {
                    if (i == 0 || i == 1)
                    {
                        paginas[i].SetActive(true);
                    }
                    else
                    {
                        paginas[i].SetActive(false);
                    }
                }
                break;
            case "Tarefas":
                Coletaveis();
                for (int i = 0; i < paginas.Length; i++)
                {
                    if (i == 4 || i == 5)
                    {
                        paginas[i].SetActive(true);
                    }
                    else
                    {
                        paginas[i].SetActive(false);
                    }
                }
                break;
            case "Coletaveis":
                Inimigos();
                for (int i = 0; i < paginas.Length; i++)
                {
                    if (i == 8 || i == 9)
                    {
                        paginas[i].SetActive(true);
                    }
                    else
                    {
                        paginas[i].SetActive(false);
                    }
                }
                break;
            case "Inimigos":
                Mapa();
                for (int i = 0; i < paginas.Length; i++)
                {
                    if (i == 16 || i == 17)
                    {
                        paginas[i].SetActive(true);
                    }
                    else
                    {
                        paginas[i].SetActive(false);
                    }
                }
                break;
            case "Mapa":
                Dicas();
                for (int i = 0; i < paginas.Length; i++)
                {
                    if (i == 22 || i == 23)
                    {
                        paginas[i].SetActive(true);
                    }
                    else
                    {
                        paginas[i].SetActive(false);
                    }
                }
                break;
            case "Dicas":
                AllLeft();
                for (int i = 0; i < paginas.Length; i++)
                {
                    if (i == 24 || i == 25)
                    {
                        paginas[i].SetActive(true);
                    }
                    else
                    {
                        paginas[i].SetActive(false);
                    }
                }
                break;
            case "Pagina1":
                Anotacoes();
                break;
            case "Pagina2":
                for (int i = 0; i < paginas.Length; i++)
                {
                    if (i == 2 || i == 3)
                    {
                        paginas[i].SetActive(true);
                    }
                    else
                    {
                        paginas[i].SetActive(false);
                    }
                }
                break;
            case "Pagina3":
                for (int i = 0; i < paginas.Length; i++)
                {
                    if (i == 0 || i == 1)
                    {
                        paginas[i].SetActive(true);
                    }
                    else
                    {
                        paginas[i].SetActive(false);
                    }
                }
                break;
            case "Pagina4":
                Tarefas();
                break;
            case "Pagina5":
                Tarefas();
                break;
            case "Pagina6":
                for (int i = 0; i < paginas.Length; i++)
                {
                    if (i == 6 || i == 7)
                    {
                        paginas[i].SetActive(true);
                    }
                    else
                    {
                        paginas[i].SetActive(false);
                    }
                }
                break;
            case "Pagina7":
                for (int i = 0; i < paginas.Length; i++)
                {
                    if (i == 4 || i == 5)
                    {
                        paginas[i].SetActive(true);
                    }
                    else
                    {
                        paginas[i].SetActive(false);
                    }
                }
                break;
            case "Pagina8":
                Coletaveis();
                break;
            case "Pagina9":
                Coletaveis();
                break;
            case "Pagina10":
                for (int i = 0; i < paginas.Length; i++)
                {
                    if (i == 10 || i == 11)
                    {
                        paginas[i].SetActive(true);
                    }
                    else
                    {
                        paginas[i].SetActive(false);
                    }
                }
                break;
            case "Pagina11":
                for (int i = 0; i < paginas.Length; i++)
                {
                    if (i == 8 || i == 9)
                    {
                        paginas[i].SetActive(true);
                    }
                    else
                    {
                        paginas[i].SetActive(false);
                    }
                }
                break;
            case "Pagina12":
                for (int i = 0; i < paginas.Length; i++)
                {
                    if (i == 12 || i == 13)
                    {
                        paginas[i].SetActive(true);
                    }
                    else
                    {
                        paginas[i].SetActive(false);
                    }
                }
                break;
            case "Pagina13":
                for (int i = 0; i < paginas.Length; i++)
                {
                    if (i == 10 || i == 11)
                    {
                        paginas[i].SetActive(true);
                    }
                    else
                    {
                        paginas[i].SetActive(false);
                    }
                }
                break;
            case "Pagina14":
                for (int i = 0; i < paginas.Length; i++)
                {
                    if (i == 14 || i == 15)
                    {
                        paginas[i].SetActive(true);
                    }
                    else
                    {
                        paginas[i].SetActive(false);
                    }
                }
                break;
            case "Pagina15":
                for (int i = 0; i < paginas.Length; i++)
                {
                    if (i == 12 || i == 13)
                    {
                        paginas[i].SetActive(true);
                    }
                    else
                    {
                        paginas[i].SetActive(false);
                    }
                }
                break;
            case "Pagina16":
                Inimigos();
                break;
            case "Pagina17":
                Inimigos();
                break;
            case "Pagina18":
                for (int i = 0; i < paginas.Length; i++)
                {
                    if (i == 18 || i == 19)
                    {
                        paginas[i].SetActive(true);
                    }
                    else
                    {
                        paginas[i].SetActive(false);
                    }
                }
                break;
            case "Pagina19":
                for (int i = 0; i < paginas.Length; i++)
                {
                    if (i == 16 || i == 17)
                    {
                        paginas[i].SetActive(true);
                    }
                    else
                    {
                        paginas[i].SetActive(false);
                    }
                }
                break;
            case "Pagina20":
                for (int i = 0; i < paginas.Length; i++)
                {
                    if (i == 20 || i == 21)
                    {
                        paginas[i].SetActive(true);
                    }
                    else
                    {
                        paginas[i].SetActive(false);
                    }
                }
                break;
            case "Pagina21":
                for (int i = 0; i < paginas.Length; i++)
                {
                    if (i == 18 || i == 19)
                    {
                        paginas[i].SetActive(true);
                    }
                    else
                    {
                        paginas[i].SetActive(false);
                    }
                }
                break;
            case "Pagina22":
                Mapa();
                break;
            case "Pagina23":
                Mapa();
                break;
            case "Pagina24":
                Dicas();
                break;
            case "Pagina25":
                Dicas();
                break;
            case "Pagina26":
                for (int i = 0; i < paginas.Length; i++)
                {
                    if (i == 26 || i == 27)
                    {
                        paginas[i].SetActive(true);
                    }
                    else
                    {
                        paginas[i].SetActive(false);
                    }
                }
                break;
            case "Pagina27":
                for (int i = 0; i < paginas.Length; i++)
                {
                    if (i == 24 || i == 25)
                    {
                        paginas[i].SetActive(true);
                    }
                    else
                    {
                        paginas[i].SetActive(false);
                    }
                }
                break;
            case "Pagina28":
                AllLeft();
                for (int i = 0; i < paginas.Length; i++)
                {
                    paginas[i].SetActive(false);
                }
                break;
        }
    }
}
