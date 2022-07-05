using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    //�q�I�u�W�F�N�g�̃T�C�Y�����邽�߂̕ϐ�
    private float Left, Right, Top, Bottom;

    //�J�������猩����ʍ����̍��W������ϐ�
    Vector3 LeftBottom;

    //�J�������猩����ʉE���̍��W������ϐ�
    Vector3 RightTop;

    // Start is called before the first frame update
    void Start()
    {
        //�q�I�u�W�F�N�g�̐��������[�v�������s��
        foreach (Transform child in gameObject.transform)
        {
            //�q���I�u�W�F�N�g�̒��ň�ԉE�̈ʒu�ɂ����Ȃ�
            if (child.localPosition.x >= Right)
            {
                //�q�I�u�W�F�N�g�̃��[�J��x���W���E�[�p�̕ϐ��ɑ������
                Right = child.transform.localPosition.x;
            }

            //�q���I�u�W�F�N�g�̒��ň�ԉE�̈ʒu�ɂ����Ȃ�
            if (child.localPosition.x <= Left)
            {
                //�q�I�u�W�F�N�g�̃��[�J��x���W���E�[�p�̕ϐ��ɑ������
                Left = child.transform.localPosition.x;
            }
            //�q���I�u�W�F�N�g�̒��ň�ԉE�̈ʒu�ɂ����Ȃ�
            if (child.localPosition.z >= Top)
            {
                //�q�I�u�W�F�N�g�̃��[�J��x���W���E�[�p�̕ϐ��ɑ������
                Top = child.transform.localPosition.z;
            }
            //�q���I�u�W�F�N�g�̒��ň�ԉE�̈ʒu�ɂ����Ȃ�
            if (child.localPosition.z >= Bottom)
            {
                //�q�I�u�W�F�N�g�̃��[�J��x���W���E�[�p�̕ϐ��ɑ������
                Bottom = child.transform.localPosition.z;
            }
        }
        //�J�����ƃv���C���[�̋����𑪂�i�\���`���̎l����ݒ肵�邽�߂ɕK�v�j
        var distaance = Vector3.Distance(Camera.main.transform.position, transform.position);

        //�X�N���[����ʍ����Ɉʒu��ݒ肷��
        LeftBottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distaance));

        //�X�N���[���E��̈ʒu��ݒ肷��
        RightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distaance));
    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���[�̃��[���h���W���擾
        Vector3 pos = transform.position;   
        
        //�E���L�[�����͂��ꂽ�Ƃ�
        if(Input.GetKey(KeyCode.RightArrow))
        {
            //�E������0.01����
            pos.x += 0.1f;
        }
        //�����L�[�����͂��ꂽ�Ƃ�
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            //��������0.01����
            pos.x -= 0.1f;
        }
        //����L�[�����͂��ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //�������0.01����
            pos.z += 0.1f;
        }
        //�����L�[�����͂��ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //��������0.01����
            pos.z -= 0.1f;
        }
        transform.position=new Vector3(
            Mathf.Clamp(pos.x,LeftBottom.x+transform.localScale.x-Left,RightTop.x-transform.localScale.x-Right),
            pos.y,
            Mathf.Clamp(pos.z, LeftBottom.z + transform.localScale.z-Bottom, RightTop.z - transform.localScale.z-Top));
    }
}
