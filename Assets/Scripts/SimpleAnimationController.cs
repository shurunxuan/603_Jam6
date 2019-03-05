using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAnimationController : MonoBehaviour {

    private Animator animator;

    public bool willBeDestroy;

    void Awake () {
        animator = GetComponent<Animator>();
    }

    public void OnDestroy() {
        if (willBeDestroy)
            Destroy(gameObject);
        else 
            gameObject.SetActive(false);
    }

    public void PlayAnimation(string animName) {
        animator.Play(animName);
    }

}
