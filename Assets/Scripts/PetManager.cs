using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetManager : MonoBehaviour
{

    [SerializeField] private int goodBehaviourPoint = 1;
    [SerializeField] private int badBehaviourPoint = -1;
    private CatManager cat = new CatManager{petPreference = EPetPreference.MonoPet};
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cat.petPreference = EPetPreference.MonoPet){
            timer -= Time.DeltaTime;
        }
        if (cat.petPreference = EPetPreference.HoldPet){
            
        }
    }

    public static bool GoodPetting(){
        if(cat.petPreference = EPetPreference.MonoPet){
            if(timer<=0){
                timer = cat.petFrequency; 
                return true;
            }
            else{
                timer = cat.petFrequency; 
                return false;
            }
        }
        if(cat.petPreference = EPetPreference.HoldPet){
            if(timer<=0){ 
                return false;
            }
            else{
                return true;
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
    }

    void InitialiseCat(){
        timer = cat.petFrequency;
    }


}
