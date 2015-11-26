using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnumHumanizedType.NH
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class EnumHumanizedType<T> : NHibernate.Type.EnumStringType where T : struct, IComparable, IFormattable
    {
        public EnumHumanizedType() : base(typeof(T)) { }

        public override object GetValue(object instance)
        {
            var toDb = (((T)instance) as Enum).Humanize();
            return toDb;
        }

        public override object GetInstance(object fromDb)
        {
            var instance = fromDb.ToString().DehumanizeTo<T>();
            return instance;
        }
    }
}
