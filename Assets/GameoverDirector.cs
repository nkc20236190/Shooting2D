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
        // ���N���b�N�܂��̓Q�[���p�b�h�̃{�^���O�ŃX�^�[�g
        if (Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
