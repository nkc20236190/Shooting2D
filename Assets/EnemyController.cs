using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Vector3 dir = Vector3.zero;  // �ړ�����
    float speed = 5;�@�@�@�@�@�@ // �ړ����x

    void Start()
    {
        // ����4�b
        Destroy(gameObject, 4f);
    }

    void Update()
    {
        // �ړ�����������
        dir = Vector3.left;

        // ���ݒn�Ɉړ��ʂ����Z
        transform.position += dir.normalized * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �������Ԃ�10�b���炷
        GameDirector.lastTime -= 10f;

        // �������̃I�u�W�F�N�g�Əd�Ȃ��������
        Destroy(gameObject);
    }
}
