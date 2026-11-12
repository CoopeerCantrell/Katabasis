using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransistion : MonoBehaviour
{
     public string targetSceneName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TransitionScene()
    {
        TransitionScene(targetSceneName);
    }

    public void TransitionScene(string targetScene)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(targetScene);
    }
    public void ResetRun()
    {
        TransitionScene(targetSceneName);
        ModifuerManager.fallSpeedStack = 0;
        ModifuerManager.musicRadiusStack = 0;
        ModifuerManager.speedStack = 0;
        ModifuerManager.musicTimerStack = 0;
        ModifuerManager.enemySpeedDown = 0;
        ModifuerManager.storedItem = null;
        PlayerMovement.canContinueDeath = false;
        PlayerMovement.isDead = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
