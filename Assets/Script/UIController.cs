using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIController : MonoBehaviour
{

    [SerializeField]
    private GameObject _panelRetry;


    void Start()
    {
        _panelRetry.SetActive(false);
        
    }



    void Update()
    {
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print("click");
        Time.timeScale = 1;

    }
}
