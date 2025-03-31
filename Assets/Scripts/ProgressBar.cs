using System;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{
    public int maximum;
    public Image mask;

    public WaveSpawner waveSpawner; //input script as variable to access
    public int currentWave;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maximum = waveSpawner.waves.Length - 1;
    }

    // Update is called once per frame
    void Update()
    {
        currentWave = waveSpawner.currentWaveNumber;
        
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        float fillAmount = (float)currentWave / (float)maximum;
        mask.fillAmount = fillAmount;
    }
}
