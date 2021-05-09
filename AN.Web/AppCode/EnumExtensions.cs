using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AN.Web.App_Code
{
    public static class MyEnumExtensions
    {
        public static string GetDisplayName<T>(this T inputObject)
        {
            var genericEnumType = inputObject.GetType();
            var memberInfo = genericEnumType.GetMember(inputObject.ToString());
            if ((memberInfo != null && memberInfo.Length > 0))
            {
                var attribs = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);
                if ((attribs != null && attribs.Count() > 0))
                {
                    return ((DisplayAttribute)attribs.ElementAt(0)).GetName();
                }
            }
            return inputObject.ToString().ToLower();
        }

        public static IEnumerable<SelectListItem> EnumToSelectList<T>(bool addSelectAll = false, string selectAllText = "Select All", string selectAllValue = "0")
        {
            var list = (Enum.GetValues(typeof(T)).Cast<T>()
                .Select(e => new SelectListItem()
                {
                    Text = ((DisplayAttribute)e.GetType().GetField(e.ToString()).GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault()) != null ?
                        ((DisplayAttribute)e.GetType().GetField(e.ToString()).GetCustomAttributes(typeof(DisplayAttribute), false).First()).GetName() :
                        e.ToString(),
                    Value = ((int)Convert.ChangeType(e, TypeCode.Int32)).ToString()
                }))
                .ToList();

            if (addSelectAll)
            {
                list.Insert(0, new SelectListItem() { Value = selectAllValue, Text = selectAllText });
            }

            return list;
        }

        public static IEnumerable<SelectListItem> EnumToSelectList<T>(T Exclude)
        {
            var list = (Enum.GetValues(typeof(T)).Cast<T>()
                .Where(p => (Convert.ToInt32(p) & Convert.ToInt32(Exclude)) == 0)
                .Select(e => new SelectListItem()
                {
                    Text = ((DisplayAttribute)e.GetType().GetField(e.ToString()).GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault()) != null ?
                        ((DisplayAttribute)e.GetType().GetField(e.ToString()).GetCustomAttributes(typeof(DisplayAttribute), false).First()).GetName() :
                        e.ToString(),
                    Value = ((int)Convert.ChangeType(e, TypeCode.Int32)).ToString()
                }))
                .ToList();

            return list;
        }

        public static TEnum AllFlags<TEnum>() where TEnum : struct
        {
            Type enumType = typeof(TEnum);
            int newValue = 0;
            var enumValues = Enum.GetValues(enumType);
            foreach (var value in enumValues)
            {
                int v = (int)Convert.ChangeType(value, TypeCode.Int32);
                newValue |= v;
            }

            return (TEnum)Enum.ToObject(enumType, newValue);
        }

        public static TEnum AllFlags<TEnum>(TEnum Exclude) where TEnum : struct
        {
            Type enumType = typeof(TEnum);
            int newValue = 0;
            var enumValues = Enum.GetValues(enumType);
            foreach (var value in enumValues)
            {
                if ((Convert.ToInt32(value) & Convert.ToInt32(Exclude)) != 0)
                {
                    continue;
                }
                int v = (int)Convert.ChangeType(value, TypeCode.Int32);
                newValue |= v;
            }

            return (TEnum)Enum.ToObject(enumType, newValue);
        }

        public static List<string> GetFieldErros(this string key, ModelStateDictionary modelState)
        {
            var result = modelState.Keys.Where(k => k == key).Select(k => modelState[k].Errors).First().Select(e => e.ErrorMessage).ToList();
            return result;
        }
    }
}