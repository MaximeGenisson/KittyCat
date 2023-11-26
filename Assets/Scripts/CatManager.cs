using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ECatStateType
{   
    TooMuchAngry,
    VeryAngry,
    Angry,
    Neutral,
    Happy,
    RonronStart,
    RonronSucess,
    NoCat
}

public enum EPetPreference
{
    HoldPet,
    MonoPet
}


public class CatManager : MonoBehaviour
{

    public ECatStateType catFeeling = ECatStateType.Neutral;
    [SerializeField] public int catScore = 10;
    public EPetPreference petPreference;
    public float monoPetFrequency = 0.5f;
    public float holdPetFrequency = 10f;

    public int catIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckCatState();
    }

    public void CheckCatState(){
        if (catScore<=0){
            catFeeling = ECatStateType.TooMuchAngry;
        }
        else if (catScore<=5 && catScore > 0){
            catFeeling = ECatStateType.VeryAngry;
        }
        else if (catScore<=9 && catScore >5){
            catFeeling = ECatStateType.Angry;
        }
        else if (catScore==10){
            catFeeling = ECatStateType.Neutral;
        }
        else if (catScore>=11 && catScore <15){
            catFeeling = ECatStateType.Happy;
        }
        else if (catScore>=15 && catScore <20){
            catFeeling = ECatStateType.RonronStart;
        }
        else if (catScore>=20){
            catFeeling = ECatStateType.RonronSucess;
        }
    }

}
