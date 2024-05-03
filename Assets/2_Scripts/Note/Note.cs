using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private SpriteRenderer srdr;
    [SerializeField] private Sprite appleSprite;
    [SerializeField] private Sprite blueberrySprite;

    public void Activate(bool _isApple)
    {
        this.srdr.sprite = _isApple == true ? this.appleSprite : this.blueberrySprite;
         
    }
    public void Deactivate()
    {
        GameObject.Destroy(this.gameObject);
    }
}
