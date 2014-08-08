// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DepartmentsViewModel.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Catel.Examples.WPF.Prism.Modules.Departments.ViewModels
{
    using Catel.Messaging;
    using Catel.Services;
    using Collections;
    using Data;
    using MVVM;
    using Services;
    using Models;
    using Services;
    using Catel.IoC;
    using ViewModelBase = Prism.ViewModels.ViewModelBase;

    /// <summary>
    /// Departments view model.
    /// </summary>
    public class DepartmentsViewModel : ViewModelBase
    {
        private readonly IUIVisualizerService _uiVisualizerService;

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentsViewModel"/> class. 
        /// </summary>
        public DepartmentsViewModel(IMessageMediator messageMediator, IDepartmentRepository departmentRepository, IUIVisualizerService uiVisualizerService)
            : base(messageMediator)
        {
            _uiVisualizerService = uiVisualizerService;

            Departments = new FastObservableCollection<IDepartment>(departmentRepository.GetAllDepartments());
            if (Departments.Count > 0)
            {
                SelectedDepartment = Departments[0];
            }

            Select = new Command(OnSelectExecute);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title
        {
            get { return "Departments"; }
        }

        /// <summary>Register the IsNotificationVisible property so it is known in the class.</summary>
        public static readonly PropertyData IsNotificationVisibleProperty = RegisterProperty("IsNotificationVisible", typeof (bool), default(bool), (s, e) => ((DepartmentsViewModel) s).OnIsNotificationVisibleChanged(e));

        /// <summary>
        /// Gets or sets a value indicating whether IsNotificationVisible.
        /// </summary>
        public bool IsNotificationVisible
        {
            get { return GetValue<bool>(IsNotificationVisibleProperty); }
            set { SetValue(IsNotificationVisibleProperty, value); }
        }

        /// <summary>
        /// Occurs when the value of the IsNotificationVisible property is changed.
        /// </summary>
        /// <param name="e">
        /// The event argument
        /// </param>
        private void OnIsNotificationVisibleChanged(AdvancedPropertyChangedEventArgs e)
        {
            if ((bool) e.NewValue)
            {
                if (_notificationBarViewModel == null)
                {
                    var typeFactory = TypeFactory.Default;
                    _notificationBarViewModel = typeFactory.CreateInstance<NotificationBarViewModel>();
                    _uiVisualizerService.Activate(_notificationBarViewModel, "NotificationRegion");
                }
                else
                {
                    _uiVisualizerService.Activate(_notificationBarViewModel);
                }
            }
            else
            {
                _uiVisualizerService.Deactivate(_notificationBarViewModel);
            }
        }

        /// <summary>
        /// Gets or sets the departments.
        /// </summary>
        public FastObservableCollection<IDepartment> Departments
        {
            get { return GetValue<FastObservableCollection<IDepartment>>(DepartmentsProperty); }
            set { SetValue(DepartmentsProperty, value); }
        }

        /// <summary>
        /// Register the Departments property so it is known in the class.
        /// </summary>
        public static readonly PropertyData DepartmentsProperty = RegisterProperty("Departments", typeof (FastObservableCollection<IDepartment>));

        /// <summary>
        /// Gets or sets the selected department.
        /// </summary>
        public IDepartment SelectedDepartment
        {
            get { return GetValue<IDepartment>(SelectedDepartmentProperty); }
            set { SetValue(SelectedDepartmentProperty, value); }
        }

        /// <summary>
        /// Register the SelectedDepartment property so it is known in the class.
        /// </summary>
        public static readonly PropertyData SelectedDepartmentProperty = RegisterProperty("SelectedDepartment", typeof (IDepartment), null, (sender, e) =>
            {
                var departmentTracker = Catel.IoC.ServiceLocator.Default.ResolveType<IDepartmentTracker>();
                departmentTracker.CurrentDepartment = e.NewValue as IDepartment;
            });

        private NotificationBarViewModel _notificationBarViewModel;
        #endregion

        #region Commands
        /// <summary>
        /// Gets the Select command.
        /// </summary>
        public Command Select { get; private set; }

        /// <summary>
        /// Gets DisplayNotificationsCommand.
        /// </summary>
        public Command DisplayNotificationsCommand { get; private set; }

        /// <summary>
        /// Method to invoke when the Select command is executed.
        /// </summary>
        private void OnSelectExecute()
        {
            if (ObjectHelper.IsNull(SelectedDepartment))
            {
                return;
            }

            MessageMediator.SendMessage(SelectedDepartment.Name, "UpdateEmployees");
            MessageMediator.SendMessage(SelectedDepartment, "UpdateSelectedDepartmentFromDM");
        }
        #endregion
    }
}