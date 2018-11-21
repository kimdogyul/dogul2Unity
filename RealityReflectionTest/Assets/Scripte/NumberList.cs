using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NumberList : MonoBehaviour {

    public List<int> p_list = new List<int>();
    public int p_target = 0;
    public InputField listInput;
    public InputField targetInput;

    public void Awake()
    {
        targetInput.text = p_target.ToString();
        Refresh();
    }
    public void Refresh()
    {
        string text = string.Empty;
        for (int i = 0; i < p_list.Count; i++)
        {
            if (i == 0)
            {
                text = string.Format("{0}", p_list[i]);
            }
            else
            {
                text = string.Format("{0},{1}", text, p_list[i]);
            }
        }
        listInput.text = text;
    }

    public void OnValueChangedListInput(string input)
    {
        string[] arrayText= input.Split(',');
        p_list.Clear();
        for ( int i = 0; i < arrayText.Length; i++)
        {
            p_list.Add(int.Parse(arrayText[i]));
        }
    }

    public void OnValueChangedTargetInput(string input)
    {
        p_target = int.Parse(input);
    }

    public void OnClick()
    {
        ListRemoval.ListRemoveItem(ref p_list, p_target);
        Refresh();
    }
}

public class ListRemoval
{
    public static void ListRemoveItem(ref List<int> p_list, int p_target)
    {
        p_list = p_list.FindAll(x => x != p_target);
    }
}
