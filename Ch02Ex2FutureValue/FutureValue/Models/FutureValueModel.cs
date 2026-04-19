using System.ComponentModel.DataAnnotations;

namespace FutureValue.Models
{
    public class FutureValueModel
    {
        [Required(ErrorMessage = "Please enter a monthly investment amount.")]
        [Range(1, 1000000, ErrorMessage = "Monthly investment must be from 1 to 1000000.")]
        public decimal? MonthlyInvestment { get; set; }

        [Required(ErrorMessage = "Please enter a yearly interest rate.")]
        [Range(1, 100, ErrorMessage = "Yearly interest rate must be from 1 to 100.")]
        public decimal? YearlyInterestRate { get; set; }

        [Required(ErrorMessage = "Please enter the number of years.")]
        [Range(1, 100, ErrorMessage = "Years must be from 1 to 100.")]
        public int? Years { get; set; }

        public decimal? FutureValue { get; set; }

        public decimal? CalculateFutureValue()
        {
            decimal monthlyInvestment = MonthlyInvestment ?? 0;
            decimal yearlyInterestRate = YearlyInterestRate ?? 0;
            int years = Years ?? 0;

            decimal monthlyInterestRate = yearlyInterestRate / 12 / 100;
            int months = years * 12;
            decimal futureValue = 0;

            for (int i = 0; i < months; i++)
            {
                futureValue = (futureValue + monthlyInvestment) * (1 + monthlyInterestRate);
            }

            return futureValue;
        }
    }
}
