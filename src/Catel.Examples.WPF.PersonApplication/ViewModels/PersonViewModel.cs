namespace Catel.Examples.PersonApplication.ViewModels
{
    using System;
    using System.Collections.Generic;
    using Data;
    using Models;
    using MVVM;

    public class PersonViewModel : FeaturedViewModelBase
    {
        public PersonViewModel(Person person, IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            if (Catel.CatelEnvironment.IsInDesignMode)
            {
                return; // This prevents constructor code from being executed at design-time
            }

            Person = person;
            GenerateData = new Command<object, object>(serviceProvider, OnGenerateDataExecute, OnGenerateDataCanExecute);
            ToggleCustomError = new Command<object>(serviceProvider, OnToggleCustomErrorExecute);

            Title = "Person";
        }

        protected override void ValidateFields(List<IFieldValidationResult> validationResults)
        {
            if (!string.IsNullOrEmpty(CustomError))
            {
                validationResults.Add(FieldValidationResult.CreateError(nameof(CustomError), CustomError));
            }
        }

        [Model]
        [Fody.Expose("FirstName")]
        [Fody.Expose("MiddleName")]
        public Person Person { get; private set; }

        [ViewModelToModel("Person")]
        public Gender Gender { get; set; }

        [ViewModelToModel("Person")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the custom error.
        /// </summary>
        public string CustomError { get; set; }

        public string CustomDefinedProperty
        {
            get { return "My Custom Defined Property"; }
        }

        public Command<object, object> GenerateData { get; private set; }

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

            if (!string.IsNullOrEmpty(LastName))
            {
                return false;
            }

            return true;
        }

        private void OnGenerateDataExecute(object parameter)
        {
            Gender = Gender.Male;
            SetValue("FirstName", "John");
            SetValue("MiddleName", "Mathew");
            LastName = "Smith";
        }

        public Command<object> ToggleCustomError { get; private set; }

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
    }

    //public class DesignPersonViewModel : PersonViewModel
    //{
    //    public DesignPersonViewModel(IServiceProvider serviceProvider)
    //        : base(null, serviceProvider)
    //    {
    //        // Direct manipulation on viewmodel's property bag. This a requirement if you intend to use Fody.Expose decorator
    //        SetValue("FirstName", "Geert");
    //        SetValue("MiddleName", "van");

    //        // Regular sample usage
    //        LastName = "Horrik";
    //        Gender = Gender.Male;
    //    }
    //}
}
