using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DicasLoading : MonoBehaviour
{
    public Text dicasText;
    public Text carregandoText;

    public string[] dicasData;

    float timeToChangeCarregando;

    public void Update()
    {
        timeToChangeCarregando += Time.deltaTime;
        if (timeToChangeCarregando < 1)
        {
            carregandoText.text = "Carregando.";
        }
        else if(timeToChangeCarregando >= 1 && timeToChangeCarregando < 2)
        {
            carregandoText.text = "Carregando..";
        }
        else if(timeToChangeCarregando >= 2 && timeToChangeCarregando < 3)
        {
            carregandoText.text = "Carregando...";
        }
        else if (timeToChangeCarregando >= 3)
        {
            timeToChangeCarregando = 0;
        }
    }

    public void DicasRandomizer()
    {
        int randomNumber = Random.Range(0, dicasData.Length);
        dicasText.text = dicasData[randomNumber];
    }
}
