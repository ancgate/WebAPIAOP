using System.ComponentModel;
using System.Text;

namespace WebApiAOP.Common
{
    /// <summary>
    /// This class overrides all method a class come with (ToString, Equal...)
    /// </summary>
    public class ClassProperty
    {
        /// <summary>
        /// obtain all property values of your class and combine them into a single string
        /// </summary>
        /// <returns>The property values combined in single string</returns>
        public override string ToString()
        {
            PropertyDescriptorCollection coll = TypeDescriptor.GetProperties(this);
            StringBuilder builder = new StringBuilder();
            foreach (PropertyDescriptor pd in coll)
            {
                if (pd.GetValue(this) != null)
                {
                    builder.Append($"{pd.Name} : {pd.GetValue(this)} - ");
                    //builder.Append($"{pd.Name} : {pd.GetValue(this) ?? ""} - ");
                }
                else
                {
                    const string noValue = "No Value";
                    builder.Append($"{pd.Name} : {noValue} - ");
                }
            }
            return builder.ToString();
        }
    }
}