using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameoverDirector : MonoBehaviour
{
    public Text scoreLabel;

    void Start()
    {
        scoreLabel.text = "Score\n" + GameDirector.kyori.ToString("D6");
    }

    void Update()
    {
        // 左クリックまたはゲームパッドのボタン０でスタート
        if (Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
