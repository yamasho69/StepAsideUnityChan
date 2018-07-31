using UnityEngine;
using System.Collections;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;
    //(ゲームの）スタート地点
    private int unityStart = -245;
    //(アイテムを置く)スタート地点
    private int startPos = -160;
    //ゴール地点
    private int goalPos = 120;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;
    //ユニティちゃんを入れる
    private GameObject unitychan;
    //アイテムをユニティちゃんから何ｍ先に生成するか
    private int itemGenerationOffset = 50;
    //アイテムを生成する間隔
    private int itemGenerationInterval = 15;

    // Use this for initialization
    void Start()
    {
        //ユニティちゃんを見つける
        unitychan = GameObject.Find("unitychan");
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(this.unitychan.transform.position.z);//unityちゃんのz座標を取得

        //unityちゃんがスタート地点からゴール地点50m前の間にいるとき
        if ((unityStart < this.unitychan.transform.position.z) && (goalPos - 50 > this.unitychan.transform.position.z))
        {
            int i = unityStart + itemGenerationOffset;//変数iを宣言
            int num = Random.Range(1, 11); //numに1から10の範囲の乱数を返却
            if (num <= 2) //numが2以下なら
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f) //jは-1から始まり、1になるまで0.4fずつ増えていく
                {
                    GameObject cone = Instantiate(conePrefab) as GameObject; //GameObject型のconePrefabを生成
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i); //コーンはx座標4×j、y座標はconeを置いた位置、z座標はiに置く
                }
            }
            else
            {
                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++) //jは-1から始まり、1になるまで1ずつ増えていく
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11); //itemに1から10の範囲の乱数を返却
                                                    //アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);//offsetzに-5から5の範囲の乱数を返却
                                                      //60%コイン配置:30%車配置:10%何もなし
                    if (1 <= item && item <= 6) //itemが1以上かつ6以下のとき
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab) as GameObject;
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);//コインはposRange×j、y座標はcoinを置いた位置、z座標はi+offsetzに置く
                    }
                    else if (7 <= item && item <= 9)//itemが7以上9以下のとき
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab) as GameObject;
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);//車はposRange×j、y座標はcarを置いた位置、z座標はi+offsetzに置く
                    }
                }
            }
            unityStart += 15;　//unityStart変数に15を加える
        }
    }
}

