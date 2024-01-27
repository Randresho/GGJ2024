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


    void Awake()
    {
        m_playerInput = new PlayerInput();
        m_playerController = new PlayerController();
        m_rigidbody = GetComponent<Rigidbody>();
        m_PlayerSpeedMax = m_PlayerSpeed;
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
