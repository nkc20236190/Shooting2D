using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public Text kyoriLabel;  // 距離を表示するUI-Textオブジェクト
    int kyori;               // 距離を保存する変数

    public Image timeGauge;  // タイムゲージを表示するUI

    float lastTime;          // 残り時間を保存する変数

    void Start()
    {
        kyori = 0;
        lastTime = 100f; // 残り時間100秒
    }

    
    void Update()
    {
        // 進んだ距離を表示
        kyori++;
        kyoriLabel.text = kyori.ToString("D6") + "km";

        // 残り時間を減らす処理
        lastTime -= Time.deltaTime;
        timeGauge.fillAmount = lastTime / 100f;

        // 残り時間を０になったらリロード
        if (lastTime > 0)
        {
            SceneManager.LoadScene("GameScene");
        }

        
    }
}
