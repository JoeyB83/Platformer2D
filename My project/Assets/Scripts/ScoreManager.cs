using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI lives;
    [SerializeField] TextMeshProUGUI score;

    void Update()
    {
        TextManager();
    }

    void TextManager()
    {
        lives.text = PlayThroughtData.instance.lives.ToString();
        score.text = PlayThroughtData.instance.currentScore.ToString("000");
    }
}
