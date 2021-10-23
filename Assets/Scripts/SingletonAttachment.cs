using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonAttachment : MonoBehaviour
{
    static SingletonAttachment instance = null;
    private void Awake() {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
