using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Text;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Cameras;

public class LevelManager : MonoBehaviour {

    public Text score;
    public Menu DeathMenu;
    public int points;
    public Text finalScore;
    public GameObject CameraRig;
    public int SceneId=3;
    private StringBuilder sb;
    private MenuManager menuManager;
    private int currentLevel;
    
    public GameObject canvas;
    [SerializeField]
    private static PlayerPowers playerId;
    
    void Start()
    {
        sb = new StringBuilder();
        menuManager = GameObject.FindGameObjectWithTag("MenuManager").GetComponent<MenuManager>();
        gameObject.SetActive(true);
        SceneDetail.ChangeScene += ChangeScene;
    }
    
    void OnDisable()
    {
        SceneDetail.ChangeScene -= ChangeScene;
    }
    

    private void ChangeScene(object sender, EventArgs e)
    {
        
        var d = Instantiate(GameManager.Instance.playerPower.playerPrefap, new Vector3(0, 0, 0), Quaternion.identity);
        GameObject ds = (GameObject)d;
        ds.SetActive(true);
        ds.GetComponent<PlayerSetup>().StartPlaying();
        print("create player");
        CameraRig.GetComponent<AutoCam>().SetTarget(ds.transform);
        SceneDetail.ChangeScene -= ChangeScene;
    }

    public void SetPlayerID(PlayerPowers player)
    {
        playerId = player;
        print("set palyer");
        GameManager.Instance.playerPower = player;
    }


    public void AddPoint(int value)
    {
        points += value;
        sb.Append(points);
        score.text = sb.ToString();
        sb.Remove(0, sb.Length);
    }

    public void StartGame()
    {
       SceneManager.LoadSceneAsync(SceneId);

    }

    

    internal void HitTrap(int trapType)
    {
        menuManager.OpenMenu(DeathMenu);
        Time.timeScale = 0;
        finalScore.text += points.ToString();
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void UnPausedGame()
    {
        Time.timeScale = 1;
    }
    public void RestartLevel()
    {
        Time.timeScale = 1;
        int s = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(s);
    }
    public void OpenMenu(Menu menu)
    {
        menuManager.OpenMenu(menu);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadScene(int idScene)
    {
        //SceneManager.LoadSceneAsync(idScene);
        Application.LoadLevel(idScene);
    }

}
