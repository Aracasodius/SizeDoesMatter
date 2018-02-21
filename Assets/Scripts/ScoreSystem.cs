using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] Text t_Score;

    float t;
    float t_max = 1f;

    private void Update()
    {
        if (t_Score != null) { t_Score.text = PlayerPrefs.GetFloat("Score").ToString(); }
    }

    public void PickupAdd()
    {
        PlayerPrefs.SetFloat("Score", PlayerPrefs.GetFloat("Score") + 1);
    }
    public void PickupAdd(float amount)
    {
        PlayerPrefs.SetFloat("Score", PlayerPrefs.GetFloat("Score") + amount);
    }

    public void ResetScore()
    {
        PlayerPrefs.SetFloat("Score", 0);
    }

    public void ResetAll()
    {
        PlayerPrefs.SetFloat("Score", 0);
        PlayerPrefs.SetFloat("HighScore", 0);
        PlayerPrefs.SetInt("TotalClicks", 0);
    }

}
