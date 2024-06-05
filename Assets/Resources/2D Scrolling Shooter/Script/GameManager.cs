using UnityEngine;
using UnityEngine.SceneManagement;

class GameManager : MonoBehaviour
{
    //
    public static GameManager Instance { get; private set; }

    //게임 시작을 알려주는 프로퍼티
    public bool IsGameStarted { get; private set; }


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnPlayerDead()
    {
        // 게임시작값을 false로.
        IsGameStarted = false;
        //  점수저장.
        ScoreManager.Instance.SaveScore();
        // 결과 씬 로드.
        SceneManager.LoadScene("GameEndScene");
    }


    public void OnFadeAnimationEnd()
    {
        IsGameStarted = true;
    }



}
