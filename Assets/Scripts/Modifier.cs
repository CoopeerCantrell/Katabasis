using UnityEngine;

public class Modifier : MonoBehaviour
{
    public int speedStack = 0;
    public int fallSpeedStack = 0;
    public int musicRadiusStack = 0;

    public float speedModAmount = 0.5f;
    public float fallModAmount = 2f;
    public float musicRadModAmount = 1f;
    public int speedStacked = 0;
    public int fallSpeedStacked = 0;
    public int musicRadStacked = 0;
    public PlayerMovement player;
    public OrpheusMusic playermusic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        playermusic = GameObject.FindWithTag("Player").GetComponent<OrpheusMusic>();
    }

    // Update is called once per frame
    void Update()
    {
        if (speedStacked <= speedStack)
        {
            for (int i = 0; i < speedStack; i++)
            {
                player.speedModifier += speedModAmount;
                speedStacked++;
            }
        }

        if (fallSpeedStacked <= fallSpeedStack)
        {
            for (int i = 0; i < fallSpeedStack; i++)
            {
                player.fallSpeedModifier += fallModAmount;
                fallSpeedStacked++;
            }
        }

        if (musicRadStacked <= musicRadiusStack)
        {
            for (int i = 0; i < musicRadiusStack; i++)
            {
                playermusic.radiusModifier += musicRadModAmount;
                musicRadStacked++;
                playermusic.radIncreased = true;
            }
        }
    }

}
