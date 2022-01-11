using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour
{

    public delegate int Decision();
    public static event System.Action<NPC> UpdateNPC;
    bool npcUpdated = false;

    List<NPC> npcs = new List<NPC> {
        new NPC("Cat", 10, 5, 0, () => Random.Range(0,3)),
        new NPC("Slime", 1, 1, 0, () => 0),
        new NPC("Spider", 5, 5, 0, () => Random.Range(0,2)),
        new NPC("Wolf", 10, 10, 0, () => Random.Range(0,3)),
        new NPC("Crow", 10, 10, 0, () => 1)
    };
    int activeNPCIndex = Random.Range(0, 5);
    
    // Start is called before the first frame update
    void Start()
    {
        Board.NPCConsequences += SaveConsequences;
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

    public void SaveConsequences(int deltaHealth, int deltaGold) {
        GetActiveNPC().SaveConsequences(deltaHealth, deltaGold);
        GetNewNPC();
        if (UpdateNPC != null) UpdateNPC(GetActiveNPC());
    }

    public NPC GetActiveNPC() {
        return npcs[activeNPCIndex];
    }

    public struct NPC {
        public string name;
        public int health;
        public int damage;
        public int gold;
        public Decision Decide;

        public NPC(string newName, int newHealth, int newDamage, int newGold, Decision newDecide) {
            name = newName;
            health = newHealth;
            damage = newDamage;
            gold = newGold;
            Decide = newDecide;
        }

        public void SaveConsequences(int deltaHealth, int deltaGold) {
            health += deltaHealth;
            gold += deltaGold;   
        }
    }
}
