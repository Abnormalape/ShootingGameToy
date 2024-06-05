using System.IO;
using UnityEngine;

// ���� ��� ���� ����� ����ϴ� ��ũ��Ʈ.
// ���Ͽ��� ���� ����� �о�� ȭ�鿡 �����ִ� ���.
public class GameResult : MonoBehaviour
{
    //�ؽ�Ʈ UI ���� ����.
    [SerializeField] private TMPro.TextMeshProUGUI scoreTerxt;
    [SerializeField] private TMPro.TextMeshProUGUI bestScoreText;
    //������Ʈ Ȱ��ȭ�� ����.
    private void OnEnable()
    {
        //���� ��� ���� �ε�.
        // 1. ������ �ҷ��� ���ڿ��� �о����.
        string jsonstring = File.ReadAllText("Assets/Scroe.txt");


        // 2. �ҷ��� ���ڿ� ���� ��ü�� ����(������)
        var score = JsonUtility.FromJson<Score>(jsonstring);
        //int bestScore = score.bestScore;

        scoreTerxt.text = $"score : {score.score}";
        bestScoreText.text = $"bestscore : {score.bestScore}";



        //�ε��� ������ ������ ��ü�� ������ȭ.

        //��ü�κ��� ���� ���� �о�� �ؽ�Ʈ�� ǥ��.
    }


    // Restart ��ư�� ������ ����� �Լ�.
    public void OnRestartClicked()
    {
        SceneManager.LoadScene("GameScene");
    }

    // Quit ��ư�� ������ ����� �Լ�.
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
