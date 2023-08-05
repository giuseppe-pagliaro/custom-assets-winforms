namespace HermoItemManagers
{
    internal interface IFieldsFormBuilder
    {
        /// <summary>
        /// Sets all the props at once.
        /// </summary>
        /// <param name="newProps">The new values for the props.</param>
        void SetProps(params Object[] newProps);

        /// <summary>
        /// Puts all the controls in the form and/or changes any form properties.
        /// </summary>
        /// <param name="fieldsForm">The FieldsForm to populate.</param>
        void Populate(FieldsForm fieldsForm);

        /// <summary>
        /// Called whenever the Style prop is changed. It's used to synchronize the new style with all the form's controls.
        /// </summary>
        void ApplyStyle(FieldsForm fieldsForm);

        /// <summary>
        /// Called whenever the Action Button is clicked.
        /// </summary>
        void BtnClickedAction(FieldsForm fieldsForm);
    }
}