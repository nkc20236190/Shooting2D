using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public Text kyoriLabel; // 距離表示テキストオブジェクト保存
    public Text shotLabel;  // 弾の強さ表示テキストオブジェクト保存
    public Image timeGauge; // 残り時間ゲージ画像オブジェクト保存

    public GameObject itemPre; // アイテムプレハブ保存

    // プレーヤーコントローラーコンポーネント保存
    PlayerController playerCon; 

    // 残り時間を他のスクリプトから変更するための宣言 public static
    public static float lastTime;

    // 距離計算用
    public static int kyori;              

    // 距離の値を他のスクリプトから変更するためのプロパティ
    // (public staticを使わない方法)
    public int Kyori
    {
        set
        {
            kyori = value;
            kyori = Mathf.Clamp(kyori, 0, 999999);
        }
        get { return kyori; }
    }

    void Start()
    {
        kyori = 0;
        lastTime = 60;
        playerCon = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        // 距離を60 km/s の速さで増やす
        kyori++;
        kyoriLabel.text = kyori.ToString("D6") + "km";

        // 距離が600kmで割り切れるときにアイテム出現
        if(kyori % 600 == 0)
        {
            Instantiate(itemPre);
        }

        // プレーヤーの弾レベルを取得して表示
        shotLabel.text = "ShotLevel " + playerCon.ShotLevel.ToString("D2");

        // 制限時間とゲージを減らす処理
        lastTime -= Time.deltaTime;
        timeGauge.fillAmount = lastTime / 60f;

        // 制限時間が０より小さくなったらタイトルシーンへ
        if(lastTime < 0)
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}

