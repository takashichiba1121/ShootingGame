using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    //子オブジェクトのサイズを入れるための変数
    private float Left, Right, Top, Bottom;

    //カメラから見た画面左下の座標を入れる変数
    Vector3 LeftBottom;

    //カメラから見た画面右下の座標を入れる変数
    Vector3 RightTop;

    // Start is called before the first frame update
    void Start()
    {
        //子オブジェクトの数だけループ処理を行う
        foreach (Transform child in gameObject.transform)
        {
            //子をオブジェクトの中で一番右の位置にいたなら
            if (child.localPosition.x >= Right)
            {
                //子オブジェクトのローカルx座標を右端用の変数に代入する
                Right = child.transform.localPosition.x;
            }

            //子をオブジェクトの中で一番右の位置にいたなら
            if (child.localPosition.x <= Left)
            {
                //子オブジェクトのローカルx座標を右端用の変数に代入する
                Left = child.transform.localPosition.x;
            }
            //子をオブジェクトの中で一番右の位置にいたなら
            if (child.localPosition.z >= Top)
            {
                //子オブジェクトのローカルx座標を右端用の変数に代入する
                Top = child.transform.localPosition.z;
            }
            //子をオブジェクトの中で一番右の位置にいたなら
            if (child.localPosition.z >= Bottom)
            {
                //子オブジェクトのローカルx座標を右端用の変数に代入する
                Bottom = child.transform.localPosition.z;
            }
        }
        //カメラとプレイヤーの距離を測る（表示形式の四隅を設定しるために必要）
        var distaance = Vector3.Distance(Camera.main.transform.position, transform.position);

        //スクリーン画面左下に位置を設定する
        LeftBottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distaance));

        //スクリーン右上の位置を設定する
        RightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distaance));
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーのワールド座標を取得
        Vector3 pos = transform.position;   
        
        //右矢印キーが入力されたとき
        if(Input.GetKey(KeyCode.RightArrow))
        {
            //右方向に0.01動く
            pos.x += 0.1f;
        }
        //左矢印キーが入力されたとき
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            //左方向に0.01動く
            pos.x -= 0.1f;
        }
        //上矢印キーが入力されたとき
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //上方向に0.01動く
            pos.z += 0.1f;
        }
        //下矢印キーが入力されたとき
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //下方向に0.01動く
            pos.z -= 0.1f;
        }
        transform.position=new Vector3(
            Mathf.Clamp(pos.x,LeftBottom.x+transform.localScale.x-Left,RightTop.x-transform.localScale.x-Right),
            pos.y,
            Mathf.Clamp(pos.z, LeftBottom.z + transform.localScale.z-Bottom, RightTop.z - transform.localScale.z-Top));
    }
}
