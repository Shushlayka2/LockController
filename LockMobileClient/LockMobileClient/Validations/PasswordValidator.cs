namespace LockMobileClient.Validations
{
    class PasswordValidator : IValidationRule<string>
    {
        public bool Validate(string value)
        {
            return value?.Length == 5;
        }
    }
}
