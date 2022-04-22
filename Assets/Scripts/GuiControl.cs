using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GuiControl : MonoBehaviour
{
    private Button StartButton;

    void Start()
    {
        var root= GetComponent<UIDocument>().rootVisualElement;

        root.Q<Button>("Button_Start").clicked+=OnClickedStart;
    }

    private void OnClickedStart()
    {
        print("StartGame");
    }
    

}
