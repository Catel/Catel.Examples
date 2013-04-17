namespace Catel.Examples.WPF.Prism.Services
{
    using Catel.Services;
    using Messaging;
    using Models;

    /// <summary>
    /// Keeps track of the department info.
    /// </summary>
    public class DepartmentTracker : ServiceBase, IDepartmentTracker
    {
        private IDepartment _currentDepartment;

        public IDepartment CurrentDepartment
        {
            get { return _currentDepartment; }
            set 
            { 
                _currentDepartment = value;

                var messageMediator = GetService<IMessageMediator>();
                messageMediator.SendMessage(CurrentDepartment, "CurrentDepartmentChanged");
            }
        }
    }
}