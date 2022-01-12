using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Character
{
    public Cat(): base("Cat", 10, 5, 0) {}

    public override int Decide() {
        // Always flees, unless player fled last time, then will attack or cooperate
        return lastPlayerAction == 2 ? Random.Range(0,2) : 2;
    }
}
