using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{

    public delegate int Decision();
    public static event System.Action<Character> UpdateNPC;
    bool npcUpdated = false;

    List<Character> npcs = new List<Character> {
        new Cat(),
        new Monkey(),
        new Wolf(),
        new Magpie()
    };
    int activeNPCIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        Board.NPCConsequences += SaveConsequences;
        activeNPCIndex = Random.Range(0, npcs.Count);
    }

    // Update is called once per frame
    void Update()
    {
        if (!npcUpdated && UpdateNPC != null) {
            UpdateNPC(GetActiveNPC());
            npcUpdated = true;
        }
    }

    void OnDestroy() {
        Board.NPCConsequences -= SaveConsequences;
    }

    void GetNewNPC() {
        activeNPCIndex = Random.Range(0, npcs.Count);
    }

    public void SaveConsequences(int deltaHealth, int deltaGold, int playerAction) {
        Character activeNPC = GetActiveNPC();
        activeNPC.SaveConsequences(deltaHealth, deltaGold, playerAction);
        if (activeNPC.health <= 0) npcs.Remove(activeNPC);
        GetNewNPC();
        if (UpdateNPC != null) UpdateNPC(GetActiveNPC());
    }

    public Character GetActiveNPC() {
        return npcs[activeNPCIndex];
    }
}
