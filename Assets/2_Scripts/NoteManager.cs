using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public static NoteManager Instance;

    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    public void OnInput(KeyCode _keycode){
        Debug.Log(_keycode+"키가 눌렸음");
    }
}