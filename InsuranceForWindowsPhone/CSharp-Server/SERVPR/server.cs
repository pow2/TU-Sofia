using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace SERVPL
{
    class Server
    {
        private TcpListener tcpListener;
        private Thread listenThread;
        public Server()
        {
            this.tcpListener = new TcpListener(IPAddress.Any, 11852);
            this.listenThread = new Thread(new ThreadStart(ListenForClients));
            this.listenThread.Start();
        }
        private void ListenForClients()
        {
            this.tcpListener.Start();

            while (true)
            {
                //blocks until a client has connected to the server
                TcpClient client = this.tcpListener.AcceptTcpClient();
                
                //create a thread to handle communication 
                //with connected client
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);
            }
        }

        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();

            byte[] message = new byte[2048];
            int bytesRead;



            while (true)
            {
                bytesRead = 0;

                try
                {
                    //blocks until a client sends a message
                    bytesRead = clientStream.Read(message, 0, 2048);
                }
                catch
                {
                    //a socket error has occured
                    break;
                }

                if (bytesRead == 0)
                {
                    //the client has disconnected from the server
                    break;
                }

                //message has successfully been received
                UTF8Encoding encoder = new UTF8Encoding();
                System.Diagnostics.Debug.WriteLine(encoder.GetString(message, 0, bytesRead));
                encoder.GetString(message, 0, bytesRead);
                try
                {
                    string[] resultParts0 = encoder.GetString(message, 0, bytesRead).Split(':');
                    string operation = resultParts0[0].Trim();
                    string msg = resultParts0[1].Trim();
                    System.Diagnostics.Debug.WriteLine(operation);
                    System.Diagnostics.Debug.WriteLine(msg);
                    if (Convert.ToInt32(operation) == 1)
                    {
                        string[] resultParts1 = msg.Split(',');
                        string fname = resultParts1[0].Trim();
                        string lname = resultParts1[1].Trim();
                        string carnum = resultParts1[2].Trim();
                        Console.WriteLine("Checking: \nFist Name: {0}\nLast Name: {1}\nRegistration Number: {2}", fname, lname, carnum);
                        ZastValidation zv = new ZastValidation(fname, lname, carnum);
                        ZAST zast;
                        if (zv.ValidateZast(out zast))
                        {
                            Console.WriteLine("Expire Date: " + zast.ExpireDateDay + "." + zast.ExpireDateMonth + "." + zast.ExpireDateYear);
                            byte[] buffer = encoder.GetBytes("Дата на изтичане: " + zast.ExpireDateDay + "." + zast.ExpireDateMonth + "." + zast.ExpireDateYear);
                            clientStream.Write(buffer, 0, buffer.Length);
                            clientStream.Flush();
                        }
                        else
                        {
                            Console.WriteLine("No Insurance Found");
                            byte[] buffer = encoder.GetBytes("Нямате застраховка");
                            clientStream.Write(buffer, 0, buffer.Length);
                            clientStream.Flush();
                        }

                        
                    }
                    else if (Convert.ToInt32(operation) == 2)
                    {

                        //CASE 2
                        string[] resultParts2 = msg.Split(',');
                        string uname = resultParts2[0].Trim();
                        string pss = resultParts2[1].Trim();
                        Console.WriteLine("Checking Account: {0}", uname);
                        LoginValid lv = new LoginValid(uname, pss);
                        User user;
                        if (lv.ValidateUser(out user))
                        {
                            Console.WriteLine("User Found: \nFist Name: {0} \nLast Name: {1} \nE-mail: {2}", user.FName, user.LName, user.Email);
                            string id = user.Id.ToString();
                            Console.WriteLine("Sending: {0}", id);
                            byte[] buffer = encoder.GetBytes(id);
                            clientStream.Write(buffer, 0, buffer.Length);
                            clientStream.Flush();
                            
                        }
                        else
                        {
                            Console.WriteLine("No User Found");
                            byte[] buffer = encoder.GetBytes("Грешно име или парола");
                            clientStream.Write(buffer, 0, buffer.Length);
                            clientStream.Flush();
                        }

                        // END OF CASE 2

                    }
                    else if (Convert.ToInt32(operation) == 3)
                    {
                        try
                        {
                            string[] resultParts3 = msg.Split(',');
                            string uuser = resultParts3[0].Trim();
                            string ppass = resultParts3[1].Trim();
                            string ffname = resultParts3[2].Trim();
                            string llname = resultParts3[3].Trim();
                            string nnum = resultParts3[4].Trim();
                            string bbrand = resultParts3[5].Trim();
                            string mmodel = resultParts3[6].Trim();
                            Int16 ccartype = Convert.ToInt16(resultParts3[7].Trim());
                            string ccaraddinfo = resultParts3[8].Trim();
                            string pprice = resultParts3[9].Trim();
                            Int16 ccity = Convert.ToInt16(resultParts3[10].Trim());
                            int empid = Convert.ToInt32(resultParts3[11].Trim());

                            try
                            {

                                ZAST zast1 = new ZAST();
                                ZastValidation zv2 = new ZastValidation(ffname, llname, nnum);
                                ZAST zast2;
                                if (zv2.ValidateZast(out zast2))
                                {
                                        zast1.ExpireDateDay = Convert.ToInt16(1);
                                        zast1.ExpireDateMonth = Convert.ToInt16(Convert.ToInt32(zast2.ExpireDateMonth) + 1);
                                        zast1.ExpireDateYear = zast2.ExpireDateYear + 1;
                                }
                                else
                                {
                                    DateTime thisDay = DateTime.Today;
                                    Console.WriteLine(thisDay.ToString("d"));
                                    string[] resultParts4 = thisDay.ToString("d").Split('.');
                                    string[] resultParts5 = resultParts4[2].Split(' ');
                                    Int16 month = Convert.ToInt16(resultParts4[1].Trim());
                                    Int16 day = Convert.ToInt16(resultParts4[0].Trim());
                                    Int32 yr = Convert.ToInt32(resultParts5[0].Trim());
                                    zast1.ExpireDateDay = Convert.ToInt16(1);
                                    zast1.ExpireDateMonth = Convert.ToInt16(Convert.ToInt32(month) + 1);
                                    zast1.ExpireDateYear = yr + 1;
                                      
                                }
                                try
                                {
                                    zast1.FName = ffname;
                                    zast1.LName = llname;
                                    zast1.CarNum = nnum;
                                    zast1.CarBrand = bbrand;
                                    zast1.CarModel = mmodel;
                                    zast1.CarType = ccartype;
                                    zast1.CarAddinfo = ccaraddinfo;
                                    zast1.employee = empid;
                                    zast1.Price = pprice;
                                    zast1.City = ccity;
                                        if (ZastValidation.InsertZast(zast1))
                                        {
                                            Console.WriteLine("Zast created successfully. New expire date: " + zast1.ExpireDateDay + "." + zast1.ExpireDateMonth + "." + zast1.ExpireDateYear);
                                            byte[] buffer = encoder.GetBytes("Застраховката е създадена успешно. \n Дата на изтичане: " + zast1.ExpireDateDay + "." + zast1.ExpireDateMonth + "." + zast1.ExpireDateYear);
                                            clientStream.Write(buffer, 0, buffer.Length);
                                            clientStream.Flush();
                                        }
                                        else
                                        {
                                            byte[] buffer = encoder.GetBytes("Системата не може да изпълни заявката в момента");
                                            clientStream.Write(buffer, 0, buffer.Length);
                                            clientStream.Flush();
                                        }
                                }
                                catch
                                {
                                    byte[] buffer = encoder.GetBytes("Грешка номер 3");
                                    clientStream.Write(buffer, 0, buffer.Length);
                                    clientStream.Flush();
                                }
                            }
                            catch
                            {
                                byte[] buffer = encoder.GetBytes("Грешка номер 2");
                                clientStream.Write(buffer, 0, buffer.Length);
                                clientStream.Flush();
                            }
                        }
                      catch
                        {
                            byte[] buffer = encoder.GetBytes("Грешка номер 1");
                            clientStream.Write(buffer, 0, buffer.Length);
                            clientStream.Flush();
                        }
                    }
                    
                }
                catch (Exception e) 
                {
                    byte[] buffer = encoder.GetBytes("Неизвестна команда!");
                    clientStream.Write(buffer, 0, buffer.Length);
                    clientStream.Flush();
                }
            }

            tcpClient.Close();
        }


    }
}
