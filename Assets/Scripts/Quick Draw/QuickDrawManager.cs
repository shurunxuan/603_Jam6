using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickDrawManager : MonoBehaviour {

    public static QuickDrawManager instance {
        get;
        private set;
    }

    [SerializeField]
    private QuickDrawCanvas quickDrawCavas;

    [SerializeField]
    private float timeBetweenQuickDraws;

    [SerializeField]
    private GameObject[] rewardPrefabs;

    private float startTime;
    private bool readyToEndQuickDraw;

    private List<InputController> respondedPlayers;
    private int indexOfLastPlayerProcessed;
    private List<Reward> rewards;

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

        respondedPlayers = new List<InputController>();
        indexOfLastPlayerProcessed = -1;

        // Create rewards
        rewards = new List<Reward>();
        for (int i = 0; i < 1; i++) { // Just creating one for now
            Reward r = Instantiate(rewardPrefabs[0]).GetComponent<Reward>();
            rewards.Add(r);
        }
        quickDrawCavas.SetRewards(rewards);

        // Pause game
        Time.timeScale = 0;

        // Wait for play input
        readyToEndQuickDraw = false;
        while (!readyToEndQuickDraw) {

            // Process any players that have notified the system
            for (int i = indexOfLastPlayerProcessed + 1; i < respondedPlayers.Count; i++) {
                ProcessPlayer(respondedPlayers[i]);
            }
            indexOfLastPlayerProcessed = respondedPlayers.Count - 1;

            yield return null;
        }

        // Destroy any rewards still left over
        foreach(Reward r in rewards) {
            if (r != null) Destroy(r.gameObject);
        }

        // Resume game
        Time.timeScale = 1f;

    }

    private void ProcessPlayer(InputController _player) {

        // Don't process if we're already ending it
        if (readyToEndQuickDraw) return;

        // Give player item/weapon/ship here
        rewards[0].ApplyTo(_player);

        // This is for a single reward
        // Will have to change this with multi-reward quick draws
        readyToEndQuickDraw = true;

    }

    public void Notify(InputController _player) {
        respondedPlayers.Add(_player);
    }

}
