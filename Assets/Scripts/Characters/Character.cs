using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public string name;
    public int health;
    public int damage;
    public int gold;
    public int lastPlayerAction = -1;

    public Character(string newName, int newHealth, int newDamage, int newGold) {
        name = newName;
        health = newHealth;
        damage = newDamage;
        gold = newGold;
    }

    public void SaveConsequences(int deltaHealth, int deltaGold, int playerAction) {
        health += deltaHealth;
        gold += deltaGold;
        LogPlayerAction(playerAction);
    }

    public virtual int Decide() {
        return Random.Range(0,3);
    }

    protected virtual void LogPlayerAction(int action) {
        lastPlayerAction = action;
    }
}
