using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearablePiece : MonoBehaviour
{
    public AnimationClip clearAnimation;
    private bool isBeingCleared = false;

    public bool IsBeingCleared{
        get{return isBeingCleared;}
    }

    protected GamePiece piece;

    void Awake(){
        piece = GetComponent<GamePiece>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public ClearablePiece()
    {
        isBeingCleared = true;
        StartCoroutine(ClearCoroutine());
    }

    private IEnumerator ClearCoroutine(){
        Animator animator = GetComponent<Animator>();

        if(animator){
            animator.Play(clearAnimation.name);
            yield return new WaitForSeconds(.01f);
            Destroy(gameObject);
        }
    }
}
