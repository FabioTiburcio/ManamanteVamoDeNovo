using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transitions : MonoBehaviour
{

    public PlayerMovement player;
    public Health playerHealth;
    public PlayerQuest activeQuest;
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

    public AudioSource sombralidaAudio;
    public AudioSource criogenicasAudio;

    public float transitionCooldown = 5;

    public LoadingImageChanger loadingImageChanger;

    private void OnEnable()
    {

        activeQuest = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerQuest>();

        StartCoroutine(LightsOut());
        fakeLoading.Fade();
        switch (mapaAnterior)
        {
            case "SaidaEsquerda":
                player.transform.position = chegadaDireita.position;
                robo.position = chegadaDireita.position;
                break;
            case "SaidaDireita":
                player.transform.position = chegadaEsquerda.position;
                robo.position = chegadaEsquerda.position;
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

        if (mapaAtivo.tag == "MapaGelo")
        {
            criogenicasAudio.Play();
            activeQuest.QuestAtt("Criogenicas", true);
        }
        else
        {
            criogenicasAudio.Stop();
        }
    }
    // Update is called once per frame
    void Update()
    {
        ChangeLoadingFundo();
        if(mapaAtivo.name == "CasaMera")
        {
            if (chuva.activeSelf)
            {
                chuva.GetComponent<ParticleSystem>().Pause();
            }
            if (globalLight.activeSelf)
            {
                globalLight.SetActive(false);
            }
        }
        else if(mapaAtivo.name == "FlorestaSombralida1" || mapaAtivo.name == "FlorestaSombralida2" || mapaAtivo.name == "FlorestaSombralida3" || mapaAtivo.name == "FlorestaSombralida4" || mapaAtivo.name == "FlorestaSombralida5")
        {
            if (globalLight.activeSelf)
            {
                globalLight.SetActive(false);
            }
        }
        else if (mapaAtivo.name == "TorfariosBattle")
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
                chuva.GetComponent<ParticleSystem>().Play();
            }
        }

        
        transitionCooldown += Time.deltaTime;
        if (playerHealth.respawnPlayer)
        {
            StartCoroutine(timeToSpawnPlayer());
        }
        if(transitionCooldown< 5f)
        {
            return;
        }
    }

    public void ChangeLoadingFundo()
    {
        string fundo = mapaAtivo.name;
        switch (fundo)
        {
            case "CasaMera":
                loadingImageChanger.changeImage("Vila");
                break;
            case "VilaMera":
                loadingImageChanger.changeImage("Vila");
                break;
            case "Fazenda":
                loadingImageChanger.changeImage("Floresta");
                break;
            case "FlorestaSombralida1":
                loadingImageChanger.changeImage("Sombralida");
                break;
            case "TorfariosBattle":
                loadingImageChanger.changeImage("Sombralida");
                break;
            case "FlorestaSombralida2":
                loadingImageChanger.changeImage("Sombralida");
                break;
            case "Floresta Gelo":
                loadingImageChanger.changeImage("Criogenicas");
                break;
            case "Cidade Gelo":
                loadingImageChanger.changeImage("Criogenicas");
                break;
            case "Floresta1":
                loadingImageChanger.changeImage("Floresta");
                break;
            case "Floresta2":
                loadingImageChanger.changeImage("Floresta");
                break;
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
    IEnumerator timeToSpawnPlayer()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(LightsOut());
        fakeLoading.Fade();
        mapaAtivo.SetActive(false);
        casaMera.SetActive(true);
        player.transform.position = casaMeraInstantPoint.position;
        robo.transform.position = casaMeraInstantPoint.position;
        transitionCooldown = 0;
        dayCycle.SetActive(true);
        playerHealth.respawnPlayer = false;
    }

    IEnumerator LightsOut()
    {
        globalLight.SetActive(false);
        yield return new WaitForSeconds(1f);
        playerHealth.gameObject.SetActive(true);
    }
}
