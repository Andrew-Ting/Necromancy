using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalData 
{
    public enum Floor {
        NotApplicable=0,
        LowFloor=1,
        MidFloor=2,
        HighFloor=3,
        Sewer=4,
    }
    public static Vector3[] spawnPosition = new Vector3[5]; // where the player will spawn in each floor when the scene loads

    public static class SpecialInteractionData {
        public static bool unlockedSewers = false;
        public static int ghostProgress = 0;
    }
}
