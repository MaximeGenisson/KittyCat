using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTail : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;

    void ChangeSprite()
    {
        if (CatManager.catFeeling == ECatStateType.VeryAngry)
        {
            spriteRenderer.sprite = spriteArray[0];
        }
        else if (CatManager.catFeeling == ECatStateType.Angry)
        {
            spriteRenderer.sprite = spriteArray[1];
        }

        else if (CatManager.catFeeling == ECatStateType.Neutral)
        {
            spriteRenderer.sprite = spriteArray[1];
        }

        else if (CatManager.catFeeling == ECatStateType.Happy)
        {
            spriteRenderer.sprite = spriteArray[2];
        }

        else if (CatManager.catFeeling == ECatStateType.RonronStart)
        {
            spriteRenderer.sprite = spriteArray[2];
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
