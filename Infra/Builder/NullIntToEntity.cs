using System;
using Omu.ProDinner.Core.Model;
using Omu.ProDinner.Core.Repository;
using Omu.ValueInjecter;

namespace Omu.ProDinner.Infra.Builder
{
    public class NullIntToEntity : LoopValueInjection
    {
        protected override bool TypesMatch(Type sourceType, Type targetType)
        {
            return sourceType == typeof(int?) && targetType.IsSubclassOf(typeof(Entity));
        }

        protected override object SetValue(object sourcePropertyValue)
        {
            if (sourcePropertyValue == null) return null;
            var id = ((int?) sourcePropertyValue).Value;

            dynamic repo = IoC.Resolve(typeof(IRepo<>).MakeGenericType(TargetPropType));

            return repo.Get(id);
        }
    }
}