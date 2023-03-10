using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    private Animator playerAnimator;
    private string[] animationsArray = {"isWalkF", "isWalkB", "isWalkL", "isWalkR", "isWalkFL", "isWalkFR", "isWalkBL", "isWalkBR"};

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animPlay();

    }

    void animPlay(){
        bool forwardPress = Input.GetKey(KeyCode.W);
        bool backwardPress = Input.GetKey(KeyCode.S);
        bool leftPress = Input.GetKey(KeyCode.A);
        bool rightPress = Input.GetKey(KeyCode.D);
        bool forwardLeftPress = (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A));
        bool forwardRightPress = (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D));
        bool backwardLeftPress = (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A));
        bool backwardRightPress = (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D));

        if(forwardPress){setAnimation(0);}
        if(!forwardPress){resetAnimation(0);}

        if(backwardPress){setAnimation(1);}
        if(!backwardPress){resetAnimation(1);}

        if(leftPress){setAnimation(2);}
        if(!leftPress){resetAnimation(2);}

        if(rightPress){setAnimation(3);}
        if(!rightPress){resetAnimation(3);}

        if(forwardLeftPress){setAnimation(4); resetAnimation(0); resetAnimation(2);}
        if(!forwardLeftPress){resetAnimation(4);}

        if(forwardRightPress){setAnimation(5); resetAnimation(0); resetAnimation(3);}
        if(!forwardRightPress){resetAnimation(5);}

        if(backwardLeftPress){setAnimation(6); resetAnimation(1); resetAnimation(2);}
        if(!backwardLeftPress){resetAnimation(6);}

        if(backwardRightPress){setAnimation(7); resetAnimation(1); resetAnimation(3);}
        if(!backwardRightPress){resetAnimation(7);}
    }

    void setAnimation(int num){
        for(int i = 0; i < animationsArray.Length; i++){
            if(i == num){playerAnimator.SetBool(animationsArray[i], true);}
        }
    }

    void resetAnimation(int num){
        for(int i = 0; i < animationsArray.Length; i++){
            if(i == num){playerAnimator.SetBool(animationsArray[i], false);}
        }
    }


}
