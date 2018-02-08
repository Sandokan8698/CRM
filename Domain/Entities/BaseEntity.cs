using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;

namespace Domain.Entities
{
    public partial class BaseEntity<T> where T : class
    {
    }

    public partial class BaseEntity<T> : IDataErrorInfo where T : class
    {

        string IDataErrorInfo.Error
        {
            get
            {
                if (!AllowValidation) return null;
                return string.Empty;
                
            }
        }
        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                if (!AllowValidation) return null;
                return IDataErrorInfoHelper.GetErrorText(this, columnName);
            }
        }

        [NotMapped]
        public bool AllowValidation { get; set; }
        

        public bool IsValid
        {
            get
            {
                AllowValidation = true;
                Error = "";

                PropertyInfo[] properties = typeof(T).GetProperties();
                foreach (PropertyInfo property in properties)
                {
                  Error += string.IsNullOrEmpty(((IDataErrorInfo)this)[property.Name]) ? "" : ((IDataErrorInfo)this)[property.Name] + Environment.NewLine;
                }
                
                if (!string.IsNullOrEmpty(Error))
                {
                    return false;
                }
                return true;
            }
        }

        [NotMapped]
        public String Error { get; private set; }
    }

}
   

