using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    GameObject timeText;
    GameObject hpGauge;

    float time = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        timeText = GameObject.Find("Time");
        hpGauge = GameObject.Find("hpGauge");
    }

    private void Update()
    {
        time -= Time.deltaTime;
        timeText.GetComponent<Text>().text = this.time.ToString("F1");

        if (time <= 0)
        {
            SceneManager.LoadScene("ClearScene");
        }
    }


    public void DecreaseHp()
    {
        if (hpGauge.GetComponent<Image>().fillAmount == 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
        else hpGauge.GetComponent<Image>().fillAmount -= 0.1f;

    }

    // 나중에 구현할거
    /*public void Hit()
    {
        hitText.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void NoHit()
    {
        hitText.GetComponent<SpriteRenderer>().enabled = false;
    }*/
}
