using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAudioController : MonoBehaviour
{
    AudioSource audioSource;     // オーディオソースコンポーネント保存
    AudioClip audioClip;　　　　 // オーディオクリップ保存
    AudioClip[] bgmClip = new AudioClip[1];  // オーディオクリップ保存（1曲分）

    void Start()
    {
        // Resourcesフォルダ内に保存されているオーディオファイルを読み込む
        //bgmClip[0] = Resources.Load<AudioClip>("Audio/BGM/bgm_maoudamashii_8bit25");
        //bgmClip[1] = Resources.Load<AudioClip>("Audio/BGM/bgm_maoudamashii_8bit28");
        //bgmClip[2] = Resources.Load<AudioClip>("Audio/BGM/bgm_maoudamashii_8bit29");

        string[] bgmName =
        {
            "Audio/BGM/Kirby Mass Attack - Kirby SHMUP Title Theme", // bgmName[0]
        };


        // Resourcesフォルダ内に保存されているオーディオファイルを読み込む
        audioClip = Resources.Load<AudioClip>("Audio/BGM/Kirby Mass Attack - Kirby SHMUP Title Theme");

        // オーディオソースコンポーネントの情報を取得
        audioSource = GetComponent<AudioSource>();

        // オーディオソースにオーディオクリップをセットする
        audioSource.clip = audioClip;

        //  オーディオソースに登録されているオーディオクリップを再生する
        audioSource.Play();

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 再生するオーディオクリップを入れ替える
            audioSource.clip = bgmClip[0];

            // セットされたオーディオクリップを再生する
            audioSource.Play();
        }

    }
}
