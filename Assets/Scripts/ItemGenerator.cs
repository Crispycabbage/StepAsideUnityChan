using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;//各Prefabの入れ物を宣言最初から出てきているわけでは無いので直接インスペクタで入れる？
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;
    //スタート地点
    private int startPos = 80;
    //ゴール地点
    private int goalPos = 360;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    private float switchpoint = 0f;
    private float placementpoint = 45f;
    private float interval = 15f;



    private GameObject unitychan;//unityちゃんの入れ物を作成

    // Use this for initialization
    void Start()
    {
        this.unitychan = GameObject.Find("unitychan");
        this.switchpoint = this.startPos;
    }

    // Update is called once per frame
    void Update()
    {
        //一定の距離ごとにアイテムを生成
        if (this.goalPos > switchpoint && unitychan.transform.position.z+this.placementpoint >=  this.switchpoint)
            //スイッチポイント＋生成視界がゴールより前、スイッチポイントがユニティちゃんの位置＋生成視界内の時
        {
            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, this.switchpoint);
                }
            }
            else
            {

                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置:30%車配置:10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, this.switchpoint+ offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, this.switchpoint+ offsetZ);
                    }
                }
            }
            this.switchpoint += this.interval;

        }
    }
}