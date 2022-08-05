using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Config
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum GenericEnum)
        {
            if (GenericEnum == null)
                return null;

            Type genericEnumType = GenericEnum.GetType();
            MemberInfo[] _menberInfo = genericEnumType.GetMember(GenericEnum.ToString());
            if((_menberInfo != null) && (_menberInfo.Length > 0))
            {
                var _atributes = _menberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                if ((_atributes != null) && (_atributes.Count() > 0))
                {
                    return ((System.ComponentModel.DescriptionAttribute)_atributes.ElementAt(0)).Description;
                }
            }
            return GenericEnum.ToString(); 
        }
    }
}
