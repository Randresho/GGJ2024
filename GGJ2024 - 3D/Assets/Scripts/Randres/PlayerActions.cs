using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class PlayerActions : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    private PlayerController m_playerController;
    public Transform attachPoint;
    public bool isAttach;
    public bool isInAObject;
    [SerializeField] private Item item;
    [SerializeField] private GameObject itemGameObject;
    private MovimientoDelPersonaje movimiento;

    [Header("Canvas")]
    public bool canNavegateOptions;
    public GameObject canvasGameObject;
    public GameObject canvasGameObjectHerramientas;
    private Vector3 startScale;
    public Vector3 finalScale = new Vector3(1f, 1f, 1f);
    public float speedScale = 10f;
    public bool canScale;
    public bool canScaleHerramientas;

    [Header("First Selected Options")]
    [SerializeField] private GameObject _uiOpciones;
    [SerializeField] private GameObject _uiHerramientas;

    // Start is called before the first frame update
    void Awake()
    {
        m_playerController = new PlayerController();
        m_rigidbody = GetComponent<Rigidbody>();
        movimiento = FindObjectOfType<MovimientoDelPersonaje>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canScale)
        {
            canvasGameObject.transform.localScale = Vector3.Lerp(canvasGameObject.transform.localScale, finalScale, Time.deltaTime * speedScale);
            canNavegateOptions = true;
        }
        else
        {
            canvasGameObject.transform.localScale = Vector3.Lerp(canvasGameObject.transform.localScale, startScale, Time.deltaTime * speedScale);
            canNavegateOptions = false;
        }

        if (canScaleHerramientas)
        {
            canvasGameObjectHerramientas.transform.localScale = Vector3.Lerp(canvasGameObjectHerramientas.transform.localScale, finalScale, Time.deltaTime * speedScale);
            canNavegateOptions = true;
        }
        else
        {
            canvasGameObjectHerramientas.transform.localScale = Vector3.Lerp(canvasGameObjectHerramientas.transform.localScale, startScale, Time.deltaTime * speedScale);
            canNavegateOptions = false;
        }

        /*if (canScaleHerramientas)
            EventSystem.current.SetSelectedGameObject(_uiHerramientas);
        else if (canScale)
            EventSystem.current.SetSelectedGameObject(_uiOpciones);*/
        if(!canScale && !canScaleHerramientas)
            EventSystem.current.SetSelectedGameObject(null);
    }

    public void SwapUi()
    {
        canScale = !canScale;
        canScaleHerramientas = !canScaleHerramientas;

        StartCoroutine(DelaySwap());

    }

    IEnumerator DelaySwap()
    {
        yield return new WaitForSeconds(0.5f);
        if (canScale)
            EventSystem.current.SetSelectedGameObject(_uiOpciones);
        if (canScaleHerramientas)
            EventSystem.current.SetSelectedGameObject(_uiHerramientas);
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

        if (other.GetComponent<Table>() != null)
        {
            switch (other.GetComponent<Table>().tableStatus)
            {
                case TableStatus.Angry:
                    canScaleHerramientas = true;
                    EventSystem.current.SetSelectedGameObject(_uiHerramientas);
                    break;
                case TableStatus.Neutral:
                    canScale = true;
                    EventSystem.current.SetSelectedGameObject(_uiOpciones);
                    break;
                case TableStatus.Happy:
                    canScale = true;
                    EventSystem.current.SetSelectedGameObject(_uiOpciones);
                    break;
                case TableStatus.Comida:
                    break;
                default:
                    break;
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
                        if(other.GetComponent<Item>().isGrabbleble)
                        {
                            other.GetComponent<Item>().canScale = true;
                        }
                        else
                        {
                            other.GetComponent<Item>().canScale = false;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        if (other.GetComponent<Table>() != null)
        {
            other.GetComponent<Table>().canScale = true;
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

            other.GetComponent<Item>().canScale = false;
            /*switch (other.GetComponent<Item>().itemType)
            {
                case ItemType.Dialogo:
                    other.GetComponent<Item>().canScale = false;
                    break;
                case ItemType.Agarrable:
                    
                    break;
                default:
                    break;
            }*/
        }

        if (other.GetComponent<Table>() != null)
        {
            other.GetComponent<Table>().canScale = false;

            canScaleHerramientas = false;
            canScale = false;

            EventSystem.current.SetSelectedGameObject(null);
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
                    if (itemGameObject.GetComponent<Item>().isGrabbleble)
                    {
                        if (isAttach)
                        {
                            print("Solte el objeto");
                            itemGameObject.transform.parent = null;
                            itemGameObject.transform.SetParent(null);
                            isAttach = false;

                            itemGameObject.GetComponent<Item>().wasGrab = false;
                            itemGameObject.GetComponent<Rigidbody>().useGravity = true;
                            itemGameObject.GetComponent<Rigidbody>().isKinematic = false;
                            itemGameObject.GetComponent<BoxCollider>().enabled = true;

                            movimiento.m_PlayerSpeed = movimiento.m_PlayerSpeedMax;
                        }
                        else
                        {
                            print("Agarre el objeto");
                            itemGameObject.transform.parent = attachPoint;
                            itemGameObject.transform.SetParent(attachPoint);
                            itemGameObject.transform.position = attachPoint.position;
                            isAttach = true;

                            itemGameObject.GetComponent<Item>().wasGrab = true;
                            itemGameObject.GetComponent<Rigidbody>().useGravity = false;
                            itemGameObject.GetComponent<Rigidbody>().isKinematic = true;
                            itemGameObject.GetComponent<BoxCollider>().enabled = false;

                            movimiento.m_PlayerSpeed = movimiento.m_PlayerSpeed / 2;
                        }
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
