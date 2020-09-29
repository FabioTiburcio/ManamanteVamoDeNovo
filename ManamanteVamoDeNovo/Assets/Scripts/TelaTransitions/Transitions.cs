using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transitions : MonoBehaviour
{

    public PlayerMovement player;
    public Transform robo;
    // Start is called before the first frame update
    public GameObject cidadePrincipal;
    public GameObject FlorestaSombralida;
    public GameObject casaMera;

    public Transform cidadeInstantPoint;
    public Transform sombralidaInstantPoint;
    public Transform casaMeraInstantPoint;

    public ColliderTransition sombralidaCTransition;
    public ColliderTransition cidadeSTransition;
    public ColliderTransition cidadeCTransition;
    public ColliderTransition casaCTransition;

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
            cidadePrincipal.SetActive(false);
            FlorestaSombralida.SetActive(true);
            player.transform.position = sombralidaInstantPoint.position;
            robo.transform.position = sombralidaInstantPoint.position;
            cidadeSTransition.playerCollided = false;
            transitionCooldown = 0;
        }
        else if(sombralidaCTransition.playerCollided)
        {
            FlorestaSombralida.SetActive(false);
            cidadePrincipal.SetActive(true);
            player.transform.position = cidadeInstantPoint.position;
            robo.transform.position = cidadeInstantPoint.position;
            sombralidaCTransition.playerCollided = false;
            transitionCooldown = 0;
        }
        else if (cidadeCTransition.playerCollided)
        {
            cidadePrincipal.SetActive(false);
            casaMera.SetActive(true);
            player.transform.position = casaMeraInstantPoint.position;
            robo.transform.position = casaMeraInstantPoint.position;
            cidadeCTransition.playerCollided = false;
            transitionCooldown = 0;
        }
        else if (casaCTransition.playerCollided)
        {
            casaMera.SetActive(false);
            cidadePrincipal.SetActive(true);
            player.transform.position = cidadeInstantPoint.position;
            robo.transform.position = cidadeInstantPoint.position;
            casaCTransition.playerCollided = false;
            transitionCooldown = 0;
        }
    }
}
