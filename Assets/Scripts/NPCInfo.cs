using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInfo : MonoBehaviour
{
    public Text nameText;
    public Text damageText;
    public Text healthText;
    public Text goldText;

    // Start is called before the first frame update
    void Start()
    {
        CharacterManager.UpdateNPC += RenderNPCInfo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy() {
        CharacterManager.UpdateNPC -= RenderNPCInfo;
    }

    void RenderNPCInfo(Character npc) {
        nameText.text = npc.name;
        damageText.text = npc.damage.ToString();
        healthText.text = npc.health.ToString();
        goldText.text = npc.gold.ToString();
    }
}
