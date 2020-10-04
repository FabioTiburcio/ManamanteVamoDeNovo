using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transitions : MonoBehaviour
{

    public PlayerMovement player;
    public Transform robo;
    public FakeLoading fakeLoading;
    public GameObject globalLight;
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
        if(transitionCooldown< 5f)
        {
            return;
        }
        if (cidadeSTransition.playerCollided)
        {
            StartCoroutine(LightsOut());
            fakeLoading.Fade();
            cidadePrincipal.SetActive(false);
            FlorestaSombralida.SetActive(true);
            player.transform.position = sombralidaInstantPoint.position;
            robo.transform.position = sombralidaInstantPoint.position;
            cidadeSTransition.playerCollided = false;
            transitionCooldown = 0;

        }
        else if(sombralidaCTransition.playerCollided)
        {
            StartCoroutine(LightsOut());
            fakeLoading.Fade();
            FlorestaSombralida.SetActive(false);
            cidadePrincipal.SetActive(true);
            player.transform.position = cidadeInstantPoint.position;
            robo.transform.position = cidadeInstantPoint.position;
            sombralidaCTransition.playerCollided = false;
            transitionCooldown = 0;

        }
        else if (cidadeCTransition.playerCollided)
        {
            StartCoroutine(LightsOut());
            fakeLoading.Fade();
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
            fakeLoading.Fade();
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
            fakeLoading.Fade();
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
            fakeLoading.Fade();
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
    }
}
