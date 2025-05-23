using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimation : MonoBehaviour
{
    private Animator anim;
    private Unit unit;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        unit = GetComponent<Unit>();
    }

    // Update is called once per frame
    void Update()
    {
        ChooseAnimation(unit);
    }

    private void ChooseAnimation(Unit u)
    {
        anim.SetBool("IsIdle", false);
        anim.SetBool("IsMove", false);
        anim.SetBool("IsAttackUnit", false);
        anim.SetBool("IsMoveToBuild", false);
        anim.SetBool("IsBuildProgress", false);
        anim.SetBool("IsMoveToResource", false);
        anim.SetBool("IsGather", false);
        anim.SetBool("IsDeliverToHQ", false);
        anim.SetBool("IsStoreAtHQ", false);
        anim.SetBool("IsMoveToEnemy", false);
        anim.SetBool("IsDie", false);
        anim.SetBool("IsMoveToEnemyBuilding", false);
        anim.SetBool("IsAttackBuilding", false);

        switch (u.State)
        {
            case UnitState.Idle:
                anim.SetBool("IsIdle", true);
                break;
            case UnitState.Move:
                anim.SetBool("IsMove", true);
                break;
            case UnitState.AttackUnit:
                anim.SetBool("IsAttackUnit", true);
                break;
            case UnitState.MoveToBuild:
                anim.SetBool("IsMoveToBuild", true);
                break;
            case UnitState.BuildProgress:
                anim.SetBool("IsBuildProgress", true);
                break;
            case UnitState.MoveToResource:
                anim.SetBool("IsMoveToResource", true);
                break;
            case UnitState.Gather:
                anim.SetBool("IsGather", true);
                break;
            case UnitState.DeliverToHQ:
                anim.SetBool("IsDeliverToHQ", true);
                break;
            case UnitState.StoreAtHQ:
                anim.SetBool("IsStoreAtHQ", true);
                break;
            case UnitState.MoveToEnemy:
                anim.SetBool("IsMoveToEnemy", true);
                break;
            case UnitState.Die:
                anim.SetBool("IsDie", true);
                break;
            case UnitState.MoveToEnemyBuilding:
                anim.SetBool("IsMoveToEnemyBuilding", true);
                break;
            case UnitState.AttackBuilding:
                anim.SetBool("IsAttackBuilding", true);
                break;
        }
    }

    /*//Idle,
    Move,
    AttackUnit,
    MoveToBuild,
    BuildProgress,
    MoveToResource,
    Gather,
    DeliverToHQ,
    StoreAtHQ,
    MoveToEnemy,
    Die*/
}
