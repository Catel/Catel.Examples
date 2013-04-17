namespace Catel.Examples.WPF.Prism.Modules.Departments.ViewModels
{
    using Data;
    using Prism.ViewModels;

    /// <summary>
    /// UserControl view model.
    /// </summary>
    public class NotificationBarViewModel : ViewModelBase
    {
        #region Properties
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title
        {
            get { return "Departments"; }
        }

        /// <summary>
        /// Gets or sets the property value.
        /// </summary>
        public string EventMessage
        {
            get { return GetValue<string>(EventMessageProperty); }
            set { SetValue(EventMessageProperty, value); }
        }

        /// <summary>
        /// Register the EventMessage property so it is known in the class.
        /// </summary>
        public static readonly PropertyData EventMessageProperty = RegisterProperty("EventMessage", typeof (string));
        #endregion

        #region Methods
        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationBarViewModel"/> class.
        /// </summary>
        public NotificationBarViewModel()
        {
            MessageMediator.Register<string>(this, data =>
                {
                    if (ObjectHelper.IsNull(data))
                        return;

                    try
                    {
                        EventMessage = data;
                    }
                    catch
                    {
                    }
                }, "UpdateNotification");
        }
        #endregion
    }
}