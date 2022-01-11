using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PlayerOption : MonoBehaviour
{
    public int option;
    public static event System.Action<int> Decide;
    Button optionButton;
    // Start is called before the first frame update
    void Start()
    {
        optionButton = gameObject.GetComponent<Button>();
        optionButton.onClick.AddListener(() => {
            if (Decide != null) Decide(option);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
