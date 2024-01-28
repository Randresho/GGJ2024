using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoDelPersonaje : MonoBehaviour
{
    private PlayerInput m_playerInput;
    private Rigidbody m_rigidbody;
    private PlayerController m_playerController;
    public float m_PlayerSpeed = 0f;
    public float m_PlayerSpeedMax = 0f;
    private Vector2 moveInput;
    public Animator animator;
    public Animator animatorShadow;
    public SpriteRenderer spriteRenderer;
    public SpriteRenderer spriteRendererShadow;
    private PlayerActions playerActions;


    void Awake()
    {
        m_playerInput = new PlayerInput();
        m_playerController = new PlayerController();
        m_rigidbody = GetComponent<Rigidbody>();
        m_PlayerSpeedMax = m_PlayerSpeed;
        playerActions = FindObjectOfType<PlayerActions>();  
    }

    

    // Update is called once per frame
    void FixedUpdate()
    {
        moveInput = m_playerController.Move.Walk.ReadValue<Vector2>();
        SetVelocity(m_PlayerSpeed);
    }

    private void SetVelocity(float speed)
    {
        m_rigidbody.velocity = new Vector3(-moveInput.y * speed, 0f, moveInput.x * speed);
        if (m_rigidbody.velocity.magnitude > 0.1f)
        {
            if(!playerActions.isAttach)
            {
                animator.SetBool("Walk", true);
                animator.SetBool("Idle", false);
                animator.SetBool("CarryingWalk", false);
                animator.SetBool("CarryingIdle", false);

                animatorShadow.SetBool("Walk", true);
                animatorShadow.SetBool("Idle", false);
                animatorShadow.SetBool("CarryingWalk", false);
                animatorShadow.SetBool("CarryingIdle", false);
            }
            else
            {
                animator.SetBool("Walk", false);
                animator.SetBool("Idle", false);
                animator.SetBool("CarryingWalk", true);
                animator.SetBool("CarryingIdle", false);

                animatorShadow.SetBool("Walk", false);
                animatorShadow.SetBool("Idle", false);
                animatorShadow.SetBool("CarryingWalk", true);
                animatorShadow.SetBool("CarryingIdle", false);
            }
        }
        else
        {
            if (!playerActions.isAttach)
            {
                animator.SetBool("Walk", false);
                animator.SetBool("Idle", true);
                animator.SetBool("CarryingWalk", false);
                animator.SetBool("CarryingIdle", false);

                animatorShadow.SetBool("Walk", false);
                animatorShadow.SetBool("Idle", true);
                animatorShadow.SetBool("CarryingWalk", false);
                animatorShadow.SetBool("CarryingIdle", false);
            }
            else
            {
                animator.SetBool("Walk", false);
                animator.SetBool("Idle", false);
                animator.SetBool("CarryingWalk", false);
                animator.SetBool("CarryingIdle", true);

                animatorShadow.SetBool("Walk", false);
                animatorShadow.SetBool("Idle", false);
                animatorShadow.SetBool("CarryingWalk", false);
                animatorShadow.SetBool("CarryingIdle", true);
            }

            /*animator.SetBool("Walk", false);
            animator.SetBool("Idle", true);

            animatorShadow.SetBool("Walk", false);
            animatorShadow.SetBool("Idle", true);*/
        }
        if(m_rigidbody.velocity.z < 0.1f)
        {
            spriteRenderer.flipX = true;
            spriteRendererShadow.flipX = true;
        }
        else if(m_rigidbody.velocity.z > 0.1f)
        {
            spriteRenderer.flipX = false;
            spriteRendererShadow.flipX = false;
        }

        //m_rigidbody.velocity = moveInput * speed;

        //animator.SetFloat("VelX", m_rigidbody2D.velocity.x);
        //nimator.SetFloat("VelY", m_rigidbody2D.velocity.y);
    }

    #region Input Enable / Disable
    private void OnEnable()
    {
        m_playerController.Enable();
    }
    private void OnDisable()
    {
        m_playerController.Disable();
    }
    #endregion
}
