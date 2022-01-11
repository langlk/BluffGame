using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInfo : MonoBehaviour
{
    public Text nameText;
    public Text damageText;

    // Start is called before the first frame update
    void Start()
    {
        Characters.NewNPC += RenderNPCInfo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy() {
        Characters.NewNPC -= RenderNPCInfo;
    }

    void RenderNPCInfo(Characters.NPC npc) {
        nameText.text = npc.name;
        damageText.text = npc.damage.ToString();
    }
}
