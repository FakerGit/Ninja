using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using System;
using System.IO;
using System.Collections.Generic;
using cn.bmob.api;
using cn.bmob.io;

using cn.bmob.tools;
using System.Net;
public class GameController : MonoBehaviour {
    public static GameController _instance;
    public GameObject deadMenu;
    public Text titleText;

    private int score;
    public Text scoreText;

    private bool showMenu;

    //确定名字
    private string playerName;
    public Text nameText;
    public GameObject nameMenu;

    //上传
    private BmobUnity bmobUnity;
    private bool ifSend; //是否上传过数据
    void Awake()
    {
        _instance = this;
        showMenu = false;
    }
	// Use this for initialization
	void Start () {
        score = 0;
        playerName = "Mage";
        setName();
        bmobUnity = GetComponent<BmobUnity>();
        ifSend = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //显示名字菜单
    public void setName()
    {
        if (playerName == null)
        {
            nameMenu.SetActive(true);
        }
    }

    //设置名字
    public void set()
    {
        playerName = nameText.text;
        nameMenu.SetActive(false);
    }


    public void GameOver()
    {
        deadMenu.SetActive(true);
    }

    public void ShowMenu()
    {
        showMenu = !showMenu;
        Time.timeScale = 0;
        deadMenu.SetActive(showMenu);
    }


    public void Continue()
    {
        showMenu = !showMenu;
        deadMenu.SetActive(showMenu);
        Time.timeScale = 1;
    }
    public void LoadLevel(string sceneName)
    {
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }
        Application.LoadLevel(sceneName);
    }

    public void AddScore(int point)
    {
        score += point;
        scoreText.text = "Score: " + score;
    }

    public void SetScore(int s)
    {
        score = s;
        scoreText.text = "Score: "+score;
    }

    public void FinishLevel()
    {
        var data =new ScoreRank();
        data.score=score;
        if (ifSend)
        {

        }
        else
        {
            bmobUnity.Create("scoreRank", data, (resp, exception) =>
                {
                    if (exception != null)
                    {
                        print("保存失败，失败原因为 " + exception.Message);
                        return;
                    }
                    ifSend = true;
                    print("保存成功，@" + resp.createdAt);
                });
            
        }
        showMenu = !showMenu;
        deadMenu.SetActive(showMenu);
        titleText.text = "MISSION Finish";
    }
}
