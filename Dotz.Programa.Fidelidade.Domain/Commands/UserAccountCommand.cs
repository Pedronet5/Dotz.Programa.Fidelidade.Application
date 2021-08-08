using Dotz.Programa.Fidelidade.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using FluentValidator;
using System.Globalization;

namespace Dotz.Programa.Fidelidade.Domain.Commands
{
    public class UserAccountCommand : Notifiable, ICommand
    {
        public string Email { get; set; }

        private ValidationResult ValidationResult { get; set; }

        [System.Obsolete]
        public bool IsValid()
        {
            ValidationResult = new DigitalAccountValidation().Validate(this);

            foreach (var Error in this.ValidationResult.Errors)
                AddNotification(Error.PropertyName, Error.ErrorMessage);

            return ValidationResult.IsValid;
        }
    }

    public class DigitalAccountValidation : AbstractValidator<UserAccountCommand>
    {
        [System.Obsolete]
        public DigitalAccountValidation()
        {
            ValidatorOptions.LanguageManager.Culture = new CultureInfo("en");

            RuleFor(c => c.Email).EmailAddress();
        }
    }
}
