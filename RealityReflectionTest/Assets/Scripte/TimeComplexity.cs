using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeComplexity : MonoBehaviour
{
    private int maxEnchant = 10;
    private long complexityCount = 0;
    public Text textComplexityCount;
    public InputField textMaxEnchantCount;
    public Toggle toggleIsDynamic;


    public void Awake()
    {
        textMaxEnchantCount.text = maxEnchant.ToString();
    }
    public void OnClick()
    {
        maxEnchant = int.Parse(textMaxEnchantCount.text);

        complexityCount = 0;

        if (toggleIsDynamic.isOn == false)
        {
            if (int.Parse(textMaxEnchantCount.text) <= 30)
            {
                Complexity(0);
            }
            else
            {
                textComplexityCount.text = "30 이상의 값은 Unity를 멈추게 할수도있습니다.";
                return;
            }
        }
        else
        {
            DynamicComplexity(maxEnchant);
        }
        textComplexityCount.text = complexityCount.ToString();
    }

    public void Complexity(int enchantCount)//O(n^3)
    {
        for (int i = 1; i <= 3; i++)
        {
            // 정지 조건
            if (enchantCount + i > maxEnchant) return;

            if (enchantCount + i == maxEnchant)
            {
                complexityCount++;
                return;
            }

            Complexity(enchantCount + i);
        }
    }

    public void DynamicComplexity(int enchantCount)//O(n)
    {
        long[] dp_array = new long[enchantCount];

        dp_array[0] = 1;
        dp_array[1] = 2;
        dp_array[2] = 4;
        for(int i =3; i< enchantCount;i++)
        {
            dp_array[i] = dp_array[i - 1] + dp_array[i - 2] + dp_array[i - 3];
        }

        complexityCount = dp_array[enchantCount - 1];

    }


}
