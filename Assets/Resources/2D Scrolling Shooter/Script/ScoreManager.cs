
using UnityEngine;

class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance = null;

    [SerializeField] private Score score = new Score();
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    [SerializeField] private TMPro.TextMeshProUGUI bestScoreText;
    //private void Awake()
    //{
    //    if(score== null)
    //    {
    //        score = new Score();
    //    }
    //}

    public static ScoreManager Instance
    {
        get { return instance; }
    }
    public static ScoreManager Get()
    {
        return instance;
    }

    public void AddScore(int gainScore)
    {
        score.Add(gainScore);
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        score.SetTextUI(scoreText, bestScoreText);
        score.Initialize();    
    }

}
