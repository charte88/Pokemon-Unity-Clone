using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 3f;

    public bool isAllowedToMove = true;
    //bool isMoving = false;

    public Rigidbody2D rb;
    public Animator animator;

    private static bool playerExists;
    private SFXManager sfxManager;

    public string startPoint;

    Vector2 movement;

    void Start()
    {
        isAllowedToMove = true;

        //sfxManager = FindObjectOfType<SFXManager>();

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Input
       
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);       
    }

    void FixedUpdate()
    {
        //isMoving = true;
        // Movement
        if (isAllowedToMove)
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
