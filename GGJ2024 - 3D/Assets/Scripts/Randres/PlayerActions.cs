using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    private PlayerController m_playerController;


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
            
        }
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
