using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotController : MonoBehaviour
{
    Vector3 dir;        // 移動方向
    float speed;        // 移動速度
    GameDirector gd;    // GameDirectorコンポーネント保存
    Transform player;   // プレーヤーのトランスフォームコンポーネントを保存

    void Start()
    {
        // プレーヤーの情報を保存
        player = GameObject.Find("Player").transform;
        
        // 弾の速度
        speed = 12f;

        // 弾の発射方向（敵の現在地から見たプレーヤーの方向）
        dir = player.position - transform.position;

        // GameDirectorコンポーネントを取得
        gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();

        // 寿命
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        // 移動処理
        transform.position += dir.normalized * speed * Time.deltaTime;        
    }

    // 重なり判定  
    void OnTriggerEnter2D(Collider2D c)
    {
        // 重なった相手のタグが【Player】だったら
        if (c.tag == "Player")
        {
            // 制限時間を1秒減らす
            GameDirector.lastTime -= 1f;
            gd.Kyori -= 500;        // 距離を減らす
            Destroy(gameObject);    // 自分（敵弾）削除
        }
    }

}
