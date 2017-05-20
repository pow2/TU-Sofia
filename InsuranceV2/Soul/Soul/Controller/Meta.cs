using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soul.Structures;

namespace Soul.Controller
{
    public class Meta
    {
        //-----------------------------------------------------------------------------------------------
        public ConnectionData Cdata { get; } = null;
        public Calculator Calc { get; } = null;
        public Checker Chk { get; } = null;
        public AppointmentCtrl AppointmentCtrl { get; } = null;
        private AppIdCtrl appIdCtrl = null;
        //-----------------------------------------------------------------------------------------------
        public string AppId { 
            get 
            {
                if (appIdCtrl != null)
                {
                    return appIdCtrl.AppId;
                }
                else
                {
                    return String.Empty;
                }
            }
        }
        //-----------------------------------------------------------------------------------------------
        public Meta()
        {
            Cdata = new ConnectionData("127.0.0.1", "10260");
            Calc = new Calculator(this);
            Chk = new Checker(this);
            AppointmentCtrl = new AppointmentCtrl(this);
            appIdCtrl = new AppIdCtrl(this);
        }
        //-----------------------------------------------------------------------------------------------
        public void SetHost(String ip, String port)
        {
            if (!String.IsNullOrWhiteSpace(ip) && !String.IsNullOrWhiteSpace(port))
            {
                Cdata.IP = ip;
                Cdata.Port = port;
            }
        }
        //-----------------------------------------------------------------------------------------------
    }
}
