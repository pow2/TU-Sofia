using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVPL
{
    class ZastValidation
    {

        private static string _fname;
        private static string _lname;
        private static string _carnum;

        public ZastValidation(string fn, string ln, string cn)
            {
                _fname = fn;
                _lname = ln;
                _carnum = cn;
            }

        public static ZAST getZast(string fname, string lname, string carnum)
        {
            return ZastValidation._getZast(fname, lname, carnum);
        }
        private static ZAST _getZast(string fname, string lname, string carnum)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            var queryResult = (from zast in dc.GetTable<ZAST>()
                               where (zast.FName == fname) &&
                                   (zast.LName == lname) &&
                                   (zast.CarNum == carnum)
                               select zast).ToArray<ZAST>();
            if (queryResult.Count<ZAST>() > 0)
                return queryResult[0];
            else return null;
        }

        public bool ValidateZast(out ZAST zast)
        {
            ZAST queryResult = ZastValidation._getZast(_fname, _lname, _carnum);
            zast = queryResult;
            if (queryResult == null)
            {
                return false;
            }
            return true;
        }



        public static bool InsertZast(ZAST z)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            try
            {
                dc.AddNewZast(z.FName, z.LName, z.CarNum, z.CarBrand, z.CarModel, (Int16)z.CarType, z.CarAddinfo, (Int16)z.ExpireDateDay, (Int16)z.ExpireDateMonth, (int)z.ExpireDateYear, (int)z.employee, z.Price, (Int16)z.City);
                dc.SubmitChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }


    }
}
