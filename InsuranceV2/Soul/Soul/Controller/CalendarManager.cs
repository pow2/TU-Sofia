using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Appointments;
using Windows.UI.Xaml;
using Windows.Foundation;
using Windows.UI.Xaml.Media;

namespace Soul.Controller
{
    class CalendarManager
    {
        public static Rect GetElementRect(FrameworkElement element)
        {
            GeneralTransform buttonTransform = element.TransformToVisual(null);
            Point point = buttonTransform.TransformPoint(new Point());
            return new Rect(point, new Size(element.ActualWidth, element.ActualHeight));
        }

        public static async void CreateCalendarAppointmentAsync(string dtm, string office, object sender)
        {
            bool isCreated = false;
            var appointment = CreateAppointment(dtm, office);
            var rect = GetElementRect(sender as FrameworkElement);
            string appointmentId = await AppointmentManager.ShowAddAppointmentAsync(
                                   appointment, rect, Windows.UI.Popups.Placement.Default);
            if (!String.IsNullOrWhiteSpace(appointmentId))
            {
                isCreated = true;
            }
        }
        private static Appointment CreateAppointment(string dtm, string office)
        {
            var appointment = new Windows.ApplicationModel.Appointments.Appointment();
            // StartTime
            DateTime dt = DateTime.ParseExact(dtm, "yyyyMMddHHmmssfff", null);
            var date = dt.Date;
            var time = dt.TimeOfDay;
            var timeZoneOffset = TimeZoneInfo.Local.GetUtcOffset(DateTime.Now);
            var startTime = new DateTimeOffset(date.Year, date.Month, date.Day, time.Hours, time.Minutes, 0, timeZoneOffset);
            appointment.StartTime = startTime;

            // Subject
            appointment.Subject = "Запазен час в офис " + office;

            if (appointment.Subject.Length > 255)
            {
                appointment.Subject.Substring(0, 255);
            }

            // Location
            appointment.Location = office;

            if (appointment.Location.Length > 32768)
            {
                appointment.Location.Substring(0, 255);
            }

            appointment.Duration = TimeSpan.FromMinutes(30);
            appointment.Reminder = TimeSpan.FromHours(1);
            appointment.BusyStatus = Windows.ApplicationModel.Appointments.AppointmentBusyStatus.OutOfOffice;
            appointment.Sensitivity = Windows.ApplicationModel.Appointments.AppointmentSensitivity.Private;
           
            return appointment;
        }
    }
}
