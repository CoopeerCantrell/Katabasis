using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Modifier : MonoBehaviour
{

    public float speedModAmount = 0.5f;
    public float fallModAmount = 2f;
    public float musicRadModAmount = 1f;
    public int speedStacked = 0;
    public int fallSpeedStacked = 0;
    public int musicRadStacked = 0;
    public PlayerMovement player;
    public OrpheusMusic playermusic;
    public List<ModifierObject> modObjects;
    public List<ModifierObject> copiedModObjects;
    public SceneTransistion scene;
    public bool choice1Done = false;
    public bool choice2Done = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        ShuffleList(modObjects, copiedModObjects);
    }
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        playermusic = GameObject.FindWithTag("Player").GetComponent<OrpheusMusic>();
        PopMods();
        PopMods();

    }

    // Update is called once per frame
    void Update()
    {
        if (speedStacked <= ModifuerManager.speedStack)
        {
            for (int i = 0; i < ModifuerManager.speedStack; i++)
            {
                player.speedModifier += speedModAmount;
                speedStacked++;
            }
        }

        if (fallSpeedStacked <= ModifuerManager.fallSpeedStack)
        {
            for (int i = 0; i < ModifuerManager.fallSpeedStack; i++)
            {
                player.fallSpeedModifier += fallModAmount;
                fallSpeedStacked++;
            }
        }

        if (musicRadStacked <= ModifuerManager.musicRadiusStack)
        {
            for (int i = 0; i < ModifuerManager.musicRadiusStack; i++)
            {
                playermusic.radiusModifier += musicRadModAmount;
                musicRadStacked++;
                playermusic.radIncreased = true;
            }
        }
    }

    public void PopMods()
    {
        if (choice1Done == false)
        {
            ModifierObject currentMod = copiedModObjects.Last();

            ModifuerManager.Instance.portrait1.sprite = currentMod.sprite;
            ModifuerManager.Instance.nameText1.text = currentMod.nameText;
            ModifuerManager.Instance.textComponent1.text = currentMod.descriptionText;
            if (currentMod.mod == "Speed")
            {
                ModifuerManager.Instance.button1.GetComponent<Button>().onClick.AddListener(() => UpdateSpeedStack());
                ModifuerManager.Instance.button1.GetComponent<Button>().onClick.AddListener(() => scene.TransitionScene("SampleScene"));
            }
            else if (currentMod.mod == "Fall")
            {
                ModifuerManager.Instance.button1.GetComponent<Button>().onClick.AddListener(() => UpdateFallStack());
                ModifuerManager.Instance.button1.GetComponent<Button>().onClick.AddListener(() => scene.TransitionScene("SampleScene"));
            }
            else if (currentMod.mod == "Range")
            {
                ModifuerManager.Instance.button1.GetComponent<Button>().onClick.AddListener(() => UpdateRangeStack());
                ModifuerManager.Instance.button1.GetComponent<Button>().onClick.AddListener(() => scene.TransitionScene("SampleScene"));
            }
            choice1Done = true;
        }
        else if (choice1Done)
        {
            ModifierObject currentMod = copiedModObjects.First();

            ModifuerManager.Instance.portrait2.sprite = currentMod.sprite;
            ModifuerManager.Instance.nameText2.text = currentMod.nameText;
            ModifuerManager.Instance.textComponent2.text = currentMod.descriptionText;
            if (currentMod.mod == "Speed")
            {
                ModifuerManager.Instance.button2.GetComponent<Button>().onClick.AddListener(() => UpdateSpeedStack());
                ModifuerManager.Instance.button2.GetComponent<Button>().onClick.AddListener(() => scene.TransitionScene("SampleScene"));
            }
            else if (currentMod.mod == "Fall")
            {
                ModifuerManager.Instance.button2.GetComponent<Button>().onClick.AddListener(() => UpdateFallStack());
                ModifuerManager.Instance.button2.GetComponent<Button>().onClick.AddListener(() => scene.TransitionScene("SampleScene"));
            }
            else if (currentMod.mod == "Range")
            {
                ModifuerManager.Instance.button2.GetComponent<Button>().onClick.AddListener(() => UpdateRangeStack());
                ModifuerManager.Instance.button2.GetComponent<Button>().onClick.AddListener(() => scene.TransitionScene("SampleScene"));
            }
            choice2Done = true;
        }
    }

    public void ShuffleList(List<ModifierObject> list, List<ModifierObject> listTarg)
    {
        List<ModifierObject> temp = new List<ModifierObject>();
        temp.AddRange(list);

        for (int i = 0; i < list.Count; i++)
        {
            int index = Random.Range(0, temp.Count - 1);
            listTarg.Add(temp[index]);
            temp.RemoveAt(index);
        }
    }

    public void UpdateSpeedStack()
    {
        ModifuerManager.speedStack++;
    }
    public void UpdateFallStack()
    {
        ModifuerManager.fallSpeedStack++;
    }
    public void UpdateRangeStack()
    {
        ModifuerManager.musicRadiusStack++;
    }
    

}
