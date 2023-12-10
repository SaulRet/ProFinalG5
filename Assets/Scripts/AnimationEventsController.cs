using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventsController : MonoBehaviour
{
    public void onAttack()
    {
        Character2DController.Instance.Attack();
    }
}
