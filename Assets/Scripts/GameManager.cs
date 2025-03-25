using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    //Singleton Setup
    public static GameManager instance = null;

    public float xBoundary = 8.5f;
    public float yBoundary = 5f;

    public GameObject player;

    //Score Variables
    public Text lootText;
    private int loot = 10000;

    // Awake Checks - Singleton setup
    void Awake() {

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
    }

    void SetLootText()
    {
        lootText.text = "Loot Remaining: " + loot.ToString() +"/10000";
    }

    public void TakePoints(int lootToAdd)
    {
        loot += lootToAdd;
        Debug.Log(loot);
        SetLootText();
    }
}
