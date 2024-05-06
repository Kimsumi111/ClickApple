using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public static NoteManager Instance;

    [SerializeField] private KeyCode[] initKeyCodeArr;
    [SerializeField] private NoteGroup baseNoteGroupClass = null;
    [SerializeField] private float noteGroupWidthInterval = 1f;
    // 동적으로 늘어날 수 있겠끔 리스트 사용
    private List<NoteGroup> noteGroupClassList;

    void Awake()
    {
        Instance = this;

        this.noteGroupClassList = new List<NoteGroup>();
    }
    public void Activate()
    {// 생성 함수 호출 함수
        // 키 코드 인자로 전달
        foreach (KeyCode _initKeyCode in this.initKeyCodeArr)
        {
            this.OnSpawnNoteGroup(_initKeyCode);
        }
    }

    public void OnSpawnNoteGroup(KeyCode _keyCode)
    {// 노트 그룹 생성 함수
        GameObject _noteGroupClassObj = GameObject.Instantiate(this.baseNoteGroupClass.gameObject);

        _noteGroupClassObj.transform.position = Vector3.right * this.noteGroupWidthInterval * this.noteGroupClassList.Count;

        NoteGroup _noteGroupClass = _noteGroupClassObj.GetComponent<NoteGroup>();
        // 노트 그룹은 키코드 모름
        _noteGroupClass.Activate(_keyCode);

        this.noteGroupClassList.Add(_noteGroupClass);  // 캐싱
    }


    public void OnInput(KeyCode _keycode){
        // 랜덤하게 하나를 지정해서 받아옴
        int _randID = Random.Range(0, this.noteGroupClassList.Count);
        NoteGroup _randNoteGroupClass = this.noteGroupClassList[_randID];

        // 내가 입력한 키의 줄만 맨 위에 과일 추가 생성
        foreach (NoteGroup _noteGroupClass in this.noteGroupClassList)
        {
            _noteGroupClass.OnSpawnNote(_noteGroupClass == _randNoteGroupClass);
            bool _isSelected = _noteGroupClass.GetKeyCode == _keycode;
            _noteGroupClass.OnInput(_isSelected);
        }
    }
}