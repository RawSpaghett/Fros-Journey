using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EggManager : MonoBehaviour
{
    public static EggManager instance;
    public int eggCount;
    public int totalEggs;
    public Text eggText;
    public int lotusCount;
    public int totalLotus;

    public TMP_Text finishText;
    public GameObject finish;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    void Awake()
    {
        instance = this;
    }


    void Start()
    {
        totalEggs = GameObject.FindGameObjectsWithTag("Egg").Length;
        totalLotus = GameObject.FindGameObjectsWithTag("Lotus").Length;

        UpdateUI(); // initialize UI at start
    }

    // This replaces manually changing eggCount
    public void AddEgg()
    {
        eggCount++;
        UpdateUI();

        if (eggCount >= totalEggs)
        {
            LevelComplete();
        }
    }

    public void AddLotus()
    {
        lotusCount++;
        UpdateUI();
    }


    // This replaces your Update() method
    void UpdateUI()
    {
        if (eggText != null)
            eggText.text = eggCount + " / " + totalEggs + "  Lotus: " + lotusCount + "/" + totalLotus; ;
    }


    void LevelComplete()
    {
        if (finish != null)
            finish.SetActive(true);

        if (finishText != null)
        {
            finishText.text =
                "Eggs: " + eggCount + " / " + totalEggs +
                "\nLotus: " + lotusCount + " / " + totalLotus;
        }

    }
}
