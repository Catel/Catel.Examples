// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShoppingListItem.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.WP8.ShoppingList.Data
{
    using System.Collections.Generic;
    using Catel.Data;

    /// <summary>
    /// ShoppingListItem Data object class which fully supports serialization, property changed notifications,
    /// backwards compatibility and error checking.
    /// </summary>
    public class ShoppingListItem : SavableModelBase<ShoppingListItem>, IShoppingListItem
    {
        #region Variables
        #endregion

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new object from scratch.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="quantity">The quantity.</param>
        public ShoppingListItem(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        /// <summary>
        /// Initializes a new object from scratch.
        /// </summary>
        public ShoppingListItem()
        {
        }
        #endregion

        #region Constants
        /// <summary>
        /// Register the Checked property so it is known in the class.
        /// </summary>
        public static readonly PropertyData CheckedProperty = RegisterProperty("Checked", typeof (bool), false);

        /// <summary>
        /// Register the Name property so it is known in the class.
        /// </summary>
        public static readonly PropertyData NameProperty = RegisterProperty("Name", typeof (string), string.Empty);

        /// <summary>
        /// Register the Quantity property so it is known in the class.
        /// </summary>
        public static readonly PropertyData QuantityProperty = RegisterProperty("Quantity", typeof (int), 1);
        #endregion

        #region IShoppingListItem Members
        /// <summary>
        /// Gets or sets whether the resource is gathered.
        /// </summary>
        public bool Checked
        {
            get { return GetValue<bool>(CheckedProperty); }
            set { SetValue(CheckedProperty, value); }
        }

        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        public int Quantity
        {
            get { return GetValue<int>(QuantityProperty); }
            set { SetValue(QuantityProperty, value); }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Validates the field values of this object. Override this method to enable
        /// validation of field values.
        /// </summary>
        /// <param name="validationResults">The validation results, add additional results to this list.</param>
        protected override void ValidateFields(List<IFieldValidationResult> validationResults)
        {
            if (string.IsNullOrEmpty(Name))
            {
                validationResults.Add(FieldValidationResult.CreateError(NameProperty, "Name is required"));
            }

            if (Quantity < 1)
            {
                validationResults.Add(FieldValidationResult.CreateError(QuantityProperty, "Quantity must at least be 1"));
            }
        }
        #endregion
    }
}