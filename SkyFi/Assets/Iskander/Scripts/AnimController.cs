using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    private Animator playerAnimator;
    private string[] animationsArray = {"isWalkF", "isWalkB", "isWalkL", "isWalkR", 
    "isWalkFL", "isWalkFR", "isWalkBL", "isWalkBR", "isAim", "isAimF", "isAimL", "isAimR", "isAimB", 
    "isRunF", "isRunB", "isRunFL", "isRunFR"};


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

        //Movement Keys
        bool forwardPress = Input.GetKey(KeyCode.W);
        bool backwardPress = Input.GetKey(KeyCode.S);
        bool leftPress = Input.GetKey(KeyCode.A);
        bool rightPress = Input.GetKey(KeyCode.D);
        bool forwardLeftPress = (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A));
        bool forwardRightPress = (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D));
        bool backwardLeftPress = (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A));
        bool backwardRightPress = (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D));

        //Aim Keys
        bool rmbPress = Input.GetKey(KeyCode.Mouse1);
        bool rmbForwardPress = (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Mouse1));
        bool rmbLeftPress = (Input.GetKey(KeyCode.Mouse1) && Input.GetKey(KeyCode.A));
        bool rmbRightPress = (Input.GetKey(KeyCode.Mouse1) && Input.GetKey(KeyCode.D));
        bool rmbBackPress = (Input.GetKey(KeyCode.Mouse1) && Input.GetKey(KeyCode.S));

        //Run Keys
        bool runForwardPress = (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift));
        bool runBackwardPress = (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift));
        bool runForwardLeftPress = (forwardLeftPress && Input.GetKey(KeyCode.LeftShift));
        bool runForwardRightPress = (forwardRightPress && Input.GetKey(KeyCode.LeftShift));

            //Movement Animations
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

        
            //Aim Animations
            if(rmbPress){setAnimation(8);}
            if(!rmbPress){resetAnimation(8);}

            if(rmbForwardPress){setAnimation(9); resetAnimation(0);}
            if(!rmbForwardPress){resetAnimation(9);}

            if(rmbLeftPress){setAnimation(10); resetAnimation(2);}
            if(!rmbLeftPress){resetAnimation(10);}

            if(rmbRightPress){setAnimation(11); resetAnimation(3);}
            if(!rmbRightPress){resetAnimation(11);}

            if(rmbBackPress){setAnimation(12); resetAnimation(1);}
            if(!rmbBackPress){resetAnimation(12);}

            //Running Animations
            if(runForwardPress){setAnimation(13); resetAnimation(0);}
            if(!runForwardPress){resetAnimation(13);}

            if(runBackwardPress){setAnimation(14); resetAnimation(1);}
            if(!runBackwardPress){resetAnimation(14);}

            if(runForwardLeftPress){setAnimation(15); resetAnimation(13); resetAnimation(4);}
            if(!runForwardLeftPress){resetAnimation(15);}

            if(runForwardRightPress){setAnimation(16); resetAnimation(13); resetAnimation(5);}
            if(!runForwardRightPress){resetAnimation(16);}
        

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
