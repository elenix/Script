using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour {

    public GameObject TimerText, HpBar, GameOverText, StatusText, PauseButton;
    public float timer = 10.0f;
    public int HpCurrent = 1000;
    public int HpMax = 1000;
    public int damagetaken = 1;
    public Spawner cancelSpawn;

    private Text status_text;
    Image healthbar;

    void Awake()
    {
        status_text = StatusText.GetComponent<Text>();
        healthbar = HpBar.GetComponent<Transform>().FindChild("HealthBar").GetComponent<Image>();
    }

    void Update ()
    {
        timer -= Time.deltaTime;
        Text time_text = TimerText.GetComponent<Text>();
        
        if(HpCurrent <= 0)
        {
            cancelSpawn.CancelInvoke();
            status_text.text = "YOU DIED!";
            GameOverText.SetActive(true);
            PauseButton.SetActive(false);
        }
        else if (timer >= 0.0f)
        {
            time_text.text = timer.ToString("F1") + "'s";
        }
        else
        {
            cancelSpawn.CancelInvoke();
            time_text.text = "0.0's";
            status_text.text = "TIME OUT!";
            GameOverText.SetActive(true);
            PauseButton.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "MeteorS")
        {
            HpCurrent -= damagetaken;
            healthbar.fillAmount = (float)HpCurrent / HpMax;
        }
        else if (col.gameObject.tag == "MeteorM")
        {
            HpCurrent -= (damagetaken * 2);
            healthbar.fillAmount = (float)HpCurrent / HpMax;
        }
        else if (col.gameObject.tag == "MeteorB")
        {
            HpCurrent -= (damagetaken * 3);
            healthbar.fillAmount = (float)HpCurrent / HpMax;
        }

        Destroy(col.gameObject);
    }
}
