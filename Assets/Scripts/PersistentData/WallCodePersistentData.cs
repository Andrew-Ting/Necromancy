using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName="Wall Code", menuName="Wall Code")]
public class WallCodePersistentData : ScriptableObject
{
    [SerializeField] private List<Sprite> hieroglyphs = new List<Sprite>(); 
    [SerializeField] private List<int> randomlyGeneratedHieroglyphIndexes;
    private void OnEnable()
     {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
     }
    public void ResetData()
    {
        randomlyGeneratedHieroglyphIndexes = new List<int>();
        while (randomlyGeneratedHieroglyphIndexes.Count < 4) {
            int a;
            do {
                a = Random.Range(0, hieroglyphs.Count);
            }
            while (randomlyGeneratedHieroglyphIndexes.Contains(a));
            randomlyGeneratedHieroglyphIndexes.Add(a);
        }
    }
    public Sprite GetHieroglyphAtIndex(int index) {
        if (index < 0 || index >= 4) {
            Debug.LogError("Index is not within code range. Its value is " + index);
            return null;
        }

        return hieroglyphs[randomlyGeneratedHieroglyphIndexes[index]];
    }
    public int GetHieroglyphIndexAtIndex(int index) {
        if (index < 0 || index >= 4) {
            Debug.LogError("Index is not within code range. Its value is " + index);
            return -1;
        }
        Debug.Log("HIEROGLYPH COUNT: " + randomlyGeneratedHieroglyphIndexes.Count);

        return randomlyGeneratedHieroglyphIndexes[index];
    }
    
}
