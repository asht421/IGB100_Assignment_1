using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private float maximum;
    [SerializeField] Image mask;

    [SerializeField] Player playerScript; //input script as variable to access
    [SerializeField] float playerHealth;

    [SerializeField] Text healthText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maximum = playerScript.health;
        Debug.Log("maximum = "+maximum);
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = playerScript.health;

        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        float fillAmount = playerHealth / maximum;
        mask.fillAmount = fillAmount;
        healthText.text = (fillAmount*100).ToString() + "/" + maximum.ToString();
    }
}
