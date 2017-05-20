using Soul.Connectivity;
using Soul.Pages;
using Soul.Structures;
using Soul.Models;
using System;
using System.Collections.Generic;

namespace Soul.Controller
{
    public class Calculator
    {
        //-----------------------------------------------------------------------------------------------
        public BindingLists BindingLists { get; } = null;
        private Meta meta;
        //-----------------------------------------------------------------------------------------------
        public Calculator(Meta meta)
        {
            this.meta = meta;
            BindingLists = new BindingLists();
        }
        //-----------------------------------------------------------------------------------------------
        public List<string> VehCapacity(string vehicle)
        {
            return BindingLists.VehCapacity(vehicle);
        }
        //-----------------------------------------------------------------------------------------------
        public void GetRespFromServer(string city, string vehicle, string capacity, ISender sender)
        {
            CalcStructure calcStruct = new CalcStructure(city, vehicle, capacity);
            string forSend = JsonController.CalculateToJson(calcStruct);
            HTTPConnector httpCon = new HTTPConnector(meta.Cdata);
            httpCon.SendToAsync(forSend, Endpoints.CALC_EP, sender);
        }
        //-----------------------------------------------------------------------------------------------
        public string GetSum(String jsonStruct)
        {
            CalcStructure calcStruct =  JsonController.JsonToCalculate(jsonStruct);
            return calcStruct.Sum;
        }
        //-----------------------------------------------------------------------------------------------
        public string FormatResponse(string response)
        {
            string resp = String.Empty;
            if (response.StartsWith("{") && response.EndsWith("}"))
            {
                resp = GetSum(response);
            }
            else
            {
                resp = response;
            }
            return resp;
        }
        //-----------------------------------------------------------------------------------------------
    }
}
