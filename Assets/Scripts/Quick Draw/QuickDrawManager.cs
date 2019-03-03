using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickDrawManager : MonoBehaviour {

    public static QuickDrawManager instance {
        get;
        private set;
    }

    [SerializeField]
    private float timeBetweenQuickDraws;

    private float startTime;
    private bool endQuickDraw;

    private void Awake() {
        instance = this;
    }
    
    void Start () {
        startTime = Realtime.time;
        StartCoroutine(CycleQuickDraws());
	}
	
	private IEnumerator CycleQuickDraws() {

        while (true) {

            if (timeBetweenQuickDraws < 0) {
                yield return null;
                continue;
            }

            while (Realtime.time - startTime < timeBetweenQuickDraws) {
                yield return null;
            }

            yield return QuickDraw();

            startTime = Realtime.time;

        }
        
    }

    private IEnumerator QuickDraw() {

        Time.timeScale = 0;
        endQuickDraw = false;
        while (!endQuickDraw) {
            yield return null;
        }

        Time.timeScale = 1f;

    }

    public void Notify(int _playerNum) {
        endQuickDraw = true;
    }

}
