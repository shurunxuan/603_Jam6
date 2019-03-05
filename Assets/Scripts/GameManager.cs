using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance {
        get;
        private set;
    }

    public GameObject defaultShipPrefab;
    public GameObject defaultWeaponPrefab;

    public Dictionary<int, InputController> players = new Dictionary<int, InputController>();

    public void AddPlayer(InputController _inputController) {
        _inputController.playerNum = players.Count;
        players.Add(_inputController.playerNum, _inputController);
        Debug.Log("Player " + _inputController.playerNum + " joined");
    }

    public InputController GetPlayer(int _playerNum) {
        InputController player;
        if (players.TryGetValue(_playerNum, out player)) {
            return player;
        }
        return null;
    }

    public List<InputController> GetAllPlayers() {
        return players.Values.ToList();
    }

    private void Awake() {
        instance = this;
    }

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
            if(Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("CreditScreen");
            }
            yield return null;
        }
    }

    // Transition to end of game state for anything
    private IEnumerator EndGame() {
        Debug.Log("Ending Game");
        yield return new WaitForSeconds(2); // Dummy wait to simulate stuff being done
    }

}
