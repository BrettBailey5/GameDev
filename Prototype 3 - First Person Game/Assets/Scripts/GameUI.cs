using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;  //If you want to load multiple scenes you HAVE to have this Library

public class GameUI : MonoBehaviour
{
    [Header("Hud")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI ammoText;
    public Image healthBarFill;

    [Header("Pause Menu")]
    public GameObject pauseMenu;

    [Header("End Game Screen")]
    public GameObject endGameScreen;
    public TextMeshProUGUI endGameHeaderText;
    public TextMeshProUGUI endGameScoreText;

    // Instance (Create a Singleton for GUI Script) Singleton = a single instance of a class we're going to reference.
    public static GameUI instance;

    void Awake()
    {
        //Set the instance to this script
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealthBar(int curHP, int maxHP)
    {
        healthBarFill.fillAmount = (float)curHP / (float)maxHP;
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void UpdateAmmoText(int curAmmo, int maxAmmo)
    {
        ammoText.text = "Ammo: " + curAmmo + " / " + maxAmmo;
    }

    public void TogglePauseMenu( bool paused)
    {
        
    }
}
