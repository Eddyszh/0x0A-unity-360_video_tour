using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossfadeTransition : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private ChangeRooms change;
    private float wait = 1.2f;

    public void StartTransition(int i)
    {
        anim.SetTrigger("TransitionIn");
        StartCoroutine(EndTransition(i));
    }

    IEnumerator EndTransition(int i)
    {
        yield return new WaitForSeconds(wait);
        change.Move(i);
        anim.SetTrigger("TransitionOut");
    }
}
