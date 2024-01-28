using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    GameObject boton;
    public GameObject creditsPanel;
    public GameObject mainMenuPanel;

    public GameObject controlsPanel;


    void Start()
    {
        gameObject.GetComponent<Button>();
        goBack();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CargarJuego() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1, LoadSceneMode.Single);
    }

    public void exit(){
        Application.Quit();
    }

    public void goBack(){
        mainMenuPanel.SetActive(true);
        creditsPanel.SetActive(false);
        controlsPanel.SetActive(false);

    }

    public void credits(){
        mainMenuPanel.SetActive(false);
        creditsPanel.SetActive(true);
        controlsPanel.SetActive(false);

    }
}
