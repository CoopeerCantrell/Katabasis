using UnityEngine;

public class TutorialPanel : MonoBehaviour
{
    public static bool inTutorial = true;
    public GameObject panel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (inTutorial)
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inTutorial)
        {
            Time.timeScale = 0.0f;
        }
        else if (inTutorial != true && pauseMenu.GameIsPaused != true)
        {
            Time.timeScale = 1f;
        }
    }

    public void Leave()
    {
        panel.SetActive(false);
        inTutorial = false;
    }
}
