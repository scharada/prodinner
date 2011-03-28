using System.Linq;
using Omu.ValueInjecter;

namespace Omu.ProDinner.Service
{
    public class Same : ConventionInjection
    {
        private readonly string[] ignores;

        public Same(params string[] ignores)
        {
            this.ignores = ignores;
        }

        protected override bool Match(ConventionInfo c)
        {
            return c.SourceProp.Name == c.TargetProp.Name && c.SourceProp.Type == c.TargetProp.Type
                   && !ignores.Contains(c.SourceProp.Name);
        }
    }
}