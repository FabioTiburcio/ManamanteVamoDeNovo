using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DadosPesquisa", menuName = "Pesquisa/DadosPesquisa")]
public class DadosEllgog : ScriptableObject
{
    public string pesquisaTitle;
    public Sprite image;
    [TextArea(10, 10)]
    public string description;
    public ItemObject itemObject;
    public DadosEllgog similarLink;
    public DadosEllgog similarLink2;
}
