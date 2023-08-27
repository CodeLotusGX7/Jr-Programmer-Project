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
        if (m_CurrentPile == null)
        {
            ResourcePile pile = m_Target as ResourcePile;

            if (pile != null)
            {
                m_CurrentPile = pile;
                m_CurrentPile.ProductionSpeed *= ProductivityMultiplier;
            }
        }
    }

    void ResetProductivity()
    {
        if (m_CurrentPile != null)
        {
            m_CurrentPile.ProductionSpeed /= ProductivityMultiplier;
            m_CurrentPile = null;
        }
    }
    public override void GoTo(Building target) // for targeting buildings
    {
        ResetProductivity(); // call method to put pile rate to normal
        base.GoTo(target); // run method from base class
    }

    public override void GoTo(Vector3 position) // for targeting random location on map
    {
        ResetProductivity();
        base.GoTo(position);
    }
}
