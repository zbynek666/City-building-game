using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomeManager : MonoBehaviour
{
    // Start is called before the first frame update
    private float income = 0;
    private float expense = 0;

    private float moneyPerResidance = 50;
    private float moneyPerComercial = 80;
    private float moneyPerIndustrial = 150;



    private int basicIncome = 1;

    public float ResidanceTax = 0.1f;
    public float ComercialTax = 0.1f;
    public float IndustrialTax = 0.1f;



    public int getIncome()
    {
        CalculateIncome();
        CalculateExpense();
        return (int)(income - expense);
    }

    private void CalculateIncome()
    {
        income = basicIncome + 0.0f;
        float rm = 0;
        float cm = 0;
        float im = 0;

        foreach (BasicBuilding b in GridManager.Instance.getTypeOfObject<BasicBuilding>())
        {
            if (b is ResidencBulding)
            {
                for (int i = 0; i < b.population; i++)
                {
                    rm += (moneyPerResidance * (1 + (b.happines + 0.0f) / 100));
                }
            }
            else if (b is ComercialBuilding)
            {
                for (int i = 0; i < b.population; i++)
                {
                    cm += (moneyPerComercial * (1 + (b.happines + 0.0f) / 100));
                }
            }
            else if (b is IndustrialBuilding)
            {
                for (int i = 0; i < b.population; i++)
                {
                    im += (moneyPerIndustrial * (1 + (b.happines + 0.0f) / 100));
                }
            }

        }

        income = (rm * ResidanceTax) + (cm * ComercialTax) + (im * IndustrialTax);

    }
    private void CalculateExpense()
    {
        expense = 0;
        foreach (NeedsProvidingBuilding b in GridManager.Instance.getTypeOfObject<NeedsProvidingBuilding>())
        {
            expense += b.expense;
        }
        foreach (Service b in GridManager.Instance.getTypeOfObject<Service>())
        {
            expense += b.expense;

        }
        foreach (RangeBuilding b in GridManager.Instance.getTypeOfObject<RangeBuilding>())
        {
            expense += b.expense;

        }
        foreach (TownHall b in GridManager.Instance.getTypeOfObject<TownHall>())
        {
            expense += b.expense;

        }
    }
}
