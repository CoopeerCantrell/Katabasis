using UnityEngine;

public class FavorEntrance : MonoBehaviour
{
    public GameObject favorUi;
    public bool inFavor = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            favorUi.SetActive(true);
            Time.timeScale = 0f;
            inFavor = true;
        }
    }

    public void LeaveFavor()
    {
        favorUi.SetActive(false);
        Time.timeScale = 1f;
        inFavor = false;
    }
}
