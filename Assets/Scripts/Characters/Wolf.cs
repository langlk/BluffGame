using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Character
{
    int cooperateCounter = 0;
    public Wolf(): base("Wolf", 20, 6, 0) {}

    public override int Decide(int reward, Player player) {
        // If player cooperates 3 times, wolf will always cooperate
        if (cooperateCounter == 3) return 1;
        // If player can kill, will flee
        if (player.damage >= health) return 2;
        // Attacks or flees by default
        return 2 * Random.Range(0, 1);
    }

    protected override void LogPlayerAction(int playerAction) {
        if (playerAction == 1 && cooperateCounter < 3) {
            cooperateCounter++;
        } else if (playerAction == 0) {
            // reset cooperate counter if attacked
            cooperateCounter = 0;
        }
    }
}
