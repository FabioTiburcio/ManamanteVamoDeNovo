using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    
    private Rigidbody2D playerRb;
    private SpriteRenderer spr;
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
        spr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (freezePlayer)
        {
            return;
        }
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        if(movement.x != 0 || movement.y != 0)
        {
            playerAnim.SetBool("Walking", true);
        }
        else
        {
            playerAnim.SetBool("Walking", false);
        }
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (computerRange && Input.GetKeyDown(KeyCode.C))
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
    }

    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + movement * movementSpeed * Time.deltaTime);
        lookDir = mousePos - playerRb.position;
        if(lookDir.x > 0)
        {
            spr.flipX = false;
        }
        else
        {
            spr.flipX = true;
        }
        skillSpawnRotation.transform.up = lookDir;
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
