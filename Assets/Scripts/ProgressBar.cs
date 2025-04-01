using System;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{
    private int maximum;
    [SerializeField] Image mask;

    [SerializeField] WaveSpawner waveSpawner; //input script as variable to access
    [SerializeField] int currentWave;

    [SerializeField] Text percentageText;

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
        percentageText.text = (fillAmount * 100).ToString() + "% to escape";
    }
}
