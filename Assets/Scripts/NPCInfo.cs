using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInfo : MonoBehaviour
{
    public Text nameText;
    public Text damageText;
    public NPC npc = new NPC("Cat", 5, () => Random.Range(0,3));

    // Start is called before the first frame update
    void Start()
    {
        RenderNPCInfo(npc);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RenderNPCInfo(NPC npc) {
        nameText.text = npc.name;
        damageText.text = npc.damage.ToString();
    }

    public delegate int Decision();

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
