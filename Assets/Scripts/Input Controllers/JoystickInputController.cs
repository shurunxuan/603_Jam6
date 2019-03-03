using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickInputController : InputController {

    [SerializeField]
    private int joyNum;

	// Use this for initialization
	void Start () {
        if (!inputDataExternallySet) SetJoystickNum(joyNum);
    }

    private void Update() {

        Vector2 axisVector = new Vector2(Input.GetAxisRaw(inputData.horizontal), Input.GetButton(inputData.buttonA) ? 1 : 0);
        shipController.SetAxisVector(axisVector);

        bool fireButtonDown = Input.GetButton(inputData.buttonB);
        shipController.SetFire(fireButtonDown);

        if (Input.GetButtonDown(inputData.buttonA) || Input.GetButtonDown(inputData.buttonB)) {
            QuickDrawManager.instance.Notify(playerNum);
        }

    }

    public void SetJoystickNum(int _joyNum) {
        joyNum = _joyNum;
        inputData = InputData.CreateJoystick(_joyNum);
        inputDataExternallySet = true;
    }

}
