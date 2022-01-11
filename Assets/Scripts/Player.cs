using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public int health = 20;
    public int damage = 5;
    public int gold = 0;
    public Text healthText;
    public Text damageText;
    public Text goldText;
    // Start is called before the first frame update
    void Start()
    {
        RenderInfo();
        Board.PlayerConsequences += SaveConsequences;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy() {
        Board.PlayerConsequences -= SaveConsequences;
    }

    public void RenderInfo() {
        healthText.text = health.ToString();
        damageText.text = damage.ToString();
        goldText.text = gold.ToString();
    }

    public void SaveConsequences(int deltaHealth, int deltaGold) {
        health += deltaHealth;
        gold += deltaGold;
        RenderInfo();
    }
}
