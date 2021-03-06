using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFixedShot : MonoBehaviour
{
    //プレイヤー
    private GameObject player;

    //弾のゲームオブジェクト
    public GameObject bullet;

    //1回で打ち出す弾の数を決める
    public int bulletWayNum = 3;

    //打ち出し弾の間隔を調整する
    public float bulletWaySpace = 30;

    //打ち出す弾の角度を調整する
    public int bulletWayAxis = 0;

    //打ち出す間隔を決める
    public float time = 1;

    //最初に打ち出すまでの時間を決める
    public float delayTime = 1;

    //現在のタイマー時間
    float nowtime = 0;

    private void CreateShotObject(float axis)
    {
        //弾を生成する
        GameObject bulletClone =
        Instantiate(bullet, transform.position, Quaternion.identity);

        //EnemyBulletのゲットコンポーネントを変数として保存
        var bulletObject = bulletClone.GetComponent<Enemybullet>();

        //弾を打ち出したオブジェクトの情報を渡す
        bulletObject.SetCharacterObject(gameObject);

        //弾を打ち出す角度を変更する
        bulletObject.SetForwardAxis(Quaternion.AngleAxis(axis, Vector3.up));

    }

    // Start is called before the first frame update
    void Start()
    {
        //タイマーを初期化
        nowtime = delayTime;
    }

    // Update is called once per frame
    void Update()
    {
        //もしプレイヤーの情報が入ってなかったら
        if (player == null)
        {
            //プロジェクトのPlayerを探して情報を取得する
            player = GameObject.FindGameObjectWithTag("Player");
        }

        //タイマーを減らす
        nowtime -= Time.deltaTime;

        //もしタイマーが0以下になったら
        if (nowtime <= 0)
        {
            //角度調整用の変数
            float bulletWaySpaceSplit = 180;

            //一回で発射する弾数分だけループする
            for (int i = 0; i < bulletWayNum; i++)
            {
                //一回で発射する弾数分だけループする
                CreateShotObject(bulletWaySpace - bulletWaySpaceSplit + transform.localEulerAngles.y);

                bulletWaySpaceSplit += (bulletWaySpace / (bulletWayNum - 1)) * 2;
            }
            //タイマーを初期化
            nowtime = time;
        }
    }
}
