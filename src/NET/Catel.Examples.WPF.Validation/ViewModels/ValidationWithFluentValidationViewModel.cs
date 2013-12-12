// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidationWithFluentValidationViewModel.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Catel.Examples.WPF.Validation.ViewModels
{
    using Catel.IoC;
    using Data;
    using MVVM;
    using MVVM.Services;
    using Models;

    /// <summary>
    /// ValidationInIValidator view model.
    /// </summary>
    public class ValidationWithFluentValidationViewModel : ViewModelBase
    {
        private readonly IMessageService _messageService;

        #region Variables
        #endregion

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationInIValidatorViewModel" /> class.
        /// </summary>
        /// <param name="messageService">The message service.</param>
        /// <param name="person">The person.</param>
        /// <param name="deferValidationUntilFirstSave">if set to <c>true</c> [defer validation until first save].</param>
        public ValidationWithFluentValidationViewModel(ModelWithoutValidation person, bool deferValidationUntilFirstSave, IMessageService messageService)
        {
            Argument.IsNotNull(() => messageService);

            _messageService = messageService;

            if (person == null)
            {
                person = new ModelWithoutValidation();
            }

            Person = person;
            DeferValidationUntilFirstSaveCall = deferValidationUntilFirstSave;
            CheckCommand = CommandHelper.CreateCommand(CheckCommandExecute, () => PersonValidationSummary);
        }
        #endregion

        #region Properties
        /// <summary>
        /// You can retreive the validation summary with the tags
        /// </summary>
        [ValidationToViewModel(IncludeChildViewModels = false, Tag = "Person", UseTagToFilter = true)]
        private IValidationSummary PersonValidationSummary { get; set; }

        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title
        {
            get { return "Validation with Fluent Validation Extension"; }
        }

        /// <summary>
        /// Gets the person model.
        /// </summary>
        [Model]
        public ModelWithoutValidation Person
        {
            get { return GetValue<ModelWithoutValidation>(PersonProperty); }
            private set { SetValue(PersonProperty, value); }
        }

        /// <summary>
        /// Register the Person property so it is known in the class.
        /// </summary>
        public static readonly PropertyData PersonProperty = RegisterProperty("Person", typeof (ModelWithoutValidation));

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        [ViewModelToModel("Person")]
        [DisplayName("First Name")]
        public string FirstName
        {
            get { return GetValue<string>(FirstNameProperty); }
            set { SetValue(FirstNameProperty, value); }
        }

        /// <summary>
        /// Register the FirstName property so it is known in the class.
        /// </summary>
        public static readonly PropertyData FirstNameProperty = RegisterProperty("FirstName", typeof (string));

        /// <summary>
        /// Gets or sets the middle name.
        /// </summary>
        [ViewModelToModel("Person")]
        [DisplayName("Middle Name")]
        public string MiddleName
        {
            get { return GetValue<string>(MiddleNameProperty); }
            set { SetValue(MiddleNameProperty, value); }
        }

        /// <summary>
        /// Register the MiddleName property so it is known in the class.
        /// </summary>
        public static readonly PropertyData MiddleNameProperty = RegisterProperty("MiddleName", typeof (string));

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        [ViewModelToModel("Person")]
        [DisplayName("Last Name")]
        public string LastName
        {
            get { return GetValue<string>(LastNameProperty); }
            set { SetValue(LastNameProperty, value); }
        }

        /// <summary>
        /// Register the LastName property so it is known in the class.
        /// </summary>
        public static readonly PropertyData LastNameProperty = RegisterProperty("LastName", typeof (string));
        #endregion

        #region Commands
        public Command CheckCommand { get; private set; }

        private void CheckCommandExecute()
        {
            _messageService.Show("This button was enabled with the auto hook command feature");
        }
        #endregion
    }
}