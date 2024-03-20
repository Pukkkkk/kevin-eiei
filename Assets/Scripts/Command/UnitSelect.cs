using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnitSelect : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private List<Unit> curUnits; //current selected single unit
    public List<Unit> CurUnits { get { return curUnits; } }

    private Camera cam;
    private Faction faction;

    [SerializeField]
    private Building curBuilding; //current selected single building
    public Building CurBuilding { get { return curBuilding; } }


    public static UnitSelect instance;

    void Awake()
    {
        faction = GetComponent<Faction>();
    }
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        layerMask = LayerMask.GetMask("Unit", "Building", "Resource", "Ground");

        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //if click UI, dont clear
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            ClearEverything();
        }

        // mouse up
        if (Input.GetMouseButtonUp(0))
        {
            TrySelect(Input.mousePosition);
        }
    }

    private void SelectUnit(RaycastHit hit)
    {
        Unit unit = hit.collider.GetComponent<Unit>();

        Debug.Log("Selected Unit");

        if (GameManager.instance.MyFaction.IsMyUnit(unit))
        {
            curUnits.Add((unit));
            unit.ToggleSelectionVisual(true);
            ShowUnit(unit);
        }
    }

    private void TrySelect(Vector2 screenPos)
    {
        Ray ray = cam.ScreenPointToRay(screenPos);
        RaycastHit hit;

        //if we left-click something
        if (Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            switch (hit.collider.tag)
            {
                case "Unit":
                    SelectUnit(hit);
                    break;
                case "Building":
                    BuildingSelect(hit);
                    break;
            }
        }
    }
    private void ClearAllSelectionVisual()
    {
        foreach (Unit u in  curUnits)
        {
            u.ToggleSelectionVisual(false);
        }

        if (curBuilding != null)
            curBuilding.ToggleSelectionVisual(false);
    }
    private void ClearEverything()
    {
        ClearAllSelectionVisual();
        curUnits.Clear();
        curBuilding = null;

        //Clear UI
        InfoManager.instance.ClearAllInfo();
    }

    private void ShowUnit(Unit u)
    {
        InfoManager.instance.ShowAllInfo(u);

        if (u.IsBuilder)
            ActiveManager.instance.ShowBuilderMode(u);
    }

    private void ShowBuilding(Building b)
    {
        InfoManager.instance.ShowAllInfo(b);
        ActiveManager.instance.ShowCreateUnitMode(b);
    }

    private void BuildingSelect(RaycastHit hit)
    {
        curBuilding = hit.collider.GetComponent<Building>();
        curBuilding.ToggleSelectionVisual(true);

        if (GameManager.instance.MyFaction.IsMyBuilding(curBuilding))
        {
            //Debug.Log("my building");
            ShowBuilding(curBuilding);//Show building info
        }
    }

}
