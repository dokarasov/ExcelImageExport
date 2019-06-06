using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace ExcelImageExport.Features
{
    public static class EnumHelper<T>
    {
        public static IList<T> GetValues(Enum value)
        {
            return value.GetType()
                .GetFields(BindingFlags.Static | BindingFlags.Public)
                .Select(fi => (T) Enum.Parse(value.GetType(), fi.Name, false))
                .ToList();
        }

        public static T Parse(string value)
        {
            return (T) Enum.Parse(typeof(T), value, true);
        }

        public static IEnumerable<string> GetNames(Enum value)
        {
            return value.GetType().GetFields(BindingFlags.Static | BindingFlags.Public).Select(fi => fi.Name).ToList();
        }

        public static IList<string> GetDisplayValues(Enum value)
        {
            return GetNames(value).Select(obj => GetDisplayValue(Parse(obj))).ToList();
        }

        private static string LookupResource(IReflect resourceManagerProvider, string resourceKey)
        {
            var properties = resourceManagerProvider.GetProperties(BindingFlags.Static |
                                                                   BindingFlags.NonPublic |
                                                                   BindingFlags.Public);
            foreach (var staticProperty in properties)
            {
                if (staticProperty.PropertyType != typeof(System.Resources.ResourceManager)) continue;

                var resourceManager = (System.Resources.ResourceManager) staticProperty.GetValue(null, null);
                return resourceManager.GetString(resourceKey);
            }

            return resourceKey; // Fallback with the key name
        }

        public static string GetDisplayValue(T value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            var descriptionAttributes = fieldInfo.GetCustomAttributes(
                typeof(DisplayAttribute), false) as DisplayAttribute[];

            if (descriptionAttributes != null && descriptionAttributes[0].ResourceType != null)
                return LookupResource(descriptionAttributes[0].ResourceType, descriptionAttributes[0].Name);

            if (descriptionAttributes == null) return string.Empty;
            return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Name : value.ToString();
        }
    }
}