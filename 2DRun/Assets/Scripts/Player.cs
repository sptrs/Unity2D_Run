using UnityEngine;

public class Player : MonoBehaviour
{

    #region 欄位區域
    /*
    // 命名規則
    // 1. 用有意義的名稱
    // 2. 不要使用數字開頭
    // 3. 不要用特殊符號

    // 欄位語法
    // 修飾詞 類型 欄位名稱 =;
    // 沒有 = 值
    // 整數，浮點數，預設值=0
    // 字串 預設值 ''
    // 布林值 false

    // 修飾詞
    // 私人 private - 僅此類別使用 | 不會顯示 - 預設值
    // 公開 public -所有類別使用 | 會顯示
    
    // 欄位屬性 [欄位名稱()]
    // 標題 Header
    // 提示 Tiletip
    // 範圍 Range
    */

    [Header("速度"),Tooltip("角色速度"),Range(10,1000)]
    public int speed = 50;
    [Header("血量"), Tooltip("角色血量"), Range(10, 1000)]
    public float hp = 500.0f;
    [Header("高度"), Tooltip("角色跳高"), Range(10, 1000)]
    public int height = 100;
    [Header("金幣數量"), Tooltip("角色吃了多少金幣")]
    public int coin;
    [Header("音效區域")]
    public AudioClip soundJump;
    public AudioClip soundSlide;
    public AudioClip soundBump;
    [Header("角色是否死亡"),Tooltip("True 代表死亡，False 表示尚未死亡")]
    public bool dead;

    #endregion

    #region 方法區域

    /// <summary>
    /// 跳躍功能:跳躍動畫，撥放音效與往上跳
    /// </summary>
    private void Jump()
    {
        print("跳躍");
    }

    /// <summary>
    /// 滑行功能:滑行動畫，撥放音效，縮小碰撞範圍
    /// </summary>
    private void Slide()
    {
        print("滑行");
    }

    /// <summary>
    /// 碰到障礙物受傷:扣血
    /// </summary>
    private void Hit()
    {

    }

    /// <summary>
    /// 吃金幣:金幣數量增加，更新介面，金幣音效
    /// </summary>
    private void EatCoin()
    {

    }

    /// <summary>
    /// 死亡:動畫，遊戲結束
    /// </summary>
    private void Dead()
    {

    }

    #endregion

    #region 事件區域

    //開始Start
    //初始化
    private void Start()
    {
        Jump();
    }

    //更新Update
    //60FPS
    //更新，監聽鍵盤，滑鼠
    private void Update()
    {
        Slide();
    }
    #endregion
}
