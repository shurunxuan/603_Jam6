using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {
    
    public int playerNum {
        get;
        protected set;
    }
    
    public Color playerColor {
        get;
        protected set;
    }

    public ShipController shipController {
        get;
        protected set;
    }

    protected InputData inputData;
    protected bool inputDataExternallySet = false;

    protected virtual void Awake() {
        shipController = GetComponentInChildren<ShipController>();
    }

    protected virtual void Start() {
        GameManager.instance.AddPlayer(this);
    }

    protected virtual void Update() {
        
        Vector2 axisVector = new Vector2(Input.GetAxisRaw(inputData.horizontal), Input.GetAxisRaw(inputData.vertical));
        shipController.SetAxisVector(axisVector);

        bool aDown = Input.GetButton(inputData.buttonA);
        shipController.SetA(aDown);

        bool bDown = Input.GetButton(inputData.buttonB);
        shipController.SetB(bDown);

        if (Input.GetButtonDown(inputData.buttonA) || Input.GetButtonDown(inputData.buttonB)) {
            QuickDrawManager.instance.Notify(this);
        }

    }

    public void SetShip(GameObject _shipPrefab) {

        GameObject weaponPrefab = shipController.Weapon;
        Vector3 pos = shipController.transform.localPosition;
        Quaternion rot = shipController.transform.localRotation;

        Destroy(shipController.gameObject);

        GameObject shipObj = Instantiate(_shipPrefab, this.transform);
        shipController = shipObj.GetComponent<ShipController>();

        shipObj.transform.localPosition = pos;
        shipObj.transform.localRotation = rot;
        shipController.Weapon = weaponPrefab;

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
