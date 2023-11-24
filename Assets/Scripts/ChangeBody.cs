using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBody : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;

    void ChangeSprite()
    {
        if (CatManager.catFeeling == ECatStateType.VeryAngry)
        {
            spriteRenderer.sprite = spriteArray[0];
        }
        else
        {
            spriteRenderer.sprite = spriteArray[1];
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSprite();
    }
}
