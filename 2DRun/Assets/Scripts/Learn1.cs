using UnityEngine;

public class Learn1 : MonoBehaviour
{
    private void Start()
    {
        // 靜態成員用法
        // 靜態屬性 property = 欄位 Field (儲存資料)
        // 語法: 類別名稱.靜態屬性名稱(區間);
        print(Mathf.PI);
        print(Random.value);
        print(Random.Range(100,501));

        Test();
        Skill("火");
        Skill("水");

    }

    private void Update()
    {
        //print(Time.time);
    }

    // 方法
    //1. 可以被按鈕呼叫

    // 語法
    // 修飾詞 傳回類型 方法名稱 () {}
    // void 無傳回
    public void Test()
    {
        print("我是測試方法");
    }


    public void Skill(string s)
    {
        print("施放技能 " + s);
        print("播放音效");
    }
}


