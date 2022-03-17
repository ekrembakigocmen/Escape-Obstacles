using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class SpawnPointsManager : MonoBehaviour
{
    public GameObject SpawnPointRed1;
    public GameObject SpawnPointRed2;
    public GameObject SpawnPointGreen1;
    public GameObject SpawnPointGreen2;
    public GameObject Obs;
    public GameObject ScorPanel;
    public GameObject Player;
    public Button ContinueButton;
    public TextMeshProUGUI TimerTxt;
    public TextMeshProUGUI LevelTxt;
    public TextMeshProUGUI SpeedTxt;
    public TextMeshProUGUI LastScorTxt;
    public TextMeshProUGUI HealthPointTxt;
    public float CurrentSliderValue = 8f;
    public static bool IsContinue = false;
    float Spawntimer = 2f;
    bool isUse = true;
    int ObsCount = 0;
    int TimesUp = 0;
    int Level = 1;
    int Leveltimer = 20;
    int CurrentObsCount = 10;

   
    void Update()
    {

        if (ObsCount <= 0)
        {
            StartCoroutine(SpawnTime());

        }
        if (TimesUp <= 0)
        {
            StartCoroutine(LevelTimer());
        }
        if (Obstacles.Coll)
        {
            

            ScorPanel.SetActive(true);
            Time.timeScale = 0f;
            SaveManager.LoadData();
            int health = ScorData.Health;
            HealthPointTxt.text = "Health Point: " + health.ToString();
            LastScorTxt.text = "Scor \n" + Player.GetComponent<CharacterManager>().Scor.ToString();
            ScorData.Scor = HighScore();
            SaveManager.SaveData();


            if (health >= 1 && isUse)
            {
                ContinueButton.interactable = true;
            }
            else
            {
                ContinueButton.interactable = false;
            }
        }
    }


    void Initialize(int x)
    {
        if (0 == x)
        {
            Instantiate(Obs, SpawnPointRed1.transform.position, Quaternion.identity);
        }
        if (1 == x)
        {
            Instantiate(Obs, SpawnPointRed2.transform.position, Quaternion.identity);
        }
        if (2 == x)
        {
            Instantiate(Obs, SpawnPointGreen1.transform.position, Quaternion.identity);
        }
        if (3 == x)
        {
            Instantiate(Obs, SpawnPointGreen2.transform.position, Quaternion.identity);
        }



    }


    IEnumerator SpawnTime() // obs lerin  -timer- degeri suresince ve x degerine gore uretim dongusu
    {
        ObsCount++;

        for (int i = 1; i <= CurrentObsCount; i++)
        {

            int x = Random.Range(0, 4);
            Initialize(x);
            yield return new WaitForSecondsRealtime(Spawntimer);

            if (i == CurrentObsCount && Obstacles.Coll == false)
            {
                ObsCount--;
            }
        }

    }

    IEnumerator LevelTimer() // Her sure bittiginde guncellenen degerler
    {
        TimesUp++;

        for (int i = Leveltimer; i >= 0; i--)
        {
            TimerTxt.text = i.ToString();
            yield return new WaitForSeconds(1f);


            if (i == 0)
            {
                CurrentSliderValue += 2f;
                SpeedTxt.text = "Speed: " + CurrentSliderValue.ToString();
                if (Leveltimer > 11)
                {
                    Leveltimer -= 2;
                }
                CurrentObsCount += 2;
                CharacterManager.speed +=4f;
                if (Spawntimer > 1.1f)
                {
                    Spawntimer -= .1f;
                }
                TimesUp--;
                Level++;
                LevelTxt.text = "Level: " + Level.ToString();
                
            }
        }
    }

    public void MenuBtn()
    {
        Obstacles.Coll = false;
        ScorPanel.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");

    }

    public int HighScore()
    {
        SaveManager.LoadData();
        int x = ScorData.Scor;

        return x = Mathf.Max(x, Player.GetComponent<CharacterManager>().Scor);
    }

    public void ContinueBtn()
    {
        SaveManager.LoadData();
        int health = ScorData.Health;
        health--;
        ScorData.Health = health;
        SaveManager.SaveData();
        IsContinue = true;
        ScorPanel.SetActive(false);
        Obstacles.Coll = false;
        isUse = false;
        Time.timeScale = 1f;

    }


}
