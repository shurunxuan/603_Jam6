using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickDrawCanvas : MonoBehaviour {

    public Transform singleHolder;
    public GameObject blackBackdrop;

    public void SetRewards(List<Reward> _rewards) {
        
        for (int i = 0; i < _rewards.Count; i++) {
            GameObject o = _rewards[i].gameObject;
            o.transform.SetParent(singleHolder);
        }

    }

    public void SetBackdrop(bool _isOn)
    {
        blackBackdrop.SetActive(_isOn);
    }

}
