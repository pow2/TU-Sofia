using Soul.Connectivity;
using Soul.Models;
using Soul.Structures;
using System;
using System.Text.RegularExpressions;

namespace Soul.Controller
{
    public class Checker
    {
        //-----------------------------------------------------------------------------------------------
        private Meta meta;
        //-----------------------------------------------------------------------------------------------
        public Checker(Meta meta)
        {
            this.meta = meta;
        }
        //----------------------------------------------------------------------------------------------
        public bool CheckIfBgPlate(string number)
        {
            bool resp = false;
            string pat = "[A-Z]{1,2}[\\s]*[0-9]{4}[\\s]*[A-Z]{2}";
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);
            Match m = r.Match(number);
            if (m.Success)
            {
                resp = true;
            }
            return resp;
        }
        //-----------------------------------------------------------------------------------------------
        public void CheckIfActive(string number, ISender sender)
        {
            CheckIfActiveStructure checkStruct = new CheckIfActiveStructure();
            checkStruct.Number = number;
            String forSend = JsonController.CheckIfActiveToJson(checkStruct);
            HTTPConnector httpCon = new HTTPConnector(meta.Cdata);
            httpCon.SendToAsync(forSend, Endpoints.CHECK_EP, sender);
        }
        //-----------------------------------------------------------------------------------------------
        public string GetActiveStatus(string jsonStruct)
        {
            string resp = String.Empty;
            if (jsonStruct.StartsWith("{") && jsonStruct.EndsWith("}"))
            {
                CheckIfActiveStructure checkStruct = JsonController.JsonToCheckIfActive(jsonStruct);
                if (!checkStruct.Date.Equals(String.Empty))
                {
                    resp = checkStruct.Date;
                }
                else
                {
                    resp = Errors.NOTACTIVEINS;
                }
            }
            else
            {
                resp = jsonStruct;
            }
            return resp;

        }
        //-----------------------------------------------------------------------------------------------
        public string VerifyAndSend(string number, ISender sender)
        {
            string resp = string.Empty;
            if (!number.Equals(String.Empty))
            {
                string pat = "[A-ZА-Я]{1,2}[\\s]*[0-9]{4}[\\s]*[A-ZА-Я]{2}";
                Regex r = new Regex(pat, RegexOptions.IgnoreCase);
                Match m = r.Match(number);
                if (m.Success)
                {
                    CheckIfActive(number, sender);
                } else
                {
                    resp = Errors.INVALIDNUMBER;
                }
            }
            else
            {
                resp = Errors.FILLTHENUMBER;
            }
            return resp;
        }
        //-----------------------------------------------------------------------------------------------
    }
}
