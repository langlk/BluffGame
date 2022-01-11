using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour
{

    public delegate int Decision();
    public static event System.Action<NPC> NewNPC;
    public NPC activeNPC = new NPC("Cat", 5, () => Random.Range(0,3));
    bool npcUpdated = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!npcUpdated && NewNPC != null) {
            NewNPC(activeNPC);
            npcUpdated = true;
        }
    }

    public NPC GetActiveNPC() {
        return activeNPC;
    }

    public struct NPC {
        public string name;
        public int damage;
        public Decision Decide;

        public NPC(string newName, int newDamage, Decision newDecide) {
            name = newName;
            damage = newDamage;
            Decide = newDecide;
        }
    }
}
