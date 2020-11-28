using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PetMovement : MonoBehaviour
{

    AIDestinationSetter destinationSetter;
    AIPath aiPath;
    [SerializeField]
    float moveSpeed = 2f;

    [SerializeField]
    Transform[] waypoints;

    [SerializeField]
    public Transform playerTransform;

    private int waypointIndex = 0;
    private Transform petTransform;

    private Animator petAnim;
    private Vector2 directionPet;

    public GameObject miniRobo;
    public GameObject robozao;

    SpriteRenderer sprPet;
    // Start is called before the first frame update
    void Start()
    {
        petTransform = GetComponent<Transform>();
        petAnim = GetComponent<Animator>();
        destinationSetter = GetComponent<AIDestinationSetter>();
        aiPath = GetComponent<AIPath>();
        sprPet = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(playerTransform.position, petTransform.position);

        if (distance < 10 && distance > 0.3f)
        {
            destinationSetter.enabled = true;
            aiPath.canMove = true;
            petAnim.SetFloat("velocity", 1);
            directionPet = (playerTransform.position - petTransform.position).normalized;
            if (directionPet.x > 0)
            {
                //sprPet.flipX = true;
            }
            else
            {
                //sprPet.flipX = false;
            }
            ////enemyAnim.SetFloat("EnemyDirectionX", directionEnemy.x);
            ////enemyAnim.SetFloat("EnemyDirectionY", directionEnemy.y);
            
        }
        //Se o inimigo chegou na distancia de só ficar parado
        else if (distance <= 0.3f)
        {
            petAnim.SetFloat("velocity", 0);
            aiPath.canMove = false;
            destinationSetter.enabled = false;
            petTransform.position = this.transform.position;
        }
    }
}
