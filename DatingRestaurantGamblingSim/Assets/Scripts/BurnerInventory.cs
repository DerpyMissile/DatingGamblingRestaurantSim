using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public static class BurnerInventory {
    [SerializeField] 
    public static List<Item> decorInventory { 
        get; 
        private set;
    } = new List<Item>();

    [RuntimeInitializeOnLoadMethod]
    static void Awake() {
        Decor fl = Resources.Load<Decor>("Data/Flowers");
        Decor gs = Resources.Load<Decor>("Data/Glass Swan");
        decorInventory.Add(fl);
        decorInventory.Add(gs);

        DebugInventory();
    }
    
    public static void DebugInventory() {
        string output = new System.String('-', 20);
        output += "\n";
        foreach ( var item in decorInventory ) {
            output += item + "\n";
        }

        Debug.Log(output);
    }
}