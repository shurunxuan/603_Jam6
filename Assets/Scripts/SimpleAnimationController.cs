using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAnimationController : MonoBehaviour {

    private Animator animator;

    void Awake () {
        animator = GetComponent<Animator>();
    }

    public void OnDestroy() {
        Destroy(gameObject);
    }

    public void PlayAnimation(string animName) {
        animator.Play(animName);
    }

}
