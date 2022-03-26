using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    public Rigidbody2D rb;

    private Vector2 input;

    public Animator anim;

    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Horizontal", input.x);
        anim.SetFloat("Vertical", input.y);
        anim.SetFloat("Speed", input.sqrMagnitude);

        
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + input * moveSpeed * Time.fixedDeltaTime);
    }

    public void AddPumpkins(int value)
    {
        GameManager.Instance.pumpkin += value;
        GameManager.Instance.GameUI.transform.Find("PumpkinText").GetComponent<Text>().text = "Pumpkins collected: " + GameManager.Instance.pumpkin;
    }


    
}

