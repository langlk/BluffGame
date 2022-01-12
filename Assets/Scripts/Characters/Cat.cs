using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Character
{
    public Cat(): base("Cat", 10, 5, 0) {}

    public override int Decide() {
        if (lastPlayerAction == 2) {
            return Random.Range(0,2);
        } else {
            return Random.Range(0,3);
        }
    }
}
