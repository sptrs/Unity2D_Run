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

    }

    private void Update()
    {
        //print(Time.time);
    }
}
