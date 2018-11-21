using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPart : MonoBehaviour
{
    public delegate void ButtonEvent(Griffin.State state);
    public ButtonEvent buttonEvent;

    public Griffin.State state;

    public void Awake()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnClick);
    }
    public void OnClick()
    {
        if(buttonEvent != null)
        {
            buttonEvent(state);
        }
    }
}
