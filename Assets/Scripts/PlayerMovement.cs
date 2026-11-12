using System.Collections;

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool cantBeHit = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D body;
    public float speed = 5f;
    public float speedModifier = 0f;
    public float fallSpeed = 16f;
    public float fallSpeedModifier = 0f;
    public Vector2 movement;
    public int lifeAmount = 1;
    public GameObject deathPanel;
    public bool thrown = false;
    public bool noMovement = false;
    public static bool canContinueDeath = false;
    public bool inAnimatioon = false;
    public GameObject player;
    public AudioSource audioSource;
    public AudioClip wilhiem;
    public static bool isDead;
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        audioSource = GameObject.FindGameObjectWithTag("Inventory").GetComponent<AudioSource>();
        Time.timeScale = 1f;
    }
    void Start()
    {
        player = gameObject;
        deathPanel = FindInactiveObject("DeathPanel");
    }

    GameObject FindInactiveObject(string name)
    {
        GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();

        foreach (GameObject obj in objects)
        {
            if (obj.name == name && obj.scene.IsValid())
            {
                return obj;
            }
        }

        return null;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        if(!noMovement)
            body.linearVelocity = new Vector2(movement.x * (speed + speedModifier), body.linearVelocity.y);

        if (body.linearVelocity.y < -(fallSpeed + fallSpeedModifier))
        {
            body.linearVelocity = new Vector3(
                body.linearVelocity.x,
                -(fallSpeed + fallSpeedModifier)
            );
        }

        if (lifeAmount <= 0)
        {
            if (!inAnimatioon)
            {
                inAnimatioon = true;
                isDead = true;
                audioSource.PlayOneShot(wilhiem);
                TweenHelper.TakeDamage(transform);
                StartCoroutine(CancelPlayer());
            }
            if (canContinueDeath && inAnimatioon)
                {
                    deathPanel.SetActive(true);
                    Time.timeScale = 0f;
                }
        }
    }

    public void CallDamageTick()
    {
        StartCoroutine(DamageTick());
    }

    IEnumerator DamageTick()
    {
        float elapsedTime = 0f;
        float duration = 3f;

        while (elapsedTime < duration)
        {
            cantBeHit = true;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        cantBeHit = false;
        Debug.Log("can be damaged again");
    }

    IEnumerator CancelPlayer()
    {
        noMovement = true;
        player.GetComponent<SpriteRenderer>().color = new Color(125f, 0f, 0f, 225f);
        yield return new WaitForSeconds(0.5f);
        noMovement = false;
        player.GetComponent<SpriteRenderer>().color = new Color(225f, 225f, 225f, 225f);
        canContinueDeath = true;
    }
}
