using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetManager : MonoBehaviour
{

    [SerializeField] private int goodBehaviourPoint = 1;
    [SerializeField] private int badBehaviourPoint = -1;
    private CatManager cat = new CatManager{petPreference = EPetPreference.MonoPet};
    private float timerHold;
    private float timerMono;
    private float holdingTime;

    public enum EPlayerPetting
    {
    isNotPetting,
    isHoldPetting,
    isMonoPetting
    }
    private EPlayerPetting petRecieved = EPlayerPetting.isNotPetting;

    // Start is called before the first frame update
    void Start()
    {
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
            if(petRecieved == EPlayerPetting.isMonoPetting){
                Debug.Log("entering mono");
                Player.isPetting = false;
                CatFeeling();
            }
             else if(petRecieved == EPlayerPetting.isHoldPetting){
                holdingTime += Time.deltaTime;
                 Debug.Log("entering hold");
                if(holdingTime >= 2.0){
                    holdingTime = 0;
                    CatFeeling();
                } 
            }
        }
        else{
            timerHold = 0;
        }
        
    }

    public bool GoodPetting(){
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
            if(timerHold<= cat.holdPetFrequency){ 
                return true;
            }
            else{
                return false;
            }
        }
    }

    void CatFeeling(){
        if(GoodPetting()){
            cat.catScore += goodBehaviourPoint;
        }
        else{
            cat.catScore += badBehaviourPoint;
        }
        cat.CheckCatState();
        Debug.Log(cat.catScore);
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


}
