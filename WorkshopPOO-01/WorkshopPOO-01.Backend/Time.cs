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
        public Time() : this(0, 0, 0, 0) 
        {
            
        }
        public Time(int hour) : this(hour, 0, 0, 0) 
        {
            
        }
        public Time(int hour, int minute) : this(hour, minute, 0, 0) 
        {
            
        }
        public Time(int hour, int minute, int second) : this(hour, minute, second, 0) 
        {
            
        }
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

        public long ToMillisseconds()
        {
            const long MillisecondsPerHour = 3600000;
            const long MillisecondsPerMinute = 60000;
            const long MillisecondsPerSecond = 1000;

            return _hour * MillisecondsPerHour +
                   _minute * MillisecondsPerMinute +
                   _second * MillisecondsPerSecond +
                   _millisecond;
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
            const long MillisecondsPerDay = 24 * 60 * 60 * 1000;
            return this.ToMillisseconds() + other.ToMillisseconds() >= MillisecondsPerDay;
        }

        public Time Add(Time other)
        {
            const long MillisecondsPerHour = 3600000;
            const long MillisecondsPerMinute = 60000;
            const long MillisecondsPerSecond = 1000;
            const int HoursPerDay = 24;

            long totalMs = this.ToMillisseconds() + other.ToMillisseconds();
            long remainingMs = totalMs;

            int newHour = (int)((remainingMs / MillisecondsPerHour) % HoursPerDay);
            remainingMs %= MillisecondsPerHour;

            int newMinute = (int)(remainingMs / MillisecondsPerMinute);
            remainingMs %= MillisecondsPerMinute;

            int newSecond = (int)(remainingMs / MillisecondsPerSecond);
            int newMillisecond = (int)(remainingMs % MillisecondsPerSecond);

            return new Time(newHour, newMinute, newSecond, newMillisecond);
        }

        public override string ToString()
        {
            string suffix = _hour < 12 ? "AM" : "PM";
            int hour12 = _hour % 12;
            if (hour12 == 0) hour12 = 12;

            return $"{hour12:D2}:{_minute:D2}:{_second:D2}.{_millisecond:D3} {suffix}";
        }

        private int ValidateHour(int hour)
        {
            if (hour < 0 || hour > 23)
                throw new ArgumentOutOfRangeException(nameof(hour),
                    $"The hour: {hour}, is not valid.");
            return hour;
        }

        private int ValidateMinute(int minute)
        {
            if (minute < 0 || minute > 59)
                throw new ArgumentOutOfRangeException(nameof(minute),
                    $"The minute: {minute}, is not valid.");
            return minute;
        }

        private int ValidateSecond(int second)
        {
            if (second < 0 || second > 59)
                throw new ArgumentOutOfRangeException(nameof(second),
                    $"The second: {second}, is not valid.");
            return second;
        }

        private int ValidateMillisecond(int millisecond)
        {
            if (millisecond < 0 || millisecond > 999)
                throw new ArgumentOutOfRangeException(nameof(millisecond),
                    $"The millisecond: {millisecond}, is not valid.");
            return millisecond;
        }