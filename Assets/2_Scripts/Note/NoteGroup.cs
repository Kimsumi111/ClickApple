using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NoteGroup : MonoBehaviour
{
    [SerializeField] private int noteMaxNum = 5;
    [SerializeField] private Note baseNoteClass = null; //원본
    [SerializeField] private float noteGapInterval = 8f;
    [SerializeField] private Transform noteSpawnTrf = null;
    [SerializeField] private SpriteRenderer btnSrdr = null;
    [SerializeField] private Sprite nomalBtnSprite = null;
    [SerializeField] private Sprite selectedBtnSprite = null;
    [SerializeField] private Animation anim = null;
    [SerializeField] private TextMeshPro keycodeTmp = null;
    private KeyCode keyCode;           // 동적으로 할당됨. 시리어화 필요없음
    private List<Note> noteClassList;

    public KeyCode GetKeyCode => this.keyCode;

    private void Awake()
    {
        this.noteClassList = new List<Note>();

    }

    public void Activate(KeyCode _keyCode)
    {
        this.keyCode = _keyCode;

        this.keycodeTmp.text = _keyCode.ToString();

        for (int i = 0; i < noteMaxNum; i++)
        {
            this.OnSpawnNote(true); // 처음에는 무조건 사과로 시작
        }

        InputManager.Instance.AddKeycode(_keyCode);
    }
    public void OnSpawnNote(bool _isApple) {
        GameObject _noteClassObj = GameObject.Instantiate(this.baseNoteClass.gameObject);

        _noteClassObj.transform.SetParent(this.noteSpawnTrf);
        _noteClassObj.transform.localPosition = Vector3.up * this.noteClassList.Count * this.noteGapInterval;

        Note _noteClass = _noteClassObj.GetComponent<Note>();
        _noteClass.Activate(_isApple);

        this.noteClassList.Add(_noteClass);
    }

    // 노트매니저에게 클릭 이벤트 받음
    public void OnInput(bool _isSelected)
    {
        // 가장 아래의 과일 제거
        Note _noteClass = this.noteClassList[0];
        _noteClass.OnInput(_isSelected);

        this.noteClassList.RemoveAt(0);

        // 생성될 위치
        for (int i = 0; i < this.noteClassList.Count; i++)
        {
            this.noteClassList[i].transform.localPosition = Vector3.up * i * this.noteGapInterval;
        }

        // 애니메이션 실행
        if (_isSelected == true)
        {
            this.btnSrdr.sprite = this.selectedBtnSprite;

            this.anim.Play();
        }
    }

    // 원래대로 되돌림
    public void CallAni_Done()
    {
        this.btnSrdr.sprite = this.nomalBtnSprite;
    }
}
