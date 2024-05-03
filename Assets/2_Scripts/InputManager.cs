using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) == true){
            NoteManager.Instance.OnInput(KeyCode.A);
        }
        if (Input.GetKeyDown(KeyCode.S) == true){
            NoteManager.Instance.OnInput(KeyCode.S);
        }
        if (Input.GetKeyDown(KeyCode.D) == true){
            NoteManager.Instance.OnInput(KeyCode.D);
        }
    }
}
