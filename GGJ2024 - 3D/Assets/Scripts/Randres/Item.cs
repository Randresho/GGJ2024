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

    [Header("Table")]
    public GameObject tableObject;
    public AnimalTable animalTable;

    // Start is called before the first frame update
    void Start()
    {
        
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
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject obj = other.gameObject;
        if (other.GetComponent<Table>() != null)
        {
            print("Estoy fuera de la mesa");
            if (!wasGrab)
            {
                tableObject = null;
            }
        }
    }
}
