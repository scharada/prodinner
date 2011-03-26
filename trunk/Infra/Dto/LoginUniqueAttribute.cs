using System;
using System.ComponentModel.DataAnnotations;
using Omu.ProDinner.Core.Service;

namespace Omu.ProDinner.Infra.Dto
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class LoginUniqueAttribute : ValidationAttribute
    {
        private static readonly string DefaultErrorMessage = "login unique";//MUI.login_unique;

        public LoginUniqueAttribute()
            : base(DefaultErrorMessage)
        {
        }

        public override string FormatErrorMessage(string name)
        {
            return DefaultErrorMessage;
        }

        public override bool IsValid(object value)
        {
            if (string.IsNullOrEmpty((string)value)) return true;
            return IoC.Resolve<IUserService>().IsUnique((string)value);
        }
    }
}