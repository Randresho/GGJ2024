using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType { Dialogo, Agarrable,}
public class Item : MonoBehaviour
{
    public ItemType itemType;
    public bool isGrabbleble;
    public bool wasGrab;
    public GameObject canvasGameObject;
    public Vector3 starScale, finalScale;
    public bool canScale;
    public float speedScale;
    [SerializeField] private Rigidbody m_rigidbody;
    [SerializeField] private BoxCollider m_boxCollider;

    [Header("Table")]
    public GameObject tableObject;
    public AnimalTable animalTable;
    public bool isMisionComplete;

    // Start is called before the first frame update
    void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (itemType)
        {
            case ItemType.Dialogo:
                break;
            case ItemType.Agarrable:
                /*if (isGrabbleble)
                {
                    canScale = false;
                }
                else
                {
                    canScale = true;
                }*/
                break;
            default:
                break;
        }
        if (isGrabbleble)
        {
            if (!wasGrab)
            {
                if (canScale)
                {
                    canvasGameObject.transform.localScale = Vector3.Lerp(canvasGameObject.transform.localScale, finalScale, Time.deltaTime * speedScale);
                }
                else
                {
                    canvasGameObject.transform.localScale = Vector3.Lerp(canvasGameObject.transform.localScale, starScale, Time.deltaTime * speedScale);
                }
            }
            else
            {
                canvasGameObject.transform.localScale = Vector3.Lerp(canvasGameObject.transform.localScale, starScale, Time.deltaTime * speedScale);
            }
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        if(other.GetComponent<Table>() != null)
        {
            print("Estoy tocado una mesa");
            if(!wasGrab)
            {
                tableObject = other.gameObject;
                switch (tableObject.GetComponent<Table>().animalTable)
                {
                    case AnimalTable.Pingüinos:
                        break;
                    case AnimalTable.Patos:
                        break;
                    case AnimalTable.Leones:
                        break;
                    case AnimalTable.Tigres:
                        break;
                    case AnimalTable.Gorilas:
                        break;
                    case AnimalTable.Quetzales:
                        break;
                    case AnimalTable.Zorros:
                        break;
                    case AnimalTable.Coyotes:
                        break;
                    case AnimalTable.Capuchinos:
                        break;
                    case AnimalTable.Hamsters:
                        break;
                    case AnimalTable.Cuervos:
                        break;
                    case AnimalTable.Pulpos:
                        break;
                    default:
                        break;
                }
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        GameObject obj = other.gameObject;
        if (other.GetComponent<Table>() != null)
        {
            print("Estoy tocado una mesa");
            if (!wasGrab)
            {
                tableObject = other.gameObject;
                print("Nombre de la mesa " + tableObject.gameObject.name);
                if(animalTable == tableObject.GetComponent<Table>().animalTable)
                {
                    tableObject.GetComponent<Table>().isMisionComplete = true;
                    isMisionComplete = true;

                    transform.SetParent(tableObject.transform);
                    transform.position = tableObject.transform.position;

                    StartCoroutine(DestroyObject());

              

                    //transform.gameObject.SetActive(false);
                }
                else
                {
                    tableObject.GetComponent<Table>().isMisionComplete= false;
                    isMisionComplete = false;
                }
            }
        }
    }

    IEnumerator DestroyObject()
    {
        wasGrab = true;
        m_rigidbody.useGravity = false;
        m_rigidbody.isKinematic = true;
        m_boxCollider.enabled = false;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject obj = other.gameObject;
        if (other.GetComponent<Table>() != null)
        {
            tableObject = null;
            print("Estoy fuera de la mesa");
            if (!wasGrab)
            {
                tableObject = null;
            }
        }
    }
}
