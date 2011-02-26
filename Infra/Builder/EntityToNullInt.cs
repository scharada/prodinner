using System;
using Omu.AwesomeDemo.Core.Model;
using Omu.ValueInjecter;

namespace Omu.AwesomeDemo.Infra.Builder
{
    public class EntityToNullInt : LoopValueInjection
    {
        protected override bool TypesMatch(Type sourceType, Type targetType)
        {
            return sourceType.IsSubclassOf(typeof (Entity)) && targetType == typeof (int?);
        }

        protected override object SetValue(object o)
        {
            if (o == null) return null;
            return (o as Entity).Id;
        }
    }
}