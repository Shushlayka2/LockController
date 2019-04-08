using LockMobileClient.Validations;
using System;

namespace LockMobileClient.Models
{
    public class ValidatablePassword : ValidatableObject<string>
    {
        public ValidatablePassword(Action propertyChangedCallback = null, params IValidationRule<string>[] validations)
            : base(propertyChangedCallback, validations)
        {
        }

        protected override void OnValueChanged()
        {
            var valueLength = Value.Length;

            // password has only 5 digits
            if (valueLength > 5)
            {
                Value = Value.Remove(valueLength - 1);
            }
            base.OnValueChanged();
        }
    }
}
