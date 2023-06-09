using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject ExploPre; // 爆発のプレハブを保存
    public GameObject ShotPre;  // 弾のプレハブを保存
    float speed;                // 移動速度を保存
    Vector3 dir;                // 移動方向を保存
    int enemyType;              // 敵の種類を保存
    float rad;                  // 敵の動きサインカーブ用
    float shotTime;             // 弾の発射間隔計算用
    float shotInterval = 2f;    // 弾の発射間隔
    GameDirector gd;            // GameDirectorコンポーネントを保存

    AudioClip seClip;  // 効果音を保存する変数
    AudioClip dioClip;
    Vector3 sePos;       // 効果音を再生する位置を保存する変数

    void Start()
    {
        Destroy(gameObject, 6);		    // 寿命
        enemyType = Random.Range(0, 4); // 敵の種類
        speed = 5;                      // 移動速度
        dir = Vector3.left;             // 移動方向
        rad = Time.time;                // サインカーブの動きをずらす用
        shotTime = 0;                   // 弾発射間隔計算用

        // GameDirectorコンポーネントを保存
        gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();

        seClip = Resources.Load<AudioClip>("Audio/SE/maou_se_battle_explosion06");
        dioClip = Resources.Load<AudioClip>("Audio/SE/maou_se_battle18");
        sePos = GameObject.Find("Main Camera").transform.position;

    }

    void Update()
    {
        // エネミータイプ２だけ縦移動（サインカーブ）追加
        if(enemyType == 2)
        {
            dir.y = Mathf.Sin(rad + Time.time * 2f);
        }
        if(enemyType == 3)
        {
            dir.x = Mathf.Cos(rad + Time.time * 1f);
        }

        // 移動処理
        transform.position += dir.normalized * speed * Time.deltaTime;

        // 敵の弾の生成
        shotTime += Time.deltaTime;
        if (shotTime > shotInterval)
        {
            shotTime = 0;
            Instantiate(ShotPre, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(dioClip, sePos);
        }
    }

    // 重なり判定処理
    void OnTriggerEnter2D(Collider2D other)
    {
        // 重なった相手のタグが【Player】だったら
        if (other.tag == "Player")
        {
            // 距離を減らす
            gd.Kyori -= 1000;

            // 制限時間を3秒減らす
            GameDirector.lastTime -= 3f;

            // 重なった相手が衝突爆発を生成
            Instantiate(ExploPre, transform.position, transform.rotation);

            // 自分（敵）削除
            Destroy(gameObject);

            AudioSource.PlayClipAtPoint(seClip, sePos);
        }

        // 重なった相手のタグが【PlayerShot】だったら
        if (other.tag == "PlayerShot")
        {
            // 距離を増やす
            gd.Kyori += 200;

            // 重なった相手が衝突爆発を生成
            Instantiate(ExploPre, transform.position, transform.rotation);

            // 自分（敵）削除
            Destroy(gameObject);

            
            AudioSource.PlayClipAtPoint(seClip, sePos);

        }
    }
}