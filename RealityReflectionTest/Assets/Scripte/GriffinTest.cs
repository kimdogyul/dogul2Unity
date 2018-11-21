using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GriffinTest : MonoBehaviour
{

    private Griffin griffin = new Griffin();
    private bool isAdd = true;

    public GameObject togglePart;
    public GridLayoutGroup gridLayoutGroup;
    public Text bordText;

    private void Awake()
    {
        for (Griffin.State i = Griffin.State.Fly; i <= Griffin.State.Hold; i++)
        {
            GameObject obj = Instantiate(togglePart, gridLayoutGroup.transform);
            obj.SetActive(true);
            obj.name = i.ToString();
            Text uiText = obj.GetComponentInChildren<Text>();
            if (uiText != null)
            {
                uiText.text = i.ToString();
            }
            ButtonPart part = obj.GetComponent<ButtonPart>();
            if (part != null)
            {
                part.state = i;
                part.buttonEvent = OnClick;
            }
        }
        Refresh();
    }

    public void Refresh()
    {
        bordText.text = griffin.GetString();
    }

    public void OnClick(Griffin.State state)
    {
        if (isAdd == true)
        {
            griffin.AddState(state);
        }
        else
        {
            griffin.RemoveState(state);
        }
        Refresh();
    }

    public void OnToggleAdd(bool isOn)
    {
        if (isOn == true)
        {
            isAdd = true;
        }
    }
    public void OnToggleRemove(bool isOn)
    {
        if (isOn == true)
        {
            isAdd = false;
        }
    }
}

public class Griffin
{
    public enum State
    {
        Fly,      //  OnGround 와 공존할 수 없습니다.
        OnGround, //  Fly 와 공존할 수 없습니다.
        Poison,
        Bleeding,
        Marked,
        SpeedUp,
        Regeneration,
        BlockingArrow,
        Casting,
        Attacking,
        Defencing,
        Dead,
        Stun,
        Slow,
        Anger,
        Hold
    }
    State m_state = State.Fly;
    List<State> listState = new List<State>();
    public Griffin()
    {
        listState.Add(m_state);
    }
    /// <summary>
    /// 인자 상태 추가
    /// </summary>
    /// <param name="state"></param>
    public void AddState(State state)
    {
        if (state <= State.OnGround && m_state != state)
        {
            listState.Remove(m_state);
            listState.Add(state);
            m_state = state;
        }
        else if (HasState(state) == false)
        {
            listState.Add(state);
        }
        GetString();
    }
    /// <summary>
    /// 인자 상태 제거
    /// </summary>
    /// <param name="state"></param>

    public void RemoveState(State state)
    {
        if (state == State.Fly || state == State.OnGround)
        {
            //삭제할수 없습니다.
            return;
        }
        if (HasState(state) == true)
        {
            listState.Remove(state);
            GetString();
        }
    }
    /// <summary>
    /// 인자의 상태를 가지고 있는지
    /// </summary>
    /// <param name="state"></param>
    /// <returns></returns>
    public bool HasState(State state)
    {
        return listState.Contains(state);
    }

    public string GetString()
    {
        string text = string.Empty;
        for (int i = 0; i < listState.Count; i++)
        {
            if (i == 0)
            {
                text = string.Format("{0}", listState[i]);

            }
            else
            {
                text = string.Format("{0},{1}", text, listState[i]);
            }
        }
        return text;
    }
}