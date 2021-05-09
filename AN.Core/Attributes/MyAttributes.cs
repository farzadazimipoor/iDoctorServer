using AN.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace AN.Core.MyAttributes
{
    public class PosNumberNoZeroAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return false;
            }

            if (int.TryParse(value.ToString(), out var getal))
            {
                if (getal == 0)
                    return false;

                if (getal > 0)
                    return true;
            }
            return false;
        }
    }

    public class MorningFromAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return false;
            }
            var morningFrom = DateTime.Parse(value.ToString());

            if (!((morningFrom == Defaults.MorningStart || morningFrom > Defaults.MorningStart) && (morningFrom < Defaults.MorningEnd)))
            {
                return false;

            }

            return true;

        }
    }


    public class MorningToAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return false;
            }
            var morningTo = DateTime.Parse(value.ToString());

            if (!((morningTo == Defaults.MorningEnd || morningTo < Defaults.MorningEnd) && (morningTo > Defaults.MorningStart)))
            {
                return false;

            }

            return true;

        }
    }


    public class EveningFromAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return false;
            }
            var eveningFrom = DateTime.Parse(value.ToString());

            if (!((eveningFrom == Defaults.EveningStart || eveningFrom > Defaults.EveningStart) && (eveningFrom < Defaults.EveningEnd)))
            {
                return false;

            }

            return true;
        }
    }


    public class EveningToAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return false;
            }
            var eveningTo = DateTime.Parse(value.ToString());

            if (!((eveningTo == Defaults.EveningEnd || eveningTo < Defaults.EveningEnd) && (eveningTo > Defaults.EveningStart)))
            {
                return false;

            }

            return true;
        }
    }
}
