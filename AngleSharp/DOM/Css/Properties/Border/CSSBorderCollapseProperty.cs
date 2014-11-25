﻿namespace AngleSharp.DOM.Css
{
    using AngleSharp.Css;
    using AngleSharp.Extensions;
    using System;

    /// <summary>
    /// Information can be found on MDN:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/border-collapse
    /// </summary>
    sealed class CSSBorderCollapseProperty : CSSProperty, ICssBorderCollapseProperty
    {
        #region Fields

        Boolean _separate;

        #endregion

        #region ctor

        internal CSSBorderCollapseProperty(CSSStyleDeclaration rule)
            : base(PropertyNames.BorderCollapse, rule, PropertyFlags.Inherited)
        {
            Reset();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the use of the separated-border table rendering model.
        /// Otherwise the collapsed-border table rendering model is used.
        /// </summary>
        public Boolean IsSeparated
        {
            get { return _separate; }
        }

        #endregion

        #region Methods

        public void SetSeparated(Boolean separate)
        {
            _separate = separate;
        }

        internal override void Reset()
        {
            _separate = true;
        }

        /// <summary>
        /// Determines if the given value represents a valid state of this property.
        /// </summary>
        /// <param name="value">The state that should be used.</param>
        /// <returns>True if the state is valid, otherwise false.</returns>
        protected override Boolean IsValid(CSSValue value)
        {
            return this.TakeOne(Keywords.Separate, true).Or(this.TakeOne(Keywords.Collapse, false)).TryConvert(value, SetSeparated);
        }

        #endregion
    }
}