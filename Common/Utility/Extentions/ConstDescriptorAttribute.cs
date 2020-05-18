using System;
using System.Reflection;

namespace Consulting.Common.Utility.Extentions
{
    public class ConstDescriptorAttribute : Attribute
    {
        public string Description { get; private set; }
        public ConstDescriptorAttribute(string description)
        {
            Description = description;
        }
    }

    public static class GetFieldDescription
    {
        public static string GetFieldDescByName(Type T, string fieldName)
        {
            string constDesc = T.GetField(fieldName).GetCustomAttribute<ConstDescriptorAttribute>().Description;
            return constDesc;
        }
        public static string GetFieldDescByValue(Type T, object val)
        {
            FieldInfo[] field_infos = T.GetFields();
            string fieldDesc = string.Empty;
            foreach (FieldInfo info in field_infos)
            {
                var fieldValue = info.GetValue(null);
                if ((int)fieldValue == (int)val)
                {
                    fieldDesc = info.GetCustomAttribute<ConstDescriptorAttribute>().Description;
                    break;
                }
            }
            return fieldDesc;
        }

    }

  

}



