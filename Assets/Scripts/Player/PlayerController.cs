using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float acceleration;
    [SerializeField] private float topSpeed;
    [SerializeField] private float drag;

    private float speed;
    private Vector2 playerInput;

    [Header("References")]
    [SerializeField]private Animator anim;
    [SerializeField] private SpriteRenderer spriteRenderer;

    void Start()
    {
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame


    private void FixedUpdate()
    {
        Walk();
    }

    void Update()
    {
        SetInput();
        flipX();
    }

    private void Walk()
    {
        anim.SetBool("isWalking", playerInput.magnitude > 0.1f);


        transform.Translate(playerInput.normalized * topSpeed * Time.deltaTime);
    }

    private void flipX()
    {
        if(playerInput.x < -0.1f)
        {
            spriteRenderer.flipX = true;
        }else if(playerInput.x > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        
    }

    private void SetInput()
    {
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = Input.GetAxis("Vertical");
    }
}
