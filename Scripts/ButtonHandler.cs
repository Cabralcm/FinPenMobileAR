using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonHandler : MonoBehaviour {

    public Button m_InfoButton;

    private int buttonState;

    public GameObject info;

    private void Start()
    {
        //m_InfoButton.onClick.AddListener(TaskOnClick);
        info.SetActive(false);
        buttonState = 0;
    }

    void TaskOnClick()
    {
        Debug.Log("I clicked the button!");
    }

    public void OnClickStartBtn()
    {

        if(buttonState == 0)
        {
            info.SetActive(true);
            buttonState = 1;
        }
        else if (buttonState == 1)
        {
            info.SetActive(false);
            buttonState = 0;
        }



    }
}
