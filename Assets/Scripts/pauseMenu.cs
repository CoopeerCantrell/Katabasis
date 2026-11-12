using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject controlsUI;

    public string sceneName;
    

    // Update is called once per frame
    void Update()
    {
     
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab))
            {
             if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
        }   
        
    }

    public void Resume()
    {
     
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;
        
     
    }

    void Pause()
    {
        
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
        Time.timeScale = 0f;
        
        
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
        

    }
    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
    public void credits()
    {
        controlsUI.SetActive(true);
    }
    public void exitCredits()
    {
        controlsUI.SetActive(false);
    }
}
