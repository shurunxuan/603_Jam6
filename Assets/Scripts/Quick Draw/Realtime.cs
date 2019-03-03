using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Realtime : MonoBehaviour {

    public static float time {
        get;
        private set;
    }

    public static float deltaTime {
        get;
        private set;
    }

    private void Update() {
        deltaTime = Time.realtimeSinceStartup - time;
        time = Time.realtimeSinceStartup;
    }

}
