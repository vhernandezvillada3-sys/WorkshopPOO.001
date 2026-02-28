using System;

namespace WorkshopPOO_01.Backend
{
    public class Time
    {
        // Fields
        private int _hour;
        private int _minute;
        private int _second;
        private int _millisecond;

        // Constructors
        public Time() : this(0, 0, 0, 0) { }
        public Time(int hour) : this(hour, 0, 0, 0) { }
        public Time(int hour, int minute) : this(hour, minute, 0, 0) { }
        public Time(int hour, int minute, int second) : this(hour, minute, second, 0) { }
        public Time(int hour, int minute, int second, int millisecond)
        {
            _hour = ValidateHour(hour);
            _minute = ValidateMinute(minute);
            _second = ValidateSecond(second);
            _millisecond = ValidateMillisecond(millisecond);
        }

        // Properties
        public int Hour
        {
            get => _hour;
            set => _hour = ValidateHour(value);
        }

        public int Minute
        {
            get => _minute;
            set => _minute = ValidateMinute(value);
        }

        public int Second
        {
            get => _second;
            set => _second = ValidateSecond(value);
        }

        public int Millisecond
        {
            get => _millisecond;
            set => _millisecond = ValidateMillisecond(value);
        }

        // Methods
        public long ToMilliseconds()
        {
            return _hour * 3600000L + _minute * 60000L + _second * 1000L + _millisecond;
        }

        public int ToSeconds()
        {
            return _hour * 3600 + _minute * 60 + _second;
        }

        public int ToMinutes()
        {
            return _hour * 60 + _minute;
        }

        public bool IsOtherDay(Time other)
        {
            return ToMilliseconds() + other.ToMilliseconds() >= 86400000;
        }

        public Time Add(Time other)
        {
            long totalMs = ToMilliseconds() + other.ToMilliseconds();

            int newHour = (int)((totalMs / 3600000) % 24);
            totalMs %= 3600000;

            int newMinute = (int)(totalMs / 60000);
            totalMs %= 60000;

            int newSecond = (int)(totalMs / 1000);
            int newMillisecond = (int)(totalMs % 1000);

            return new Time(newHour, newMinute, newSecond, newMillisecond);
        }

        public override string ToString()
        {
            string amPm = _hour < 12 ? "AM" : "PM";
            int hour12 = _hour % 12;
            if (hour12 == 0) hour12 = 12;

            return $"{hour12:D2}:{_minute:D2}:{_second:D2}.{_millisecond:D3} {amPm}";
        }

        // Validation Methods
        private int ValidateHour(int hour)
        {
            if (hour < 0 || hour > 23)
                throw new ArgumentOutOfRangeException(nameof(hour), "Las horas deben estar entre 0 y 23");
            return hour;
        }

        private int ValidateMinute(int minute)
        {
            if (minute < 0 || minute > 59)
                throw new ArgumentOutOfRangeException(nameof(minute), "Los minutos deben estar entre 0 y 59");
            return minute;
        }

        private int ValidateSecond(int second)
        {
            if (second < 0 || second > 59)
                throw new ArgumentOutOfRangeException(nameof(second), "Los segundos deben estar entre 0 y 59");
            return second;
        }

        private int ValidateMillisecond(int millisecond)
        {
            if (millisecond < 0 || millisecond > 999)
                throw new ArgumentOutOfRangeException(nameof(millisecond), "Los milisegundos deben estar entre 0 y 999");
            return millisecond;
        }
    }
}