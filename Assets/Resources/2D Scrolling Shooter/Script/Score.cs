using System.IO;
using UnityEngine;




[System.Serializable]
public class Score
{
    [SerializeField] public int score = 0;
    [SerializeField] public int bestScore = 0;

    private TMPro.TextMeshProUGUI scoreText;
    private TMPro.TextMeshProUGUI bestScoreText;
    public void Initialize()
    {
        bestScore = PlayerPrefs.GetInt("BestScore");


        string jsonstring = File.ReadAllText("Assets/Score.txt");

        bestScore = JsonUtility.FromJson<Score>(jsonstring).bestScore;


        if (scoreText != null)
        {
            scoreText.text = $"score : {score}";
        }
        if (bestScoreText != null )
        {
            bestScoreText.text = $"BestScore : {bestScore}";
        }
    }

    public void SetTextUI(TMPro.TextMeshProUGUI scoreText, TMPro.TextMeshProUGUI bestScoreText)
    {
        this.scoreText = scoreText;
        this.bestScoreText = bestScoreText;
    }

    public void Add(int gainScore)
    {
        score += gainScore;

        if(scoreText != null)
        {
            scoreText.text = $"score : {score}";
        }

        if(score > bestScore)
        {
            bestScore = score;

            PlayerPrefs.SetInt("BestScore",bestScore);

            //JSON���� ���.
            //1.������ ��ü�� JSON���ڿ��� ����(��ȯ).
            string jsonString = JsonUtility.ToJson(this);
            //2.��ȯ�� JSON ���ڿ��� ���Ϸ� ����.
            //2-1.���Ϸ� �����Ϸ��� ���(������ġ)�̸�, Ȯ���ڸ� �����ؾ���.
            File.WriteAllText("Assets/Score.txt", jsonString);


            if (bestScoreText != null)
            {
                bestScoreText.text = $"BestScore : {bestScore}";
            }
        }
    }
    public void Save()
    {
        string jsonstring = JsonUtility.ToJson(this);

        File.WriteAllText("Assets/Score.txt", jsonstring);
    }

    
}
