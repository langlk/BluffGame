using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Character
{
    public Cat(): base("Cat", 10, 5, 0) {}

    public override int Decide(int reward, Player player) {
        // If can kill player, will attack
        if (player.health <= damage) return 0;
        // Otherwise always flees, unless player fled last time, then will flee *or* cooperate
        return lastPlayerAction == 2 ? Random.Range(1,3) : 2;
    }
}
