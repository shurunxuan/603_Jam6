using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputController : InputController {
    
    [SerializeField]
    private InputData.KeyboardInputType keyboardInputType;

	// Use this for initialization
	void Start () {
        if (!inputDataExternallySet) SetKeyboardType(keyboardInputType);
	}

    private void Update() {

        Vector2 axisVector = new Vector2(Input.GetAxisRaw(inputData.horizontal), Input.GetAxisRaw(inputData.vertical));
        shipController.SetAxisVector(axisVector);

        bool fireButtonDown = Input.GetButton(inputData.buttonB);
        shipController.SetFire(fireButtonDown);

    }

    public void SetKeyboardType(InputData.KeyboardInputType _keyboardInputType) {
        keyboardInputType = _keyboardInputType;
        inputData = InputData.CreateKeyboard(_keyboardInputType);
        inputDataExternallySet = true;
    }

}
