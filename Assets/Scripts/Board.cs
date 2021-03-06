using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public Text rewardText;
    public int maxRounds = 10;
    public static event System.Action GameWon;
    public static event System.Action<int, int> PlayerConsequences;
    public static event System.Action<int, int, int> NPCConsequences;
    int round = 0;
    int reward = 12;
    // Start is called before the first frame update
    void Start()
    {
        PlayerOption.Decide += Decide;
        RollReward();
        RenderReward();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy() {
        PlayerOption.Decide -= Decide;
    }

    public void RollReward() {
        reward = Random.Range(1, 25) * 4;
    }

    public void RenderReward() {
        rewardText.text = reward.ToString() + " gold";
    }

    public void Decide(int option) {
        round += 1;
        Character npc = gameObject.GetComponentInChildren<CharacterManager>().GetActiveNPC();
        Player player = gameObject.GetComponentInChildren<Player>();
        int npcOption = npc.Decide(reward, player);
        int deltaHealth = 0;
        int deltaGold = 0;
        int npcDeltaHealth = 0;
        int npcDeltaGold = 0;
        
        switch (option) {
            case 0: // Fight
                switch (npcOption) {
                    case 0:
                        deltaHealth = -npc.damage;
                        npcDeltaHealth = -player.damage;
                        break;
                    case 1:
                        deltaGold = reward;
                        npcDeltaHealth = -player.damage;
                        break;
                    case 2:
                        deltaGold = reward;
                        break;
                }
                break;
            case 1: // Cooperate
                switch (npcOption) {
                    case 0:
                        deltaHealth = -npc.damage;
                        npcDeltaGold = reward;
                        break;
                    case 1:
                        deltaGold = reward / 2;
                        npcDeltaGold = reward / 2;
                        break;
                    case 2:
                        deltaGold = reward;
                        break;
                }
                break;
            case 2: // Flee
                switch (npcOption) {
                    case 0:
                        npcDeltaGold = reward;
                        break;
                    case 1:
                        npcDeltaGold = reward;
                        break;
                    case 2:
                        break;
                }
                break;
        }
        if (PlayerConsequences != null) PlayerConsequences(deltaHealth, deltaGold);
        if (NPCConsequences != null) NPCConsequences(npcDeltaHealth, npcDeltaGold, option);
        if (round >= maxRounds && GameWon != null) GameWon();
        RollReward();
        RenderReward();
    }
}
