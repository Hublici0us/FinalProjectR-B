using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private SceneStuff sceneManager;

    public GameObject pauseEmpty;
    
    // Start is called before the first frame update
    void Start()
    {
        sceneManager = GameObject.Find("GameManager").GetComponent<SceneStuff>();
        pauseEmpty.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            pauseEmpty.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ReturnButton()
    {
        pauseEmpty.SetActive(false);

        Time.timeScale = 1;

        Cursor.lockState = CursorLockMode.Locked;
    }
}
