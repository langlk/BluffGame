using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour
{

    public delegate int Decision();
    public static event System.Action<NPC> UpdateNPC;
    public NPC activeNPC = new NPC("Cat", 10, 5, 0, () => Random.Range(0,3));
    bool npcUpdated = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Board.NPCConsequences += SaveConsequences;
    }

    // Update is called once per frame
    void Update()
    {
        if (!npcUpdated && UpdateNPC != null) {
            UpdateNPC(activeNPC);
            npcUpdated = true;
        }
    }

    void OnDestroy() {
        Board.NPCConsequences -= SaveConsequences;
    }

    public void SaveConsequences(int deltaHealth, int deltaGold) {
        activeNPC.SaveConsequences(deltaHealth, deltaGold);
        if (UpdateNPC != null) UpdateNPC(activeNPC);
    }

    public NPC GetActiveNPC() {
        return activeNPC;
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
