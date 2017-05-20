using Soul.Connectivity;
using Soul.Models;
using Soul.Structures;
using System;

namespace Soul.Controller
{
    class AppIdCtrl : Connectivity.ISender
    {
        //-----------------------------------------------------------------------------------------------
        private string FILE_WITH_ID = "SoulID.stg";
        public string AppId { get { return appId; } }
        public string appId = String.Empty;
        private int attempts = 0;
        private Meta meta = null;
        //-----------------------------------------------------------------------------------------------
        public AppIdCtrl(Meta meta)
        {
            this.meta = meta;
            SetId();
        }
        //-----------------------------------------------------------------------------------------------
        private async void SetId()
        {
            attempts++;
            string id = String.Empty;
            try
            {
                Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                Windows.Storage.StorageFile storageFile = await storageFolder.GetFileAsync(FILE_WITH_ID);
                id = await Windows.Storage.FileIO.ReadTextAsync(storageFile);
            }
            catch (Exception e)
            {
                string err = e.Message;
            }
            if (CheckId(id))
            {
                appId = id;
            }
            else
            {
                if (attempts > 1)
                {
                    return;
                }
                GenerateId();
                if (!CheckId(id))
                {
                    System.Threading.Tasks.Task.Delay(3000).Wait();
                }
                
                SetId();
            }
        }
        //-----------------------------------------------------------------------------------------------
        private bool CheckId(string id)
        {
            bool isAnId = true;
            if (String.IsNullOrWhiteSpace(id))
            {
                isAnId = false;
            }
            return isAnId;
        }
        //----------------------------------------------------------------------------------------------
        private async void GenerateId()
        {
            if (meta == null)
            {
                return;
            }
            HTTPConnector httpCon = new HTTPConnector(meta.Cdata);
            httpCon.SendToAsync(JsonController.AppIdToJson(new AppIdStructure()), Endpoints.NEW_APP_ID, this);
            
        }
        //-----------------------------------------------------------------------------------------------
        public async void RenderResponseAsync(string msg)
        {
            if (msg.StartsWith("{") && msg.EndsWith("}"))
            {
                try { 
                    Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                    Windows.Storage.StorageFile storageFile = await storageFolder.CreateFileAsync(FILE_WITH_ID, Windows.Storage.CreationCollisionOption.ReplaceExisting);
                    AppIdStructure appIdStr = JsonController.JsonToAppId(msg);
                    await Windows.Storage.FileIO.WriteTextAsync(storageFile, appIdStr.AppId);
                } catch (Exception e) { }
            }
        }
        //-----------------------------------------------------------------------------------------------
    }
}
