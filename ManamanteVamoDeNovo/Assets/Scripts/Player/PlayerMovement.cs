using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    
    private Rigidbody2D playerRb;
    private Animator playerAnim;

    Vector2 movement;
    public Vector2 mousePos;
    public Vector2 lookDir;
    public Transform skillSpawnRotation;

    public bool freezePlayer;

    public string colliderTag;

    public bool computerRange;
    public GameObject computerScreen;

    public bool upgradedRobo = true;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (freezePlayer)
        {
            return;
        }
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + movement * movementSpeed * Time.deltaTime);

        lookDir = mousePos - playerRb.position;
        skillSpawnRotation.transform.up = lookDir;
        if(computerRange && Input.GetKeyDown(KeyCode.C))
        {
            if (computerScreen.activeSelf)
            {
                computerScreen.SetActive(false);
            }
            else
            {
                computerScreen.SetActive(true);
            }

        }
        //transform.up = lookDir.normalized;
        //float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        //playerRb.rotation = angle;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(mousePos, 0.05f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Computer" || collision.name == "Robo" && upgradedRobo)
        {
            computerRange = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Computer" || collision.name == "Robo" && upgradedRobo)
        {
            computerRange = false;
        }
    }
}
