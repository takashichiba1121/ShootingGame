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
        //球のワールド座標を取得
        Vector3 pos = transform.position;

        //上にまっすぐ飛ぶ
        pos.z += 0.5f;

        //弾の移動
        transform.position = pos;

        //一定距離進んだら消滅する
        if(pos.z>=20)
        {
            Destroy(this.gameObject);
        }
    }

    //当たり判定用関数
    void OnTriggerEnter(Collider other)
    {
        //もし当たったオブジェクトのタグがEnemyだったら
        if(other.gameObject.tag=="Enemy")
        {
            /*当たったオブジェクトのEnemyスクリプトを
             呼び出してDamage関数を実行させる*/
            other.GetComponent<Enemy>().Damage();
        }
    }
}
