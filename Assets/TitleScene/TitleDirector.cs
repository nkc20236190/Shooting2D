using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleDirector : MonoBehaviour
{
    public Text scoreLabel; // 前回のスコア（距離）表示

    void Start()
    {
        scoreLabel.text = "Score\n" + GameDirector.kyori.ToString("D6");
    }

    void Update()
    {
        // 左クリックまたはゲームパッドのボタン０でスタート
        if(Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
