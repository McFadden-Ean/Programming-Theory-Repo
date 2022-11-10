using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steak : Food //INHERITANCE
{
    public override void Satisfy() //POLYMORPHISM
    {
        player.GetComponent<Player>().speed += 2;
    }
}
