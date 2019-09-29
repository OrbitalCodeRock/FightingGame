using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    public string Name { get; set; }
    public int Damage { get; set; }
    public float KnockBack { get; set; }

    public Move(string name, int damage, float knockBack)
    {
        Name = name;
        Damage = damage;
        KnockBack = knockBack;
    }

}
