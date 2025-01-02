using System;


namespace HR_Management_System
{
    public class HealthBenefit : Benefit
    {
        string info;
        string coverage;
        public HealthBenefit()
        {
            info = string.Empty;
            coverage = string.Empty;
        }
        public HealthBenefit(double Amount , string info="" , string Coverage="")
        {
            this.Type = "HealthBenefit";
            this.info = info;
            this.coverage = Coverage;
        }


        public override double CalculateBenefit(double amount)
        {
            return 0.2 * amount;
        }
        public override string displayBenefits()
        {
            return $"{base.displayBenefits()}\n Info: {info} \nCoverage: {coverage}";
        }

    }
}
