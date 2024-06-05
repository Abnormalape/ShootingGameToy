using System.IO;
using UnityEngine;

// 게임 결과 관련 기능을 담당하는 스크립트.
// 파일에서 게임 결과를 읽어와 화면에 보여주는 기능.
public class GameResult : MonoBehaviour
{
    //텍스트 UI 참조 변수.
    [SerializeField] private TMPro.TextMeshProUGUI scoreTerxt;
    [SerializeField] private TMPro.TextMeshProUGUI bestScoreText;
    //컴포넌트 활성화시 실행.
    private void OnEnable()
    {
        //게임 결과 파일 로드.
        // 1. 파일을 불러와 문자열로 읽어오기.
        string jsonstring = File.ReadAllText("Assets/Scroe.txt");


        // 2. 불러온 문자열 값을 객체로 복원(역질렬)
        var score = JsonUtility.FromJson<Score>(jsonstring);
        //int bestScore = score.bestScore;

        scoreTerxt.text = $"score : {score.score}";
        bestScoreText.text = $"bestscore : {score.bestScore}";



        //로드한 파일을 데이터 객체로 역직렬화.

        //객체로부터 점수 값을 읽어와 텍스트에 표기.
    }


    // Restart 버튼이 눌리면 실행될 함수.
    public void OnRestartClicked()
    {
        SceneManager.LoadScene("GameScene");
    }

    // Quit 버튼이 눌리면 실행될 함수.
    public void OnQuitClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        Application.Quit();
    }
}
