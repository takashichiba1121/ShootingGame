using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{

    //����������p�[�e�B�N����ݒ�
    public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //�L�[�{�[�h��B�L�[�������ꂽ��
        if (Input.GetKeyDown(KeyCode.B))
        {
            //�^�O�������I�u�W�F�N�g��S�ď�������
            GameObject[] enemyBulletObjects =
                GameObject.FindGameObjectsWithTag("Enemy bullet");

            //��ŏ��������S�ẴI�u�W�F�N�g��S�ď��ł�����
            for (int i = 0; i < enemyBulletObjects.Length; i++)
            {
                Destroy(enemyBulletObjects[i].gameObject);
            }

            //�p�[�e�B�N�����������I�u�W�F�N�g�𐶐�����
            Instantiate(particle, Vector3.zero, Quaternion.identity);
        }
    }
}
