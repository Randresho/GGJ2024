using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    private PlayerController m_playerController;
    public Transform attachPoint;
    public bool isAttach;

    // Start is called before the first frame update
    void Awake()
    {
        m_playerController = new PlayerController();
        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        if (other.GetComponent<Item>() != null)
        {
            if(!isAttach)
            {
                print("Se puede agarrar");
            }
            else
            {
                print("No se puede agarrar");
            }
        }
    }

    #region Input Enable / Disable
    private void OnEnable()
    {
        m_playerController.Enable();
        m_playerController.Move.Interaccion.performed += UseAction;
    }

    private void UseAction(InputAction.CallbackContext callbackContext)
    {

    }

    private void OnDisable()
    {
        m_playerController.Disable();
        m_playerController.Move.Interaccion.performed -= UseAction;
    }
    #endregion
}
