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
    public bool isInAObject;
    [SerializeField] private Item item;
    [SerializeField] private GameObject itemGameObject;

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
            if (!isAttach)
            {
                itemGameObject = obj;
                item = other.GetComponent<Item>();
                isInAObject = true;
            }
        }
    }

    [SerializeField] private Vector3 m_startScale;
    [SerializeField] private Vector3 m_finalScale;
    private void OnTriggerStay(Collider other)
    {
        GameObject obj = other.gameObject;
        if (other.GetComponent<Item>() != null)
        {
            if (!isAttach)
            {
                switch (other.GetComponent<Item>().itemType)
                {
                    case ItemType.Dialogo:
                        print("Esto en un dialogo");
                        other.GetComponent<Item>().canScale = true;
                        break;
                    case ItemType.Agarrable:
                        print("Estoy con un objeto agarrable");
                        break;
                    default:
                        break;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject obj = other.gameObject;
        if (other.GetComponent<Item>() != null)
        {
            if (!isAttach)
            {
                itemGameObject = null;
                item = null;
                isInAObject = false;
            }
            switch (other.GetComponent<Item>().itemType)
            {
                case ItemType.Dialogo:
                    other.GetComponent<Item>().canScale = false;
                    break;
                case ItemType.Agarrable:
                    break;
                default:
                    break;
            }
        }
    }

    private void ActiveActionMode()
    {
        if(isInAObject)
        {
            switch (itemGameObject.GetComponent<Item>().itemType)
            {
                case ItemType.Dialogo:
                    if (!isAttach)
                    {
                        print("Se activo el dialogo");
                       
                    }
                    break;
                case ItemType.Agarrable:
                    if (isAttach)
                    {
                        print("Solte el objeto");
                        //itemGameObject.transform.parent = null;
                        itemGameObject.transform.SetParent(null);
                        isAttach = false;
                        //itemGameObject.GetComponent<Rigidbody>().useGravity = true;
                        //itemGameObject.GetComponent<Rigidbody>().isKinematic = false;
                    }
                    else
                    {
                        print("Agarre el objeto");
                        //itemGameObject.transform.parent = attachPoint;
                        itemGameObject.transform.SetParent(attachPoint);
                        itemGameObject.transform.position = attachPoint.position;
                        isAttach = true;
                        //itemGameObject.GetComponent<Rigidbody>().useGravity = false;
                        //itemGameObject.GetComponent<Rigidbody>().isKinematic = true;
                    }
                    break;
                default:
                    break;
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
        ActiveActionMode();
    }

    private void OnDisable()
    {
        m_playerController.Disable();
        m_playerController.Move.Interaccion.performed -= UseAction;
    }
    #endregion
}
