using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{

    //発生させるパーティクルを設定
    public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //キーボードのBキーが押されたら
        if (Input.GetKeyDown(KeyCode.B))
        {
            //タグが同じオブジェクトを全て所得する
            GameObject[] enemyBulletObjects =
                GameObject.FindGameObjectsWithTag("Enemy bullet");

            //上で所得した全てのオブジェクトを全て消滅させる
            for (int i = 0; i < enemyBulletObjects.Length; i++)
            {
                Destroy(enemyBulletObjects[i].gameObject);
            }

            //パーティクルを持ったオブジェクトを生成する
            Instantiate(particle, Vector3.zero, Quaternion.identity);
        }
    }
}
