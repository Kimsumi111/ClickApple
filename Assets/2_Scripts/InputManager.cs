using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    private List<KeyCode> keyCodeList;

    void Awake()
    {
        Instance = this;
        
        this.keyCodeList = new List<KeyCode>();
    }

    public void AddKeycode(KeyCode _keycode)
    {// �������� ������ ���� �Լ�
        this.keyCodeList.Add(_keycode);
    }
    
    void Update()
    {
        foreach (KeyCode _keyCode in this.keyCodeList) {
            if(Input.GetKeyDown(_keyCode) == true)
            {
                NoteManager.Instance.OnInput(_keyCode);
            }
        }
    }
}
