using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameDirector : MonoBehaviour{

    //【カウントダウン実装】

    GameObject timerText;
    GameObject pointText;
    float time = 30.0f;
    //time変数を、60秒に初期化。
    int point = 0;
    //加算ポイント、減点ポイントの数値を入れるために
    //変数に初期値を代入。
    GameObject generator;

    public void GetApple()
    {
        this.point += 100;
    }

    public void GetBomb()
    {
        this.point /= 2;

    }

    // Use this for initialization
    void Start()
    {
        this.generator = GameObject.Find("ItemGenerator");
        this.timerText = GameObject.Find("Time");
        this.pointText = GameObject.Find("Point");

        if (generator)
        {
            Debug.Log(generator.name);
        }
        else
        {
            Debug.Log("No game object called ItenGenerator found");
        }
    }


        // Update is called once per frame
        void Update()
        {
            this.time -= Time.deltaTime;

            if (this.time < 0)
            {
                this.time = 0;
                this.generator.GetComponent<ItemGenerate>().SetParameter(10000.0f, 0, 0);
            }
            else if (0 <= this.time && this.time < 5)
            {
                this.generator.GetComponent<ItemGenerate>().SetParameter(0.9f, -0.04f, 3);
            }
            else if (5 <= this.time && this.time < 10)
            {
                this.generator.GetComponent<ItemGenerate>().SetParameter(0.4f, -0.06f, 6);
            }
            else if (10 <= this.time && this.time < 20)
            {
                this.generator.GetComponent<ItemGenerate>().SetParameter(0.7f, -0.04f, 4);
            }
            else if (20 <= this.time && this.time < 30)
            {
                this.generator.GetComponent<ItemGenerate>().SetParameter(1.0f, -0.03f, 2);
            }

            this.timerText.GetComponent<Text>().text =
                this.time.ToString("F1");
            //制限時間は小数点以下第1位まで表示したいので、
            //F1を指定。

            this.pointText.GetComponent<Text>().text =
                    this.point.ToString() + "point";


        }
    }

