using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryController : MonoBehaviour
{
    public GameObject diary;

    public GameObject[] capasCostas;
    public GameObject[] capasFrente;
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
}
