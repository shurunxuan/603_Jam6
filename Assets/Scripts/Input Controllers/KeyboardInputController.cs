using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputController : InputController {
    
    [SerializeField]
    private InputData.KeyboardInputType keyboardInputType;

	// Use this for initialization
	protected override void Start () {
        base.Start();
        if (!inputDataExternallySet) SetKeyboardType(keyboardInputType);
	}

    public void SetKeyboardType(InputData.KeyboardInputType _keyboardInputType) {
        keyboardInputType = _keyboardInputType;
        inputData = InputData.CreateKeyboard(_keyboardInputType);
        inputDataExternallySet = true;
        shipController.SetInputType(inputData.type);
    }

}
