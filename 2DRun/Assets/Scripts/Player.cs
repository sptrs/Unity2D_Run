﻿using UnityEngine;

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

    [Header("速度"), Tooltip("角色速度"), Range(1, 300)]
    public int speed = 50;
    [Header("血量"), Tooltip("角色血量"), Range(10, 1000)]
    public float hp = 500.0f;
    [Header("高度"), Tooltip("角色跳高"), Range(10, 900)]
    public int height = 100;
    [Header("金幣數量"), Tooltip("角色吃了多少金幣")]
    public int coin;
    [Header("音效區域")]
    public AudioClip soundJump;
    public AudioClip soundSlide;
    public AudioClip soundBump;
    [Header("角色是否死亡"), Tooltip("True 代表死亡，False 表示尚未死亡")]
    public bool dead;
    [Header("腳色動畫")]
    public Animator ani;
    [Header("膠囊碰撞器")]
    public CapsuleCollider2D cc2d;
    [Header("剛體")]
    public Rigidbody2D rig;

    public bool isGround;

    #endregion

    #region 方法區域
    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        // 如果(剛體.加速度.大小 < 10)
        if (rig.velocity.magnitude < 10)
        {
            // 剛體.添加推力(二維向量)
            rig.AddForce(new Vector2(speed, 0));
        }
    }

    /// <summary>
    /// 跳躍功能:跳躍動畫，撥放音效與往上跳
    /// </summary>
    private void Jump()
    {
        bool jump = Input.GetKey(KeyCode.Space);

        ani.SetBool("跳躍觸發", !isGround);

        // 搬家 Alt + 上，下
        // 格式化 Ctrl + K D

        // 如果在地板上
        if (isGround)
        {
            if (jump)
            {
                isGround = false; //不再地板上
                rig.AddForce(new Vector2(0, height)); // 剛體.添加推力(二維向量)
            }

        }
    }

    /// <summary>
    /// 滑行功能:滑行動畫，撥放音效，縮小碰撞範圍    
    /// </summary>
    private void Slide()
    {
        //布林值 = 輸入.取得按鍵(按鍵代碼列舉.按鍵)
        bool key = Input.GetKey(KeyCode.LeftControl);

        //動畫控制器代號
        ani.SetBool("滑行觸發", key);

        if (key) // 如果 玩家 按下 按鍵就縮小
        {
            cc2d.offset = new Vector2(0.5f, -0.8f); // 位移
            cc2d.size = new Vector2(1.3f, 1.7f); //尺寸
        }
        // 否則 恢復
        else
        {
            cc2d.offset = new Vector2(-1.0f, 0.06f); // 位移
            cc2d.size = new Vector2(2.8f, 4.0f); //尺寸
        }
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

    }

    //更新Update
    //60FPS
    //更新，監聽鍵盤，滑鼠
    private void Update()
    {
        Slide();
    }


    /// <summary>
    /// 固定更新事件 : 一秒固定執行50次，只要有剛體就寫在這裡
    /// </summary>
    private void FixedUpdate()
    {       
        Jump();
        Move();
    }

    /// <summary>
    /// 碰撞事件 : 碰到物件開始執行一次
    /// </summary>
    /// <param name="collision">碰到物件的碰撞資訊</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 如果 碰到物件 的 名稱 等於 "地板"
        if (collision.gameObject.name == "地板")
        {
            //是否在地板上 = 是
            isGround = true;
        }
    }
    #endregion

}
