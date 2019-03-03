using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickInputController : InputController {

    [SerializeField]
    private int joyNum;

	// Use this for initialization
	protected override void Start () {
        base.Start();
        if (!inputDataExternallySet) SetJoystickNum(joyNum);
    }

    public void SetJoystickNum(int _joyNum) {
        joyNum = _joyNum;
        inputData = InputData.CreateJoystick(_joyNum);
        inputDataExternallySet = true;
        shipController.SetInputType(inputData.type);
    }

}
