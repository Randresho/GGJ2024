using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TableStatus { Angry, Neutral, Happy, Comida,}
public enum AnimalTable { Zoo, Pingüinos, Patos, Leones, Tigres, Gorilas, Quetzales, Zorros, Coyotes, Capuchinos, Hamsters, Cuervos, Pulpos}
public class Table : MonoBehaviour
{
    public TableStatus tableStatus;
    public AnimalTable animalTable;
    public GameObject canvasGameObject;
    private Vector3 starScale;
    public Vector3 finalScale = new Vector3(1f, 1f, 1f);    
    public bool canScale;
    public float speedScale = 10f;
    public Image emocionImagen;
    public Sprite[] emociones;
    public Animator animator;

    [Header("Misiones")]
    public bool isMisionComplete;
    //Kidnap
    public GameObject kidnapGameObject;
    public GameObject kidnapGameObjectIdea;

    // Start is called before the first frame update
    void Awake()
    {
        switch (animalTable)
        {
            case AnimalTable.Zoo:
                break;
            case AnimalTable.Pingüinos:
                tableStatus = TableStatus.Neutral;
                break;
            case AnimalTable.Patos:
                tableStatus = TableStatus.Happy;
                break;
            case AnimalTable.Leones:
                tableStatus = TableStatus.Angry;
                break;
            case AnimalTable.Tigres:
                tableStatus = TableStatus.Angry;
                break;
            case AnimalTable.Gorilas:
                tableStatus = TableStatus.Angry;
                break;
            case AnimalTable.Quetzales:
                tableStatus = TableStatus.Angry;
                break;
            case AnimalTable.Zorros:
                tableStatus = TableStatus.Angry;
                break;
            case AnimalTable.Coyotes:
                tableStatus = TableStatus.Angry;
                break;
            case AnimalTable.Capuchinos:
                tableStatus = TableStatus.Angry;
                break;
            case AnimalTable.Hamsters:
                tableStatus = TableStatus.Angry;
                break;
            case AnimalTable.Cuervos:
                tableStatus = TableStatus.Angry;
                break;
            case AnimalTable.Pulpos:
                tableStatus = TableStatus.Happy;
                break;
            default:
                tableStatus = TableStatus.Neutral;
                break;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        switch (tableStatus)
        {
            case TableStatus.Angry:
                emocionImagen.sprite = emociones[0];
                animator.SetBool("Enojado", true);
                animator.SetBool("Neutral", false);
                animator.SetBool("Feliz", false);
                break;
            case TableStatus.Neutral:
                emocionImagen.sprite = emociones[1];
                animator.SetBool("Enojado", false);
                animator.SetBool("Neutral", true);
                animator.SetBool("Feliz", false);
                break;
            case TableStatus.Happy:
                emocionImagen.sprite = emociones[2];
                animator.SetBool("Enojado", false);
                animator.SetBool("Neutral", false);
                animator.SetBool("Feliz", true);
                break;
            default:
                break;
        }
        if (canScale)
        {
            canvasGameObject.transform.localScale = Vector3.Lerp(canvasGameObject.transform.localScale, finalScale, Time.deltaTime * speedScale);
        }
        else
        {
            canvasGameObject.transform.localScale = Vector3.Lerp(canvasGameObject.transform.localScale, starScale, Time.deltaTime * speedScale);
        }
        ChangeStatus();
    }

    public void ChangeStatus()
    {
        if (isMisionComplete)
        {
            tableStatus = TableStatus.Happy;
        }
        /*for (int i = 0; i< isMisionComplete.Length; i++)
        {
            if (isMisionComplete[i]) 
            {
                animalTable = (AnimalTable) i;
            }

            print(animalTable);
        }*/
    }
}
