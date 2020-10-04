using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiaryInfoController : MonoBehaviour
{
    public PrefabInfos[] infosInPagesPrefabs;
    public Sprite testImage;
    
    // Start is called before the first frame update
    void Start()
    {
        SetInfo("Batata", testImage, "De comer bem bom fritinha", "Anotacoes", "");
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
                for (int i = 0; i < infosInPagesPrefabs.Length; i++)
                {
                    
                }
                break;
            case "Tarefas":
                switch (Tipo)
                {
                    case "Primaria":
                        break;
                    case "Secundaria":
                        break;
                }
                break;
            case "Coletaveis":
                switch (Tipo)
                {
                    case "Fruta":
                        break;
                    case "Flor":
                        break;
                    case "Cogumelo":
                        break;
                    case "Partes":
                        break;
                }
                break;
            case "Inimigos":
                break;
            case "Mapa":
                break;
            case "Dicas":
                break;
        }
    }
}
