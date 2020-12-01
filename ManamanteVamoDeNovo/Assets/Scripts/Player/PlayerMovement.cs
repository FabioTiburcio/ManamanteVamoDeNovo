using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;

    public SkillController skillController;
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

    public bool upgradedRobo;
    public PetMovement pet;

    public AudioClip[] pcSounds;

    private int questsCompleted;

    //Footsteps
    public float footStepRatePlay;
    AudioSource playerAudioSource;
    public AudioClip[] footSteps;
    public AudioClip[] footStepsGrass;
    public AudioClip[] footStepsWood;
    public AudioClip[] footStepsSnow;
    public AudioClip[] footStepsGround;
    public float timer;

    private void Start()
    {
        playerAudioSource = gameObject.GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        movement.x = 0;
        movement.y = 0;
        if (upgradedRobo)
        {
            pet.miniRobo.SetActive(false);
            pet.robozao.SetActive(true);
        }
    }

    private void Update()
    {
        questsCompleted = PlayerPrefs.GetInt("QuestsCompleted");
        if (questsCompleted == 7) upgradedRobo = true;

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (freezePlayer)
        {
            movement.x = 0;
            movement.y = 0;
            if (skillController.isShotting)
            {
                if(skillController.activeSkill == 3)
                {
                    playerAnim.SetBool("RaioAttack", true);
                }
                else
                {
                    playerAnim.SetBool("Attacking", true);
                }
                
            }
            return;
        }

        

        else
        {
            movement.x = Input.GetAxis("Horizontal");           
            movement.y = Input.GetAxis("Vertical");
            playerAnim.SetFloat("X", movement.x);
            playerAnim.SetFloat("Y", movement.y);
        }
        playerAnim.SetBool("Attacking", false);
        playerAnim.SetBool("RaioAttack", false);
        if (movement.x != 0 || movement.y != 0)
        {
            
            playerAnim.SetBool("Walking", true);
            
        }
        else
        {
            playerAnim.SetBool("Walking", false);
            
        }
        

        if (computerRange && Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if (computerScreen.activeSelf)
            {
                
                computerScreen.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                playerAudioSource.PlayOneShot(pcSounds[0]);
                computerScreen.SetActive(true);
                Time.timeScale = 0;
            }
        }

        
    }

    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + movement * movementSpeed * Time.deltaTime);
        if((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && !freezePlayer)
        {
            //freezePlayer = false;
            if (Time.time > timer)
            {
                timer = Time.time + 1 / footStepRatePlay;
                FootStepRandomize();
            }
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            //freezePlayer = true;
        }

        

        lookDir = mousePos - playerRb.position;
        if(lookDir.x > 0)
        {
            spr.flipX = false;
            //skillController.transform.position = new Vector3(skillController.transform.position.x, skillController.transform.position.y, skillController.transform.position.z);
        }
        else
        {
            spr.flipX = true;
            //skillController.transform.position = new Vector3(-skillController.transform.position.x, skillController.transform.position.y, skillController.transform.position.z);
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

        if (collision.gameObject.tag == "Grass")
        {
            footSteps = footStepsGrass;
            footStepRatePlay = 1.8f;
        }

        if (collision.gameObject.tag == "Snow")
        {
            footSteps = footStepsSnow;
            footStepRatePlay = 2;
        }

        if (collision.gameObject.tag == "Wood")
        {
            footSteps = footStepsWood;
            footStepRatePlay = 1.8f;
        }

        if (collision.gameObject.tag == "Ground")
        {
            footSteps = footStepsGround;
            footStepRatePlay = 1.8f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Computer" || collision.name == "Robo" && upgradedRobo)
        {
            computerRange = false;
        }
    }

    void FootStepRandomize()
    {
        AudioClip soundToPlay = footSteps[Random.Range(0, footSteps.Length)];
        playerAudioSource.PlayOneShot(soundToPlay);
    }
}
