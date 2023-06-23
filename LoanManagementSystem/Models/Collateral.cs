using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Models
{
    internal class Collateral
    {
        public int Id { get; set; }
        public int LoanId { get; set; }
        public string CollateralType { get; set; }
        public double CollateralValue { get; set; }
        public string CollateralLocation { get; set; }

        public Collateral(string collateralType, double collateralValue, string collateralLocation)
        {
            CollateralType = collateralType;
            CollateralValue = collateralValue;
            CollateralLocation = collateralLocation;
        }

        public Collateral()
        {
        }
    }
}
