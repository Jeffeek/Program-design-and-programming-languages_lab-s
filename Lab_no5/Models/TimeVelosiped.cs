﻿using System;
using Lab_no5.Exceptions;

namespace Lab_no5.Models
{
    class TimeVelosiped
    {
        private int _hours;
        private int _minutes;
        private int _seconds;
        private DateTime _timeCorrection;

        public TimeVelosiped()
        {
            _timeCorrection = new DateTime(2020,10,5,0,0,0);
        }

        public TimeVelosiped(int hours, int minutes, int seconds)
        {
            SetTime(hours, minutes, seconds);
            _timeCorrection = new DateTime(2020,10,5,0,0,0);
            _timeCorrection = _timeCorrection.AddHours(Hours);
            _timeCorrection = _timeCorrection.AddMinutes(Minutes);
            _timeCorrection = _timeCorrection.AddSeconds(Seconds);
        }

        public override string ToString()
        {
            return $"{Hours}:{Minutes}:{Seconds}";
        }

        public int Hours
        {
            get => _hours;
            set
            {
                if (value > 23 || value < 0)
                {
                    _hours = value / 23;
                    throw new TimeHourException();
                }
                else
                {
                    _hours = value;
                }
                    
                
                _timeCorrection = new DateTime(2020, 10, 5, Hours, Minutes, Seconds);
            }
        }

        public void AddSeconds(int seconds)
        {
            _timeCorrection = _timeCorrection.AddSeconds(seconds);
            Seconds = _timeCorrection.Second;
            Minutes = _timeCorrection.Minute;
            Hours = _timeCorrection.Hour;
        }

        public void AddMinutes(int minutes)
        {
            _timeCorrection = _timeCorrection.AddMinutes(minutes);
            Minutes = _timeCorrection.Minute;
            Hours = _timeCorrection.Hour;
        }

        public void AddHours(int hours)
        {
            _timeCorrection = _timeCorrection.AddHours(hours);
            Hours = _timeCorrection.Hour;
        }

        public int Minutes
        {
            get => _minutes;
            set
            {
                if (value > 59 || value < 0)
                {
                    _minutes = value % 59;
                    throw new TimeMinuteException();
                }
                else
                {
                    _minutes = value;
                }
                    
                
                _timeCorrection = new DateTime(2020, 10, 5, Hours, Minutes, Seconds);
            }
        }

        public int Seconds
        {
            get => _seconds;
            set
            {
                if (value > 59 || value < 0)
                {
                    _seconds = value % 59;
                    throw new TimeSecondException();
                }
                else
                {
                    _seconds = value;
                }
                _timeCorrection = new DateTime(2020, 10, 5, Hours, Minutes, Seconds);
            }
        }



        public void SetTime(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }
    }
}
