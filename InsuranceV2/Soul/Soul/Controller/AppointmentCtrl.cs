using Soul.Connectivity;
using Soul.Structures;
using Soul.Models;
using System;
using System.Collections.Generic;

namespace Soul.Controller
{
    public class AppointmentCtrl : Connectivity.ISender
    {
        //-----------------------------------------------------------------------------------------------
        private Meta meta;
        private List<string> cities;
        private List<string> offices;
        private Dictionary<string, string> officesDict;
        //-----------------------------------------------------------------------------------------------
        public AppointmentCtrl(Meta meta)
        {
            this.meta = meta;
            ResetState();
        }
        //-----------------------------------------------------------------------------------------------
        public int State { get { return state; } }
        private int state;
        //-----------------------------------------------------------------------------------------------
        public void GetCitiesFromServer(ISender sender)
        {
            List<String> aList = null;
            CitiesStructure cStr = new CitiesStructure();
            string forSend = JsonController.JsonSerializer<CitiesStructure>(cStr);
            HTTPConnector httpCon = new HTTPConnector(meta.Cdata);
            httpCon.SendToAsync(forSend, Endpoints.APPOINTMENT1_EP, sender);
            state = 1;
        }
        //-----------------------------------------------------------------------------------------------
        public void ResetState()
        {
            state = 0;
            City = "";
            AppDTM = "";
            OfficeId = "";
            cities = new List<string>();
            offices = new List<string>();
            officesDict = new Dictionary<string, string>();
        }
        //-----------------------------------------------------------------------------------------------
        public string DateExtractor(DateTimeOffset? dto)
        {
            string resp = String.Empty;
            if (dto.HasValue == true)
            {
                resp = dto.Value.ToString("yyyyMMdd");
            }
            return resp;
        }
        //-----------------------------------------------------------------------------------------------
        public List<string> GetListOfCities(String response)
        {
            if (response.StartsWith("{") && response.EndsWith("}"))
            {
                CitiesStructure cStr = JsonController.JsonDeserialize<CitiesStructure>(response);
                cities = cStr.Cities;
                if (cities.Count == 0)
                {
                    cities.Add("Няма налични офиси в системата");
                }
                return cities;
            }
            else
            {
                return new List<string>();
            }
            
        }
        //-----------------------------------------------------------------------------------------------
        public string City { get; set; }
        public string AppDTM { get; set; }
        public void SetAppDTM(string date, string hour)
        {
            try { 
                string[] arr = hour.Split(':');
                AppDTM = date + arr[0] + arr[1] + "00000";
            } catch (Exception e) { }
        }
        //-----------------------------------------------------------------------------------------------
        public void GetFreeOffices(ISender sender)
        {
            CheckForFreeOfficeStructure cStr = new CheckForFreeOfficeStructure();
            cStr.City = City;
            cStr.Dtm = AppDTM;
            string forSend = JsonController.JsonSerializer<CheckForFreeOfficeStructure>(cStr);
            HTTPConnector httpCon = new HTTPConnector(meta.Cdata);
            httpCon.SendToAsync(forSend, Endpoints.APPOINTMENT2_EP, sender);
            state = 2;
        }
        //-----------------------------------------------------------------------------------------------
        public List<string> GetOffices(string response)
        {
            if (response.StartsWith("{") && response.EndsWith("}"))
            {
                CheckForFreeOfficeStructure cStr = JsonController.JsonDeserialize<CheckForFreeOfficeStructure>(response);
                
                foreach (string[] arr in cStr.Offices)
                {
                    offices.Add(arr[0]);
                    officesDict.Add(arr[0], arr[1]);
                }
                if (offices.Count == 0)
                {
                    offices.Add("Няма свободни офиси в посоченото време");
                }
                return offices;
            }
            else
            {
                return new List<string>();
            }
            state = 2;
        }

        //-----------------------------------------------------------------------------------------------
        public List<string> GetWorkingHours()
        {
            WorkingHours wh = new WorkingHours();
            return wh.Hours;
        }

        public void RenderResponseAsync(string msg)
        {
            throw new NotImplementedException();
        }
        //-----------------------------------------------------------------------------------------------
        private string OfficeId { get; set; }
        public void SetOffice (String office)
        {
            if (officesDict.ContainsKey(office))
            {
                OfficeId = officesDict[office];
            }
        }
        //-----------------------------------------------------------------------------------------------
        public List<string> GetAllAppintments(string response)
        {
            List<string> appointments = new List<string>();
            if (response.StartsWith("{") && response.EndsWith("}"))
            {
                AppointmentCreator cStr = JsonController.JsonDeserialize<AppointmentCreator>(response);

                if (cStr.AllAppointments != null)
                {
                    appointments = cStr.AllAppointments;
                }
                if (appointments.Count == 0)
                {
                    appointments.Add("Няма свободни офиси в посоченото време");
                }
            }
            else 
            {
                appointments.Add("Грешка в отговова на сървъра.");
            }
            return appointments;
        }
        //-----------------------------------------------------------------------------------------------
        public void MakeAnAppointment(ISender sender)
        {
            AppointmentCreator cStr = new AppointmentCreator();
            cStr.ApplicationID = meta.AppId;
            cStr.DTM = AppDTM;
            cStr.OfficeId = OfficeId;
            string forSend = JsonController.JsonSerializer<AppointmentCreator>(cStr);
            HTTPConnector httpCon = new HTTPConnector(meta.Cdata);
            httpCon.SendToAsync(forSend, Endpoints.APPOINTMENT3_EP, sender);
            CalendarManager.CreateCalendarAppointmentAsync(AppDTM, OfficeName, sender);
            state = 3;
        }

    }
}
