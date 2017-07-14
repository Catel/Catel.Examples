namespace Catel.Examples.WPF.Authentication
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
        /// <summary>
        /// Gets or sets the role the user is currently in.
        /// </summary>
        /// <value>The role.</value>
        public string Role { get; set; }

        public bool CanCommandBeExecuted(ICatelCommand command, object commandParameter)
        {
            return true;
        }

        public bool HasAccessToUIElement(FrameworkElement element, object tag, object authenticationTag)
        {
            var authenticationTagAsString = authenticationTag as string;
            if (authenticationTagAsString != null)
            {
                if (string.Compare(authenticationTagAsString, Role, true) == 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
