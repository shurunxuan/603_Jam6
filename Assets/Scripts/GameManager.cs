using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(GameLoop());
	}

    private IEnumerator GameLoop() {
        yield return StartCoroutine(InitializeGame());
        yield return StartCoroutine(StartGame());
        yield return StartCoroutine(PlayGame());
        yield return StartCoroutine(EndGame());
    }

    // Create everything in here (players, controllers, game systems, etc.)
    private IEnumerator InitializeGame() {
        Debug.Log("Initializing Game");
        yield return new WaitForSeconds(2); // Dummy wait to simulate stuff being done
    }

    // Start everything up in here (enable player controllers, start up timers, etc.)
    private IEnumerator StartGame() {
        Debug.Log("Starting Game");
        yield return new WaitForSeconds(2); // Dummy wait to simulate stuff being done
    }

    // Control anything that game manager needs to do while the game is playing
    private IEnumerator PlayGame() {
        Debug.Log("Playing Game");
        while (true) {
            yield return null;
        }
    }

    // Transition to end of game state for anything
    private IEnumerator EndGame() {
        Debug.Log("Ending Game");
        yield return new WaitForSeconds(2); // Dummy wait to simulate stuff being done
    }

}
