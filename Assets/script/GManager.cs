using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{

    //敵の数を数える用の変数
    private GameObject[] enemy;

    //パネルを登録する
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, false);

        Application.targetFrameRate = 60;

        //パネルを隠す
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //シーンに存在しているEnemyタグを持っているオブジェクト
        enemy = GameObject.FindGameObjectsWithTag("Enemy");

        //シーンに一匹もEnemyがいなくなったら
        if(enemy.Length==0)
        {
            panel.SetActive(true);
        }
    }
}
