using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MinigameController : MonoBehaviour
{
    public event Action<bool> minigameDisplaying;
    public void freezeCharacter() {
        minigameDisplaying.Invoke(true);
    }
    public void unfreezeCharacter() {
        minigameDisplaying.Invoke(false);
    }
}
