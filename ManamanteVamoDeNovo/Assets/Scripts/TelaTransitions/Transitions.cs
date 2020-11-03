using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transitions : MonoBehaviour
{

    public PlayerMovement player;
    public Health playerHealth;
    public Transform robo;
    public FakeLoading fakeLoading;
    public GameObject globalLight;
    public GameObject dayCycle;
    public GameObject chuva;
    // Start is called before the first frame update
    public string mapaAnterior;
    public GameObject mapaAtivo;
    public GameObject mapaDaEsquerda;
    public GameObject mapaDaDireita;
    public GameObject mapaDeCima;
    public GameObject mapaDeBaixo;
    public GameObject casaMera;

    public Transform chegadaEsquerda;
    public Transform chegadaDireita;
    public Transform chegadaCima;
    public Transform chegadaBaixo;

    public Transform casaMeraInstantPoint;



    public float transitionCooldown = 5;

    private void OnEnable()
    {
        StartCoroutine(LightsOut());
        fakeLoading.Fade(2f);
        switch (mapaAnterior)
        {
            case "SaidaEsquerda":
                player.transform.position = chegadaDireita.position;
                robo.position = chegadaDireita.position;
                break;
            case "SaidaDireita":
                player.transform.position = chegadaEsquerda.position;
                robo.position = chegadaDireita.position;
                break;
            case "SaidaCima":
                player.transform.position = chegadaBaixo.position;
                robo.position = chegadaBaixo.position;
                break;
            case "SaidaBaixo":
                player.transform.position = chegadaCima.position;
                robo.position = chegadaCima.position;
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(mapaAtivo.name == "CasaMera")
        {
            if (chuva.activeSelf)
            {
                chuva.SetActive(false);
            }
            if (globalLight.activeSelf)
            {
                globalLight.SetActive(false);
            }
        }
        else if(mapaAtivo.name == "FlorestaSombralida")
        {
            if (globalLight.activeSelf)
            {
                globalLight.SetActive(false);
            }
        }
        else
        {
            if (!globalLight.activeSelf)
            {
                globalLight.SetActive(true);
            }
        }
        transitionCooldown += Time.deltaTime;
        if (playerHealth.respawnPlayer)
        {
            StartCoroutine(LightsOut());
            fakeLoading.Fade(3f);
            mapaAtivo.SetActive(false);
            casaMera.SetActive(true);
            player.transform.position = casaMeraInstantPoint.position;
            robo.transform.position = casaMeraInstantPoint.position;
            transitionCooldown = 0;
            dayCycle.SetActive(true);
            playerHealth.respawnPlayer = false;
        }
        if(transitionCooldown< 5f)
        {
            return;
        }
    }

    public void SaidaUsada(string direcao)
    {
        switch (direcao)
        {
            case "SaidaEsquerda":
                mapaAtivo.SetActive(false);
                mapaDaEsquerda.GetComponentInChildren<Transitions>().mapaAnterior = direcao;
                mapaDaEsquerda.SetActive(true);
                break;
            case "SaidaDireita":
                mapaAtivo.SetActive(false);
                mapaDaDireita.GetComponentInChildren<Transitions>().mapaAnterior = direcao;
                mapaDaDireita.SetActive(true); 
                break;
            case "SaidaCima":
                mapaAtivo.SetActive(false);
                mapaDeCima.GetComponentInChildren<Transitions>().mapaAnterior = direcao;
                mapaDeCima.SetActive(true);
                break;
            case "SaidaBaixo":
                mapaAtivo.SetActive(false);
                mapaDeBaixo.GetComponentInChildren<Transitions>().mapaAnterior = direcao;
                mapaDeBaixo.SetActive(true);
                break;
        }
    }
    IEnumerator LightsOut()
    {
        globalLight.SetActive(false);
        yield return new WaitForSeconds(1f);
        playerHealth.gameObject.SetActive(true);
    }
}
