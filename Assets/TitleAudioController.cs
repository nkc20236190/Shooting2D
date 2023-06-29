using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAudioController : MonoBehaviour
{
    AudioSource audioSource;     // �I�[�f�B�I�\�[�X�R���|�[�l���g�ۑ�
    AudioClip audioClip;�@�@�@�@ // �I�[�f�B�I�N���b�v�ۑ�
    AudioClip[] bgmClip = new AudioClip[1];  // �I�[�f�B�I�N���b�v�ۑ��i1�ȕ��j

    void Start()
    {
        // Resources�t�H���_���ɕۑ�����Ă���I�[�f�B�I�t�@�C����ǂݍ���
        //bgmClip[0] = Resources.Load<AudioClip>("Audio/BGM/bgm_maoudamashii_8bit25");
        //bgmClip[1] = Resources.Load<AudioClip>("Audio/BGM/bgm_maoudamashii_8bit28");
        //bgmClip[2] = Resources.Load<AudioClip>("Audio/BGM/bgm_maoudamashii_8bit29");

        string[] bgmName =
        {
            "Audio/BGM/Kirby Mass Attack - Kirby SHMUP Title Theme", // bgmName[0]
        };


        // Resources�t�H���_���ɕۑ�����Ă���I�[�f�B�I�t�@�C����ǂݍ���
        audioClip = Resources.Load<AudioClip>("Audio/BGM/Kirby Mass Attack - Kirby SHMUP Title Theme");

        // �I�[�f�B�I�\�[�X�R���|�[�l���g�̏����擾
        audioSource = GetComponent<AudioSource>();

        // �I�[�f�B�I�\�[�X�ɃI�[�f�B�I�N���b�v���Z�b�g����
        audioSource.clip = audioClip;

        //  �I�[�f�B�I�\�[�X�ɓo�^����Ă���I�[�f�B�I�N���b�v���Đ�����
        audioSource.Play();

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // �Đ�����I�[�f�B�I�N���b�v�����ւ���
            audioSource.clip = bgmClip[0];

            // �Z�b�g���ꂽ�I�[�f�B�I�N���b�v���Đ�����
            audioSource.Play();
        }

    }
}
