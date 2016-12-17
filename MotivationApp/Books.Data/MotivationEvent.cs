using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Data
{
    public enum NotificationType
    {
        Sound,
        Visual
    }
    public class MotivationEvent
    {
        public int MotivationEventID { get; set; }
        public string Name { get; set; }
        public DateTime DateDue { get; set; }
        public string Description { get; set; }
        public List<NotificationType> NotificationTypes { get; set; }
        public string Place { get; set; }
        public int RepeatSeconds { get; set; }

        public bool SoundRemind { get; set; }
        public bool VisualRemind { get; set; }

        public DateTime LastRemind { get; set; }


        public MotivationEvent(string name, DateTime date, string description, List<NotificationType> notificationTypes, string place, int repeat)
        {
            Name = name;
            DateDue = date;
            Description = description;
            Place = place;
            RepeatSeconds = repeat;

            SoundRemind = false;
            VisualRemind = false;

            LastRemind = DateTime.Now;
            if (notificationTypes.Contains(NotificationType.Sound))
                SoundRemind = true;
            if (notificationTypes.Contains(NotificationType.Visual))
                VisualRemind = true;
        }

        public MotivationEvent() { }

        public string DateTimeFormatted
        {
            get { return DateDue.ToString("dd.MM.yyyy"); }
        }

        public int DaysLeft
        {
            get
            {
                if (DateTime.Now > DateDue) return 0;
                return (int)(DateDue - DateTime.Now).TotalDays;
            }
        }
    }
}
