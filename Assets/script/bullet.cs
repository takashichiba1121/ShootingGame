using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //���̃��[���h���W���擾
        Vector3 pos = transform.position;

        //��ɂ܂��������
        pos.z += 0.5f;

        //�e�̈ړ�
        transform.position = pos;

        //��苗���i�񂾂���ł���
        if(pos.z>=20)
        {
            Destroy(this.gameObject);
        }
    }

    //�����蔻��p�֐�
    void OnTriggerEnter(Collider other)
    {
        //�������������I�u�W�F�N�g�̃^�O��Enemy��������
        if(other.gameObject.tag=="Enemy")
        {
            /*���������I�u�W�F�N�g��Enemy�X�N���v�g��
             �Ăяo����Damage�֐������s������*/
            other.GetComponent<Enemy>().Damage();
        }
    }
}
