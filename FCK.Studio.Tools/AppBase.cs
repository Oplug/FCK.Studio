using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FCK.Studio.Tools
{
    public class AppBase
    {
        public static BirthdayAgeSex GetBirthdayAgeSex(string identityCard)
        {
            if (string.IsNullOrEmpty(identityCard))
            {
                return null;
            }
            else
            {
                if (identityCard.Length != 15 && identityCard.Length != 18)//身份证号码只能为15位或18位其它不合法
                {
                    return null;
                }
            }

            BirthdayAgeSex entity = new BirthdayAgeSex();
            string strSex = string.Empty;
            if (identityCard.Length == 18)//处理18位的身份证号码从号码中得到生日和性别代码
            {
                entity.Birthday = identityCard.Substring(6, 4) + "-" + identityCard.Substring(10, 2) + "-" + identityCard.Substring(12, 2);
                strSex = identityCard.Substring(14, 3);
            }
            if (identityCard.Length == 15)
            {
                entity.Birthday = "19" + identityCard.Substring(6, 2) + "-" + identityCard.Substring(8, 2) + "-" + identityCard.Substring(10, 2);
                strSex = identityCard.Substring(12, 3);
            }

            entity.Age = CalculateAge(entity.Birthday);
            if (int.Parse(strSex) % 2 == 0)
            {
                entity.Sex = "女";
            }
            else
            {
                entity.Sex = "男";
            }
            return entity;
        }
        /// <summary>
        /// 根据出生日期，计算精确的年龄
        /// </summary>
        /// <param name="birthDate">生日</param>
        /// <returns></returns>
        public static int CalculateAge(string birthDay)
        {
            DateTime birthDate = DateTime.Parse(birthDay);
            DateTime nowDateTime = DateTime.Now;
            int age = nowDateTime.Year - birthDate.Year;
            if (nowDateTime.Month < birthDate.Month || (nowDateTime.Month == birthDate.Month && nowDateTime.Day < birthDate.Day))
            {
                age--;
            }
            return age;
        }
        public static int CInt(object val)
        {
            try
            {
                return Convert.ToInt32(val);
            }
            catch
            {
                return 0;
            }
        }
        public static string GetRndCode(int length)
        {
            var result = new System.Text.StringBuilder();
            for (var i = 0; i < length; i++)
            {
                var r = new Random(Guid.NewGuid().GetHashCode());
                result.Append(r.Next(0, 10));
            }
            return result.ToString();
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            var tb = new DataTable(typeof(T).Name);

            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in props)
            {
                Type t = GetCoreType(prop.PropertyType);
                tb.Columns.Add(prop.Name, t);
            }

            foreach (T item in items)
            {
                var values = new object[props.Length];

                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }

                tb.Rows.Add(values);
            }

            return tb;
        }

        /// <summary>
        /// Determine of specified type is nullable
        /// </summary>
        public static bool IsNullable(Type t)
        {
            return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        /// <summary>
        /// Return underlying type if type is Nullable otherwise return the type
        /// </summary>
        public static Type GetCoreType(Type t)
        {
            if (t != null && IsNullable(t))
            {
                if (!t.IsValueType)
                {
                    return t;
                }
                else
                {
                    return Nullable.GetUnderlyingType(t);
                }
            }
            else
            {
                return t;
            }
        }
    }
    public class BirthdayAgeSex
    {
        public string Birthday { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
    }
}
