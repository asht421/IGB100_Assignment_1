using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {

    //Singleton Setup
    public static GameManager instance = null;
    public static GameManager manager;

    public float xBoundary = 8.5f;
    public float yBoundary = 5f;

    public GameObject player;

    //Score Variables
    public Text lootText;
    [SerializeField] private int loot = 10000;

    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject waveSpawn;
    public GameObject deathScreen;
    public GameObject winScreen;
    public Text finalLootText;
    public Text finalLootTextWin;
    public bool gameOver = false;

    // Awake Checks - Singleton setup
    void Awake() {
        manager = this;

        //Check if instance already exists
        if (instance == null)
            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
    }

    void Start()
    {
        SetLootText();
        deathScreen.SetActive(false);
        winScreen.SetActive(false);
        gameUI.SetActive(true);
    }

    void Update()
    {
        if (loot <= 0)
        {
            GameOver();
        }
    }

    void SetLootText()
    {
        lootText.text = "Loot Remaining: $" + loot.ToString();
    }

    public void TakePoints(int lootToAdd)
    {
        loot += lootToAdd;
        SetLootText();
    }

    public void GameOver()
    {
        gameOver = true;
        // Death Menu
        deathScreen.SetActive(true);
        gameUI.SetActive(false);
        // update score text
        finalLootText.text = "Remaining Loot: $" + loot.ToString();
        Destroy(waveSpawn);
    }

    public void YouWin()
    {
        gameOver = true;

        winScreen.SetActive(true);
        gameUI.SetActive(false);

        finalLootTextWin.text = "You escaped with:" +
            " $ " + loot.ToString();
        Destroy(waveSpawn);
    }

    public void Replay()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void Menu(string name)
    {
        SceneManager.LoadScene(name);
        SceneManager.LoadScene(name);
        gameOver = false;
    }
}
