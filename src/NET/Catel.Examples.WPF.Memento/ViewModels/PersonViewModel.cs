// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersonViewModel.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Catel.Examples.WPF.Memento.ViewModels
{
    using System.Collections.Generic;
    using Catel.Memento;
    using Data;
    using MVVM;
    using Models;

    /// <summary>
    /// Person view model.
    /// </summary>
    public class PersonViewModel : ViewModelBase
    {
        #region Variables
        #endregion

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonViewModel"/> class.
        /// </summary>
        /// <param name="person">The person.</param>
        public PersonViewModel(Person person)
        {
            Person = person ?? new Person();

            Undo = new Command(() => MementoService.Undo(), () => MementoService.CanUndo);
            Redo = new Command(() => MementoService.Redo(), () => MementoService.CanRedo);

            GenerateData = new Command<object, object>(OnGenerateDataExecute, OnGenerateDataCanExecute);
            ToggleCustomError = new Command<object>(OnToggleCustomErrorExecute);

            MementoService.RegisterObject(this);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title
        {
            get { return "Person"; }
        }

        /// <summary>
        /// Gets the memento service.
        /// </summary>
        private IMementoService MementoService
        {
            get { return GetService<IMementoService>(); }
        }

        #region Models
        /// <summary>
        /// Gets or sets the person model.
        /// </summary>
        [Model]
        [IgnoreMementoSupport]
        public Person Person
        {
            get { return GetValue<Person>(PersonProperty); }
            private set { SetValue(PersonProperty, value); }
        }

        /// <summary>
        /// Register the Person property so it is known in the class.
        /// </summary>
        public static readonly PropertyData PersonProperty = RegisterProperty("Person", typeof (Person));
        #endregion

        #region View model
        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        [ViewModelToModel("Person")]
        public Gender Gender
        {
            get { return GetValue<Gender>(GenderProperty); }
            set
            {
                MementoService.Add(new PropertyChangeUndo(this, "Gender", GetValue<string>(GenderProperty), value));
                SetValue(GenderProperty, value);
            }
        }

        /// <summary>
        /// Register the Gender property so it is known in the class.
        /// </summary>
        public static readonly PropertyData GenderProperty = RegisterProperty("Gender", typeof (Gender));

        /// <summary>Register the LastName property so it is known in the class.</summary>
        public static readonly PropertyData LastNameProperty = RegisterProperty("LastName", typeof (string));

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        [ViewModelToModel("Person")]
        public string LastName
        {
            get { return GetValue<string>(LastNameProperty); }
            set { SetValue(LastNameProperty, value); }
        }

        /// <summary>Register the MiddleName property so it is known in the class.</summary>
        public static readonly PropertyData MiddleNameProperty = RegisterProperty("MiddleName", typeof (string));

        /// <summary>
        /// Gets or sets the name of the middle.
        /// </summary>
        /// <value>
        /// The name of the middle.
        /// </value>
        [ViewModelToModel("Person")]
        public string MiddleName
        {
            get { return GetValue<string>(MiddleNameProperty); }
            set { SetValue(MiddleNameProperty, value); }
        }

        /// <summary>Register the FirstName property so it is known in the class.</summary>
        public static readonly PropertyData FirstNameProperty = RegisterProperty("FirstName", typeof (string));

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        [ViewModelToModel("Person")]
        public string FirstName
        {
            get { return GetValue<string>(FirstNameProperty); }
            set { SetValue(FirstNameProperty, value); }
        }

        /// <summary>
        /// Gets or sets the custom error.
        /// </summary>
        public string CustomError
        {
            get { return GetValue<string>(CustomErrorProperty); }
            set { SetValue(CustomErrorProperty, value); }
        }

        /// <summary>
        /// Register the CustomError property so it is known in the class.
        /// </summary>
        public static readonly PropertyData CustomErrorProperty = RegisterProperty("CustomError", typeof (string));

        /// <summary>
        /// Gets the custom defined property to test whether the ICustomTypeDescriptor for WPF works.
        /// </summary>
        public string CustomDefinedProperty
        {
            get { return "My Custom Defined Property"; }
        }
        #endregion

        #region Commands
        /// <summary>
        /// Gets the GenerateData command.
        /// </summary>
        public Command<object, object> GenerateData { get; private set; }

        /// <summary>
        /// Method to check whether the GenerateData command can be executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private bool OnGenerateDataCanExecute(object parameter)
        {
            // Note: normally you wouldn't use the ExposeAttribute if you need to access
            // the properties, but this is to show that all existing features (such as
            // INotifyPropertyChanged, IDataErrorInfo, etc also work with the ExposeAttribute).

            if (!string.IsNullOrEmpty(GetValue<string>("FirstName")))
            {
                return false;
            }

            if (!string.IsNullOrEmpty(GetValue<string>("MiddleName")))
            {
                return false;
            }

            if (!string.IsNullOrEmpty(GetValue<string>("LastName")))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Method to invoke when the GenerateData command is executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private void OnGenerateDataExecute(object parameter)
        {
            Gender = Gender.Male;
            SetValue("FirstName", "John");
            SetValue("MiddleName", "");
            SetValue("LastName", "Doe");
        }

        /// <summary>
        /// Gets the ToggleCustomError command.
        /// </summary>
        public Command<object> ToggleCustomError { get; private set; }

        /// <summary>
        /// Method to invoke when the ToggleCustomError command is executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private void OnToggleCustomErrorExecute(object parameter)
        {
            if (string.IsNullOrEmpty(CustomError))
            {
                CustomError = "Error message 1";
            }
            else if (CustomError == "Error message 1")
            {
                CustomError = "Replaced error message, does tooltip update?";
            }
            else
            {
                CustomError = string.Empty;
            }
        }

        /// <summary>
        /// Gets the undo.
        /// </summary>
        public Command Undo { get; private set; }

        /// <summary>
        /// Gets the redo.
        /// </summary>
        public Command Redo { get; private set; }
        #endregion

        #endregion

        #region Methods
        /// <summary>
        /// Validates the field values of this object. Override this method to enable
        /// validation of field values.
        /// </summary>
        /// <param name="validationResults">The validation results, add additional results to this list.</param>
        protected override void ValidateFields(List<IFieldValidationResult> validationResults)
        {
            if (!string.IsNullOrEmpty(CustomError))
            {
                validationResults.Add(FieldValidationResult.CreateError(CustomErrorProperty, CustomError));
            }
        }

        /// <summary>
        /// Called when the view model has just been closed.
        /// <para/>
        /// This method also raises the <see cref="E:Catel.MVVM.ViewModelBase.Closed"/> event.
        /// </summary>
        /// <param name="result">The result to pass to the view. This will, for example, be used as <c>DialogResult</c>.</param>
        protected override void OnClosed(bool? result)
        {
            MementoService.UnregisterObject(this);

            base.OnClosed(result);
        }
        #endregion
    }

    /// <summary>
    /// Design time version of the <see cref="PersonViewModel"/>.
    /// </summary>
    public class DesignPersonViewModel : PersonViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DesignPersonViewModel"/> class.
        /// </summary>
        public DesignPersonViewModel()
            : base(new Person {FirstName = "Geert", MiddleName = "van", LastName = "Horrik", Gender = Gender.Male})
        {
        }
    }
}