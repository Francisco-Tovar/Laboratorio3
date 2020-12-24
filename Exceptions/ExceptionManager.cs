using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace Exceptions
{
    public class ExceptionManager
    {

        public string PATH = "";

        private static ExceptionManager instance;

        private static Dictionary<int, ApplicationMessage> messages = new Dictionary<int, ApplicationMessage>();

        private ExceptionManager()
        {
            LoadMessages();
            PATH = ConfigurationManager.AppSettings.Get("LOG_PATH");
        }

        public static ExceptionManager GetInstance()
        {
            if (instance == null)
                instance = new ExceptionManager();

            return instance;
        }

        public void Process(Exception ex)
        {

            var bex = new BussinessException();


            if (ex.GetType() == typeof(BussinessException))
            {
                bex = (BussinessException)ex;
                bex.ExceptionDetails = GetMessage(bex).Message;
            }
            else
            {
                bex = new BussinessException(0, ex);
            }

            ProcessBussinesException(bex);

        }

        private void ProcessBussinesException(BussinessException bex)
        {
            var today = DateTime.Now.ToString("yyyyMMdd_hh");
            var logName = PATH + today + "_" + "log.txt";

            var message = bex.ExceptionDetails + "\n" + bex.StackTrace + "\n";

            //if (bex.InnerException!=null)
            //    message += bex.InnerException.Message + "\n" + bex.InnerException.StackTrace;

            using (StreamWriter w = File.AppendText(logName))
            {
                Log(message, w);
            }

            bex.AppMessage = GetMessage(bex);

            throw bex;

        }

        public ApplicationMessage GetMessage(BussinessException bex)
        {

            var appMessage = new ApplicationMessage
            {
                Message = "Message not found!"
            };

            if (messages.ContainsKey(bex.ExceptionId))
                appMessage = messages[bex.ExceptionId];

            return appMessage;

        }

        private void LoadMessages()
        {
            messages.Add(1, new ApplicationMessage { Id = 1, Message = "Cliente no existe." });
            messages.Add(2, new ApplicationMessage { Id = 2, Message = "Cliente debe ser mayor de edad 18+." });
            messages.Add(3, new ApplicationMessage { Id = 3, Message = "Cliente ya existe en la base de datos." });
            messages.Add(4, new ApplicationMessage { Id = 4, Message = "Cuenta ya existe en la base de datos." });
            messages.Add(5, new ApplicationMessage { Id = 5, Message = "El saldo de la cuenta debe ser positivo." });
            messages.Add(6, new ApplicationMessage { Id = 6, Message = "El tipo de cuenta debe ser A o C." });
            messages.Add(7, new ApplicationMessage { Id = 7, Message = "Cuenta no existe." });
            messages.Add(8, new ApplicationMessage { Id = 8, Message = "Operación crediticia ya existe." });
            messages.Add(9, new ApplicationMessage { Id = 9, Message = "Operación crediticia no existe." });
            messages.Add(10, new ApplicationMessage { Id = 10, Message = "Dirección ya existe." });
            messages.Add(11, new ApplicationMessage { Id = 11, Message = "Dirección no existe." });
            messages.Add(12, new ApplicationMessage { Id = 12, Message = "Pago ya existe." });
            messages.Add(13, new ApplicationMessage { Id = 13, Message = "Pago no existe." });
            messages.Add(14, new ApplicationMessage { Id = 14, Message = "El monto del pago no puede mayor al saldo del crédito." });
            messages.Add(15, new ApplicationMessage { Id = 15, Message = "Fecha inválida. Hoy o el futuro?" });
            

        }

        private void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            w.WriteLine("  :");
            w.WriteLine("  :{0}", logMessage);
            w.WriteLine("-------------------------------");
        }

    }
}

