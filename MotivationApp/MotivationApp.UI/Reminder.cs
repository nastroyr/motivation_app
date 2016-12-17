using Books.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace MotivationApp.UI
{
    public delegate void QuoteUpdate(MotivationQuote Quote);
    public delegate void BookUpdate(Book Book);
    public delegate void ImagePopUp(MotivationImage Image);
    public delegate void EventNotification(MotivationEvent Event);

    public class Reminder
    {

        public QuoteUpdate OnQuoteUpdate { get; set; }
        public BookUpdate OnBookUpdate { get; set; }
        public ImagePopUp OnImagePopUp { get; set; }
        public EventNotification OnEventNotification { get; set; }

        DispatcherTimer _timer;
        Request _request;
        DateTime _reminderStart;
        DateTime _lastQuoteUpdate;
        DateTime _lastBookUpdate;
        DateTime _lastImagePopUp;
        int _quoteInterval;
        int _bookInterval;
        int _imageInterval;

        private bool isFirstLaunch;

        const double TickInterval = 500;    //ms
        const double Delay = 2000;          //ms

        public Reminder()
        {
            _request = new Request();
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(TickInterval);
            _timer.Tick += Tick;
        }

        private void _Start()
        {
            if (_timer.IsEnabled)
            {
                _timer.Stop();
            }
            InitLastTimes();
            LoadIntervals();
            _reminderStart = DateTime.Now;
            isFirstLaunch = true;
            _timer.Start();
        }

        public void Start()
        {
            _Start();
        }

        public void Restart()
        {
            _Start();
        }

        public void Stop()
        {
            if (_timer.IsEnabled)
            {
                _timer.Stop();
            }
        }

        private void Tick(object sender, EventArgs e)
        {
            if (DateTime.Now - _lastQuoteUpdate > TimeSpan.FromSeconds(_quoteInterval) || isFirstLaunch)
            {
                MotivationQuote q = _request.RandomQuote();
                if (q != null)
                {
                    OnQuoteUpdate(q);
                    _lastQuoteUpdate = DateTime.Now;
                }
            }
            if (DateTime.Now - _lastBookUpdate > TimeSpan.FromSeconds(_bookInterval) || isFirstLaunch)
            {
                Book b = _request.RandomBook();
                if (b != null)
                {
                    OnBookUpdate(b);
                    _lastBookUpdate = DateTime.Now;
                }
            }
            if (DateTime.Now - _lastImagePopUp > TimeSpan.FromSeconds(_imageInterval) && DateTime.Now - _reminderStart > TimeSpan.FromMilliseconds(Delay))
            {
                MotivationImage i = _request.RandomMotivationImage();
                if (i != null)
                {
                    OnImagePopUp(i);
                    _lastImagePopUp = DateTime.Now;
                }
            }
            isFirstLaunch = false;

            List<MotivationEvent> events = _request.GetEventsToShow();
            if (events.Count > 0)
            {
                foreach (MotivationEvent ev in events)
                {
                    if (ev != null)
                    {
                        OnEventNotification(ev);
                        ev.LastRemind = DateTime.Now;
                    }
                }
                _request.ClearOldEvents();
            }
        }

        private void InitLastTimes()
        {
            _lastQuoteUpdate = DateTime.Now;
            _lastBookUpdate = DateTime.Now;
            _lastImagePopUp = DateTime.Now;
        }

        private void LoadIntervals()
        {
            _quoteInterval = Properties.Settings.Default.QuoteInterval;
            _bookInterval = Properties.Settings.Default.BookInterval;
            _imageInterval = Properties.Settings.Default.ImageInterval;
        }
    }
}
