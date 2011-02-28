using System;
using System.Collections.Generic;
using Omu.ProDinner.Core.Model;
using Omu.ProDinner.Core.Repository;
using Omu.ValueInjecter;

namespace Omu.ProDinner.Infra.Builder
{
    public class IntsToEntities : LoopValueInjection
    {
        protected override bool TypesMatch(Type s, Type t)
        {
            if (!s.IsGenericType || !t.IsGenericType
                || s.GetGenericTypeDefinition() != typeof(IEnumerable<>)
                || t.GetGenericTypeDefinition() != typeof(IEnumerable<>)) return false;

            return s.GetGenericArguments()[0] == (typeof(int))
                   && (t.GetGenericArguments()[0].IsSubclassOf(typeof(Entity)));
        }

        protected override object SetValue(object v)
        {
            if (v == null) return null;

            dynamic repo = IoC.Resolve(typeof(IRepo<>).MakeGenericType(TargetPropType.GetGenericArguments()[0]));
            dynamic list = Activator.CreateInstance(typeof (List<>).MakeGenericType(TargetPropType.GetGenericArguments()[0]));

            foreach (var i in (v as IEnumerable<int>))
                list.Add(repo.Get(i));
            return list;
        }
    }
}