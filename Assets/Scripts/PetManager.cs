using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetManager : MonoBehaviour
{

    [SerializeField] private static int goodBehaviourPoint = 1;
    [SerializeField] private static int badBehaviourPoint = -1;
    public static CatManager cat;
    private static float timerHold;
    private static float timerMono;
    private float holdingTime;

    private List<CatManager> cats = new List<CatManager>();

    public enum EPlayerPetting
    {
    isNotPetting,
    isHoldPetting,
    isMonoPetting
    }
    private static EPlayerPetting petRecieved;

    // Start is called before the first frame update
    void Start()
    {
        InitializeCats();
        cat = cats[0];
        timerMono = cat.monoPetFrequency;
        timerHold = 0;
        holdingTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timerMono -= Time.deltaTime;
        if(Player.isPetting){
            timerHold += Time.deltaTime;
            petRecieved = PlayerPettingState();
            if(petRecieved == EPlayerPetting.isHoldPetting){
                holdingTime += Time.deltaTime;
                if(holdingTime >= 1.0){
                    Debug.Log("entering one hold");
                    holdingTime = 0;
                    CatFeeling();
                } 
            }
        }
        else{
            timerHold = 0;
        }
        CheckCatMood();
        
    }

    public static bool GoodPetting(){
        if(petRecieved == EPlayerPetting.isMonoPetting){
            if(cat.petPreference == EPetPreference.MonoPet){
                if(timerMono<=0){
                    timerMono = cat.monoPetFrequency; 
                    return true;
                }
                else{
                    timerMono = cat.monoPetFrequency; 
                    return false;
                }
            }
            else{
                return false;
            }
        }
        else{
            if(cat.petPreference == EPetPreference.HoldPet){
                if(timerHold<= cat.holdPetFrequency){ 
                    return true;
                }
                else{
                    return false;
                }
            }
            else{
                return false;
            }
        }
    }

    public static void CatFeeling(){
        if(GoodPetting()){
            cat.catScore += goodBehaviourPoint;
        }
        else{
            cat.catScore += badBehaviourPoint;
        }
        cat.CheckCatState();
        Debug.Log(cat.catScore);
        Debug.Log(cat.catFeeling);
    }

    public static EPlayerPetting PlayerPettingState(){
    if(!Player.isMono && Player.isPetting){
        return EPlayerPetting.isHoldPetting;
    }
    else if(Player.isMono && Player.isPetting){
        return EPlayerPetting.isMonoPetting;
    }
    else{
        return EPlayerPetting.isNotPetting;
    }
    }

    private void InitializeCats(){
        cats.Add(new CatManager() {monoPetFrequency = 0.5f, petPreference = EPetPreference.MonoPet, catIndex = 1});
        cats.Add(new CatManager() {holdPetFrequency = 5f, petPreference = EPetPreference.HoldPet, catIndex = 2});
    }


    private void CheckCatMood(){
        if(cat.catScore == 20){
            Debug.Log("changing cat");
            changeCat();
        }
        if(cat.catScore == 0){
            TriggerGameOver();
        }
    }

    private void changeCat(){
        if(cat.catIndex == cats.Count){
            TriggerWin();
        }
        else{
            cat = cats[cat.catIndex];
        }
    }

    private void TriggerGameOver(){

    }

    private void TriggerWin(){

    }




}
