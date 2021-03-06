using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CSharpBasic.Transcript
{
    public static class TranscriptExtension
    {
        public static string Print(this Transcript transcript)
        {
            return PrintObject(transcript);
        }

        public static void Merge(this Transcript me, Transcript other)
        {
            if(other.Chinese != null)
            {
                me.Chinese = other.Chinese;
            }
            if(other.English != null)
            {
                me.English = other.English;
            }
            if(other.Math != null)
            {
                me.Math = other.Math;
            }
        }

        public static Transcript Clone(this Transcript t)
        {
            return new Transcript
                       {
                           Name = t.Name,
                           Chinese = t.Chinese,
                           Math = t.Math,
                           English = t.English
                       };
        }
        
        public static string Print(this Grade grade)
        {
            return PrintObject(grade);
        }

        private static string PrintObject<T>(T t)
        {
            var properties = typeof (T).GetProperties().
                Where(property => null != property.GetValue(t, null) && ExistsDisplayAttribute(property)).
                Select(property => string.Format("{0}: {1}", property.Name, property.GetValue(t, null))).
                ToList();
            return string.Join(", ", properties);
        }

        private static bool ExistsDisplayAttribute(PropertyInfo propertyInfo)
        {
            var customAttributes = propertyInfo.GetCustomAttributes(false);
            return customAttributes.OfType<DisplayAttribute>().Any();
        }
    }
}