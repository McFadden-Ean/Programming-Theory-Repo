using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : Food //INHERITANCE
{
    public override void Satisfy() //POLYMORPHISM
    {
        player.GetComponent<Player>().speed += 1;
    }
}
