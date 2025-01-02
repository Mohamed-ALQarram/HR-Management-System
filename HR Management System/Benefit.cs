using System;

namespace HR_Management_System
{
    public abstract class Benefit
    {
        double amount;
        string type;

        public  Benefit()
        {
            amount = 0;
            type = string.Empty;
        }
        
        public double Amount { get { return amount; } set { amount = value; } }

        public string Type { get { return type; } set { type= value; } }

        public abstract double CalculateBenefit(double amount);
        public virtual string displayBenefits() { 
        return $"Benefit type is: {type} \nBenefit Amount= {Amount}";
        }

    }
}
