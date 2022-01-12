using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magpie : Character
{
    int minReward = 25;
    public Magpie(): base("Magpie", 5, 5, 0) {}

    public override int Decide(int reward, Player player) {
        if (reward / 2 >= minReward) {
            // Cooperates if it can get desired amt that way
            return 1;
        } else if (reward >= minReward) {
            // Fights if full reward is desired amt
            return 0;
        } else {
            // Flees if reward is too small either way
            return 2;
        }
    }
}
