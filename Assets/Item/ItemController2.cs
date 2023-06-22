using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController2 : MonoBehaviour
{
    SpriteRenderer spRender;    // レンダラーコンポーネント取得
    Vector3 pos;                // 出現位置
    int itemType;               // アイテムの種類
    float speed;                // 落下速度

    void Start()
    {
        itemType = Random.Range(0, 4);  // アイテムの種類0～3
        speed = 6f;                     // 落下速度

        // itemType=0:赤 / itemType=1:緑 / itemType=2:青 / itemType=3:黒
        Color[] col = { Color.red, Color.magenta, Color.blue,Color.black };
        spRender = GetComponent<SpriteRenderer>();
        spRender.color = col[itemType];

        // 出現位置
        pos.x = Random.Range(-8f, 8f);
        pos.y = 6f;
        pos.z = 0;
        transform.position = pos;

        // 寿命3秒
        Destroy(gameObject, 3f); 
    }

    void Update()
    {
        // 下方向に speed m/s で移動
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    // 重なり判定
    void OnTriggerEnter2D(Collider2D c)
    {
        // 重なった相手のタグが【Player】だったら
        if (c.gameObject.tag == "Player")
        {
            // PlayerControllerコンポーネントを保存
            PlayerController pCon = c.gameObject.GetComponent<PlayerController>();

            // アイテムの種類別に処理を変更
            if (itemType == 0)       // 赤：弾レベル＋１
            {
                pCon.ShotLevel += 1; 
            }
            else if (itemType == 1)  // 緑：スピード＋５
            {
                pCon.Speed += 5;     
            }
            else if (itemType == 2)  // 青：弾レベル０　スピード５
            {
                pCon.Speed     = 5;
                pCon.ShotLevel = 0;
            }
            else if (itemType ==3)  // 黒：弾レベル3　スピード５
            {
                pCon.Speed = 5;
                pCon.ShotLevel = 3;
            }

            // 自分（アイテム）削除
            Destroy(gameObject);
        }
    }
}
