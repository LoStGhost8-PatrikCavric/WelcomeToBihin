using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    private Vector3 directionVector;
    private Transform myTransform;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Animator anim;
    public Collider2D bounds;

    Vector3 playerPos, npcPos;
    //Vector3 delta = new Vector3(player);
    public float width, height;
    public LayerMask whatIsPlayer;

    void Start()
    {
        npcPos = transform.position;
        anim = GetComponent<Animator>();
        myTransform = GetComponent<Transform>();
        myRigidbody = GetComponent<Rigidbody2D>();
        ChangeDirection();
    }

    void Update()
    {
        //if (!playerInRange)
        //{
            
        //    Move();
        //}
        if (CheckForPlayer())
        {
            Debug.Log("player in range");
            LookAtPlayer();
        }
        
    }
    //void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireCube(npcPos, new Vector3(width, height, 1));
    //}
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(npcPos, new Vector3(width, height, 1));
    }

    bool CheckForPlayer()
    {
        bool playerDetected = Physics2D.OverlapBox(npcPos, new Vector2(width, height), 0, whatIsPlayer);

        return playerDetected;
    }
    void LookAtPlayer()
    {
        
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 delta = new Vector3(playerPos.x - npcPos.x, playerPos.y - npcPos.y, 0.0f);
        delta = delta.normalized;
        //Debug.Log(delta);
        //Quaternion rotation = Quaternion.LookRotation(delta);

        //gameObject.transform.rotation = rotation;
        if (delta.y <0  && delta.y < delta.x)
        {
           // Debug.Log("down");
            anim.SetFloat("LookDir", 1f);
        }
        else if (delta.x > 0 && delta.y < delta.x)
        {
            //Debug.Log("right");
            anim.SetFloat("LookDir", 2f);
        }
        else if (delta.y >0 && delta.y > delta.x)
        {
           // Debug.Log("up");
            anim.SetFloat("LookDir", 3f);
        }
        else if (delta.x < 0 && delta.y > delta.x)
        {
            //Debug.Log("left");
            anim.SetFloat("LookDir", 4f);
        }

    }
    private void Move()
    {
        Vector3 temp = myTransform.position + directionVector * speed * Time.deltaTime;
        if (bounds.bounds.Contains(temp))
        {
            myRigidbody.MovePosition(temp);
        }
        else
        {
            ChangeDirection();
        }

    }
    void ChangeDirection()
    {
        int direction = Random.Range(0, 4);
        switch (direction)
        {
            case 0:
                directionVector = Vector3.right;
                break;
            case 1:
                directionVector = Vector3.up;
                break;
            case 2:
                directionVector = Vector3.left;
                break;
            case 3:
                directionVector = Vector3.down;
                break;
            default:
                break;
        }
        UpdateAnimation();
    }

    void UpdateAnimation()
    {
        anim.SetFloat("MoveX", directionVector.x);
        anim.SetFloat("MoveY", directionVector.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector3 temp = directionVector;
        ChangeDirection();
        int loops = 0;
        while (temp == directionVector && loops < 100)
        {
            loops++;
            ChangeDirection();
        }
    }


}


