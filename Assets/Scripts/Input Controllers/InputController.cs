using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {
    
    [SerializeField]
    protected int playerNum;

    protected ShipController shipController;

    protected InputData inputData;
    protected bool inputDataExternallySet = false;

    protected virtual void Awake() {
        shipController = GetComponent<ShipController>();
    }

    public class InputData {

        public enum Type {
            Keyboard,
            Joystick
        }

        public enum KeyboardInputType {
            WASD,
            Arrows
        }

        public Type type;
        public string horizontal;
        public string vertical;
        public string buttonA;
        public string buttonB;

        public static InputData CreateJoystick(int _joystickNum) {
            InputData iData = new InputData();
            iData.type = Type.Joystick;
            iData.horizontal = "Horizontal_Joy" + _joystickNum;
            iData.vertical = "Vertical_Joy" + _joystickNum;
            iData.buttonA = "ButtonA_Joy" + _joystickNum;
            iData.buttonB = "ButtonB_Joy" + _joystickNum;
            return iData;
        }

        public static InputData CreateKeyboard(KeyboardInputType _inputType) {
            InputData iData = new InputData();
            iData.type = Type.Keyboard;
            string suffix = "";
            if (KeyboardInputType.WASD == _inputType) {
                suffix = "WASD";
            } else if (KeyboardInputType.Arrows == _inputType) {
                suffix = "Arrows";
            }
            iData.horizontal = "Horizontal_" + suffix;
            iData.vertical = "Vertical_" + suffix;
            iData.buttonA = "ButtonA_" + suffix;
            iData.buttonB = "ButtonB_" + suffix;
            return iData;
        }

    }

}
