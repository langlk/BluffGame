using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : Character
{
    public Monkey(): base("Monkey", 10, 4, 0) {}

    public override int Decide(int reward) {
        // Copies last player choice (random otherwise)
        return lastPlayerAction != -1 ? lastPlayerAction : Random.Range(0,3);
    }
}
