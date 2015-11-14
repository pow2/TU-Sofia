using System;
using System.Net;
using System.Windows;

namespace Malthael
{
    public static class TempMem
    {
        private static string _username;
        private static string _password;
        private static int _ID;
        private static double _price;
        private static byte _cartype;
        private static byte _caraddinfo;
        private static byte _city;
        private static string _host = "130.204.181.96:11852";
        public static string host
        {
            set { _host = value; }
            get { return _host; }
        }
        public static int ID
        {
            set { _ID = value; }
            get { return _ID; }
        }
        public static double price
        {
            set { _price = value; }
            get { return _price; }
        }
        public static string username
        {
            set { _username = value; }
            get { return _username; }
        }
        public static string password
        {
            set { _password = value; }
            get { return _password; }
        }
        public static byte cartype
        {
            set { _cartype = value; }
            get { return _cartype; }
        }
        public static byte caraddinfo
        {
            set { _caraddinfo = value; }
            get { return _caraddinfo; }
        }
        public static byte city
        {
            set { _city = value; }
            get { return _city; }
        }
    }
    public class Chk
    {   
        private string fname;
        private string lname;
        private string nomavt;
        public Chk(string fn, string ln, string na)
        {
            fname = fn;
            lname = ln;
            nomavt = na;
        }
        public override string ToString()
        {
            return "1" + ":" + fname + "," + lname + "," + nomavt;
        }
    }
    public class logininf
    {
        private string user;
        private string pass;
        public logininf(string usr, string pss)
        {
            user = usr;
            pass = pss;
        }
        public override string ToString()
        {
            return "2" + ":" + user + "," + pass;
        }

    }


    public class register
    {
        private string user;
        private string pass;
        private string fname;
        private string lname;
        private string carnum;
        private string carbrand;
        private string carmodel;
        private string cartype;
        private string carainfo;
        private string price;
        private string city;
        private string UID;
        public register(string usr, string pss, string fnam, string lnam, string carnu, string carbran, string carmode, string cartyp, string carainf, string pric, string cit, string ID)
        {
            user = usr;
            pass = pss;
            fname = fnam;
            lname = lnam;
            carnum = carnu;
            carbrand = carbran;
            carmodel = carmode;
            cartype = cartyp;
            carainfo = carainf;
            price = pric;
            city = cit;
            UID = ID;
        }
        public override string ToString()
        {
            return "3" + ":" + user + "," + pass + "," + fname + "," + lname + "," + 
                carnum + "," + carbrand + "," + carmodel + "," + cartype + "," + 
                carainfo + "," + price + "," + city + "," + UID;
        }
    }
}
