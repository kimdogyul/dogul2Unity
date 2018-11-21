using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    public enum BUILDING_STATE
    {
        NORMAL = 0,
        BOOST_NORMAL = 1,
        BOOST_HARD = 2,
        STOP = 3,
    };
    public Text goldCount;
    public Text message;
    private const int maxKeepGoldAmount = 5000;     // 해당 값만큼까지만 골드를 보관할 수 있다.
    private int keepGoldAmount = 0;   // 보관중인 생산된 골드
    private float timer = 0;

    public BUILDING_STATE state = BUILDING_STATE.NORMAL;

    public void Awake()
    {
        goldCount.text = "0";
    }
    public void Update()
    {
        if (state == BUILDING_STATE.STOP) return;
        timer += Time.deltaTime;
        CheckTimer();
    }

    public void CheckTimer()
    {
        int gold = 0;
        float checkTime = 0.0f;
        switch (state)
        {
            case BUILDING_STATE.NORMAL:
                {
                    gold = 3;
                    checkTime = 10.0f;
                }
                break;
            case BUILDING_STATE.BOOST_HARD:
                {
                    gold = 10;
                    checkTime = 3.0f;
                }
                break;
            case BUILDING_STATE.BOOST_NORMAL:
                {
                    gold = 5;
                    checkTime = 5.0f;
                }
                break;
        }

        if (timer >= checkTime)
            AddGold(gold);
        message.text = string.Format("시간:[{0}] \n리미트시간:[{1}]  \n획득골드:[{2}]", (int)timer, checkTime, gold);

    }

    public void AddGold(int gold)
    {
        timer = 0;
        keepGoldAmount += gold;
        if (keepGoldAmount >= maxKeepGoldAmount)
        {
            keepGoldAmount = maxKeepGoldAmount;
        }
        goldCount.text = keepGoldAmount.ToString();

    }

    public void OnToggleClickNormal(bool value)
    {
        if (value == true)
        {
            state = BUILDING_STATE.NORMAL;
        }
    }
    public void OnToggleClickBoostNormal(bool value)
    {
        if (value == true)
        {
            state = BUILDING_STATE.BOOST_NORMAL;
        }
    }
    public void OnToggleClickBoostHard(bool value)
    {
        if (value == true)
        {
            state = BUILDING_STATE.BOOST_HARD;
        }
    }
    public void OnToggleClickStop(bool value)
    {
        if (value == true)
        {
            state = BUILDING_STATE.STOP;
        }
    }

}

