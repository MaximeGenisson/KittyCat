using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHead : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;

    void ChangeSprite()
    {
        if(PetManager.cat.catFeeling == ECatStateType.VeryAngry)
        {
            spriteRenderer.sprite = spriteArray[0];
        }
        else if (PetManager.cat.catFeeling == ECatStateType.Angry)
        {
            spriteRenderer.sprite = spriteArray[1];
        }

        else if (PetManager.cat.catFeeling == ECatStateType.Neutral)
        {
            spriteRenderer.sprite = spriteArray[2];
        }

        else if (PetManager.cat.catFeeling == ECatStateType.Happy)
        {
            spriteRenderer.sprite = spriteArray[3];
        }

        else if (PetManager.cat.catFeeling == ECatStateType.RonronStart)
        {
            spriteRenderer.sprite = spriteArray[4];
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
