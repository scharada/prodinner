using System;
using System.Collections.Generic;
using System.Linq;
using Omu.ProDinner.Core.Model;
using Omu.ValueInjecter;

namespace Omu.ProDinner.Infra.Builder
{
    public class EntitiesToInts : LoopValueInjection
    {
        protected override bool TypesMatch(Type s, Type t)
        {
            if (!s.IsGenericType || !t.IsGenericType
                || s.GetGenericTypeDefinition() != typeof(IEnumerable<>)
                || t.GetGenericTypeDefinition() != typeof(IEnumerable<>)) return false;

            return t.GetGenericArguments()[0] == (typeof(int))
                   && (s.GetGenericArguments()[0].IsSubclassOf(typeof(Entity)));
        }

        protected override object SetValue(object v)
        {
            return v == null ? null : (v as IEnumerable<Entity>).Select(o => o.Id);
        }
    }
}