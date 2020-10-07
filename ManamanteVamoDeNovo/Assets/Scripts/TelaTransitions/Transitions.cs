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
    // Start is called before the first frame update
    public GameObject cidadePrincipal;
    public GameObject FlorestaSombralida;
    public GameObject casaMera;
    public GameObject fazenda;

    public Transform cidadeInstantPoint;
    public Transform sombralidaInstantPoint;
    public Transform casaMeraInstantPoint;
    public Transform fazendaInstantPoint;

    public ColliderTransition sombralidaCTransition;
    public ColliderTransition cidadeSTransition;
    public ColliderTransition cidadeCTransition;
    public ColliderTransition cidadeFTransition;
    public ColliderTransition casaCTransition;
    public ColliderTransition fazendaCTransition;

    public float transitionCooldown = 5;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transitionCooldown += Time.deltaTime;
        if (playerHealth.respawnPlayer)
        {
            StartCoroutine(LightsOut());
            fakeLoading.Fade(3f);
            cidadePrincipal.SetActive(false);
            FlorestaSombralida.SetActive(false);
            fazenda.SetActive(false);
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
        if (cidadeSTransition.playerCollided)
        {
            StartCoroutine(LightsOut());
            fakeLoading.Fade(1f);
            cidadePrincipal.SetActive(false);
            FlorestaSombralida.SetActive(true);
            player.transform.position = sombralidaInstantPoint.position;
            robo.transform.position = sombralidaInstantPoint.position;
            cidadeSTransition.playerCollided = false;
            transitionCooldown = 0;
            dayCycle.SetActive(false);

        }
        else if(sombralidaCTransition.playerCollided)
        {
            StartCoroutine(LightsOut());
            fakeLoading.Fade(1f);
            FlorestaSombralida.SetActive(false);
            cidadePrincipal.SetActive(true);
            player.transform.position = cidadeInstantPoint.position;
            robo.transform.position = cidadeInstantPoint.position;
            sombralidaCTransition.playerCollided = false;
            transitionCooldown = 0;
            dayCycle.SetActive(true);
        }
        else if (cidadeCTransition.playerCollided)
        {
            StartCoroutine(LightsOut());
            fakeLoading.Fade(1f);
            cidadePrincipal.SetActive(false);
            casaMera.SetActive(true);
            player.transform.position = casaMeraInstantPoint.position;
            robo.transform.position = casaMeraInstantPoint.position;
            cidadeCTransition.playerCollided = false;
            transitionCooldown = 0;

        }
        else if (casaCTransition.playerCollided)
        {
            StartCoroutine(LightsOut());
            fakeLoading.Fade(1f);
            casaMera.SetActive(false);
            cidadePrincipal.SetActive(true);
            player.transform.position = cidadeInstantPoint.position;
            robo.transform.position = cidadeInstantPoint.position;
            casaCTransition.playerCollided = false;
            transitionCooldown = 0;

        }
        else if (cidadeFTransition.playerCollided)
        {
            StartCoroutine(LightsOut());
            fakeLoading.Fade(1f);
            cidadePrincipal.SetActive(false);
            fazenda.SetActive(true);
            player.transform.position = fazendaInstantPoint.position;
            robo.transform.position = fazendaInstantPoint.position;
            cidadeFTransition.playerCollided = false;
            transitionCooldown = 0;

        }
        else if (fazendaCTransition.playerCollided)
        {
            StartCoroutine(LightsOut());
            fakeLoading.Fade(1f);
            fazenda.SetActive(false);
            cidadePrincipal.SetActive(true);
            player.transform.position = cidadeInstantPoint.position;
            robo.transform.position = cidadeInstantPoint.position;
            cidadeFTransition.playerCollided = false;
            transitionCooldown = 0;

        }
    }
    IEnumerator LightsOut()
    {
        globalLight.SetActive(false);
        yield return new WaitForSeconds(1f);
        globalLight.SetActive(true);
        playerHealth.gameObject.SetActive(true);
    }
}
