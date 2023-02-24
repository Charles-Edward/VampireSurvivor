using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillCountManager : MonoBehaviour
{
    public static KillCountManager instance;


    [SerializeField]
    private TextMeshProUGUI _scoreText;

    [SerializeField]
    private TextMeshProUGUI _highScoreText;



    // Private & Protected
    //private int _killCount;
    public int _score = 0;
    private int _highScore = 0;


    private void Awake()
    {
        
        instance = this;
    }

    void Start()
    {
        _highScore = PlayerPrefs.GetInt("_highScore", 0);
        _scoreText.text = "Kills : " + _score.ToString();
        _highScoreText.text = "High Score : " + _highScore.ToString();
        
        
    }



    void Update()
    {
        
    }

    public void AddPoint()
    {
        _score += 1;
        _scoreText.text = "Kills : " + _score.ToString();
        if (_score > _highScore)
        {
            
           PlayerPrefs.SetInt("_highScore", _score);

        }

    }


    


}
