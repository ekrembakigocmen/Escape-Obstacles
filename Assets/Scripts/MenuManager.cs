using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{

    public TextMeshProUGUI highScore;
    public TextMeshProUGUI HealthTxt;


    private void Start()
    {
        
    }
    public void GameHistoryBtn()
    {
        SaveManager.LoadData();
        highScore.text = "High Score \n " + ScorData.Scor.ToString();
        HealthTxt.text = "Health \n" + ScorData.Health.ToString();

    }

    public void StartBtn()
    {

        SceneManager.LoadScene("GameScene");

    }
    public void ExitBtn()
    {

        Application.Quit();

    }
}
