namespace Lykke.Common.Validation.NoSpecialCharacters
{
    internal class NoSpecialCharactersConfigurationBuilder : INoSpecialCharactersConfigurationExpression
    {
        private readonly NoSpecialCharactersConfiguration _configuration = new NoSpecialCharactersConfiguration();

        public void SetAllowed(params char[] chars)
        {
            _configuration.SetAllowed(chars);
        }

        public void SetRestricted(params char[] chars)
        {
            _configuration.SetRestricted(chars);
        }

        public INoSpecialCharactersConfiguration Build()
        {
            return _configuration;
        }
    }
}