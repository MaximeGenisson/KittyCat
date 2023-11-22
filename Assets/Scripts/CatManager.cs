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
    public float petFrequency = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckCatState(){
        if (catScore<=0){
            catFeeling = ECatStateType.TooMuchAngry;
        }
        else if (catScore<=5){
            catFeeling = ECatStateType.VeryAngry;
        }
        else if (catScore<=9){
            catFeeling = ECatStateType.Angry;
        }
        else if (catScore==10){
            catFeeling = ECatStateType.Neutral;
        }
        else if (catScore>=11){
            catFeeling = ECatStateType.Happy;
        }
        else if (catScore>=15){
            catFeeling = ECatStateType.RonronStart;
        }
        else if (catScore>=20){
            catFeeling = ECatStateType.RonronSucess;
        }
    }

}
