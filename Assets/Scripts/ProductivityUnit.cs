using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit // replaced MonoBehaviour with Unit
{
    // <-- new variables here :D -->
    private ResourcePile m_CurrentPile = null;
    public float ProductivityMultiplier = 2;

    // <-- new variables here :D -->
    protected override void BuildingInRange()
    {
        
    }
}
