using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour {

    //Singleton Setup
    public static GameManager instance = null;

    public float xBoundary = 8.5f;
    public float yBoundary = 5f;

    public GameObject player;

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
}
