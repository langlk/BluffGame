using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Character
{
    int cooperateCounter = 0;
    public Wolf(): base("Wolf", 20, 6, 0) {}

    public override int Decide(int reward) {
        // Attacks or flees by default
        // If player cooperates 3 times, wolf will always cooperate
        // Resets if attacked
        return cooperateCounter == 3 ? 1 : 2 * Random.Range(0,1);
    }

    protected override void LogPlayerAction(int playerAction) {
        if (playerAction == 1 && cooperateCounter < 3) {
            cooperateCounter++;
        } else if (playerAction == 0) {
            cooperateCounter = 0;
        }
    }
}
