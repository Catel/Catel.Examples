namespace Catel.Examples.Authentication
{
    using System.Windows;
    using MVVM;

    /// <summary>
    /// Example implementation of the <see cref="AuthenticationProvider"/>. This class is not really implemented
    /// like it should, because it shouldn't be this easy to set the current role. However, for the sake of simplicity,
    /// this class has a simple property with the role of the user.
    /// </summary>
    public class AuthenticationProvider : IAuthenticationProvider
    {
        #region Properties
        public string Role { get; set; }
        #endregion

        #region IAuthenticationProvider Members
        public bool CanCommandBeExecuted(ICatelCommand command, object commandParameter)
        {
            return true;
        }

        public bool HasAccessToUIElement(FrameworkElement element, object tag, object authenticationTag)
        {
            var authenticationTagAsString = authenticationTag as string;
            if (authenticationTagAsString is not null)
            {
                if (authenticationTagAsString.EqualsIgnoreCase(Role))
                {
                    return true;
                }
            }

            return false;
        }
        #endregion
    }
}