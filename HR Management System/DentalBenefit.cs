using System;
namespace HR_Management_System
{
    public class DentalBenefit : Benefit
    {
        string info;
        public DentalBenefit()
        {
            info = string.Empty;
            this.Type = "Dental Benefit";
        }
        public DentalBenefit(Double amount , string info = "")
        {
            this.info = info;
            this.Type = "Dental Health";
            this.Amount = amount;
        }

        public override double CalculateBenefit(double amount)
        {
            return 0.1 * amount;
        }
        public override string displayBenefits()
        {
            return $"{base.displayBenefits()}\nInfo: {info}";
        }


    }
}
