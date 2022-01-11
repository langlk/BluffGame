using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public int reward = 10;
    public static event System.Action<int, int> PlayerConsequences;
    public Text rewardText;
    // Start is called before the first frame update
    void Start()
    {
        PlayerOption.Decide += Decide;
        RenderReward();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy() {
        PlayerOption.Decide -= Decide;
    }

    public void RenderReward() {
        rewardText.text = reward.ToString() + " gold";
    }

    public void Decide(int option) {
        Characters.NPC npc = gameObject.GetComponentInChildren<Characters>().GetActiveNPC();
        int npcOption = npc.Decide();
        int deltaHealth = 0;
        int deltaGold = 0;
        
        // currently just calculating player effects, hence nothing happening on some combos
        switch (option) {
            case 0:
                switch (npcOption) {
                    case 0:
                        deltaHealth = -npc.damage;
                        break;
                    case 1:
                        deltaGold = reward;
                        break;
                    case 2:
                        deltaGold = reward;
                        break;
                }
                break;
            case 1:
                switch (npcOption) {
                    case 0:
                        deltaHealth = -npc.damage;
                        break;
                    case 1:
                        deltaGold = reward;
                        break;
                    case 3:
                        deltaGold = reward;
                        break;
                }
                break;
            case 2:
                switch (npcOption) {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 3:
                        break;
                }
                break;
        }
        if (PlayerConsequences != null) PlayerConsequences(deltaHealth, deltaGold);
    }
}
