using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GramophoneAnimationEvent : MonoBehaviour
{
    [SerializeField]
    private Animator record;
    public void RecordSpin()
    {
        record.GetComponent<Animator>().SetBool("isSpinning", true);
    }
}
