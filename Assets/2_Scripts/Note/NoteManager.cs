using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public static NoteManager Instance;
    [SerializeField] private NoteGroup[] noteGroupClassArr;

    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    public void OnInput(KeyCode _keycode){
        // 랜덤하게 하나를 지정해서 받아옴
        int _randID = Random.Range(0, this.noteGroupClassArr.Length);
        NoteGroup _randNoteGroupClass = this.noteGroupClassArr[_randID];

        // 내가 입력한 키의 줄만 맨 위에 과일 추가 생성
        foreach (NoteGroup _noteGroupClass in this.noteGroupClassArr)
        {
            _noteGroupClass.OnSpawnNote(_noteGroupClass == _randNoteGroupClass);
            bool _isSelected = _noteGroupClass.GetKeyCode == _keycode;
            _noteGroupClass.OnInput(_isSelected);
        }
    }
}