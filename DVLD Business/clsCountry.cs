using DVLD_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsCountry
    {
        public int ID;
        public string CountryName { get; set; }

        private clsCountry(int ID, string CountryName)
        {
            this.ID = ID;
            this.CountryName = CountryName;
        }
        public static clsCountry Find(int ID)
        {
            string CountryName = "";
  
            if (clsCountryData.GetCountryByID(ID,ref CountryName))
            {
                return new clsCountry(ID,CountryName);
            }
            else
                return null;

        }
        public static clsCountry Find(string CountryName)
        {
            int ID = -1;

            if (clsCountryData.GetCountryByName(ref ID, CountryName))
            {
                return new clsCountry(ID, CountryName);
            }
            else
                return null;

        }

        public static DataTable GetAllCountries()
        {
            return clsCountryData.GetAllCountries();
        }
    }
}
