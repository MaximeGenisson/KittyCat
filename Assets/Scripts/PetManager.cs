using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetManager : MonoBehaviour
{

    [SerializeField] private int goodBehaviourPoint = 1;
    [SerializeField] private int badBehaviourPoint = -1;
    private CatManager cat = new CatManager{petPreference = EPetPreference.MonoPet};

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static bool GoodPetting(){
        return true;
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


}
