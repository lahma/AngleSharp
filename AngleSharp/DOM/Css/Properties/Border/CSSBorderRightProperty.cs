﻿namespace AngleSharp.DOM.Css
{
    using AngleSharp.Css;
    using AngleSharp.Extensions;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// More information available at:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/border-right
    /// </summary>
    sealed class CSSBorderRightProperty : CSSShorthandProperty, ICssBorderProperty
    {
        #region Fields

        readonly CSSBorderRightColorProperty _color;
        readonly CSSBorderRightStyleProperty _style;
        readonly CSSBorderRightWidthProperty _width;

        #endregion

        #region ctor

        internal CSSBorderRightProperty(CSSStyleDeclaration rule)
            : base(PropertyNames.BorderRight, rule, PropertyFlags.Animatable)
        {
            _color = Get<CSSBorderRightColorProperty>();
            _style = Get<CSSBorderRightStyleProperty>();
            _width = Get<CSSBorderRightWidthProperty>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the width of the given border property.
        /// </summary>
        public Length Width
        {
            get { return _width.Width; }
        }

        /// <summary>
        /// Gets the color of the given border property.
        /// </summary>
        public Color Color
        {
            get { return _color.Color; }
        }

        /// <summary>
        /// Gets the style of the given border property.
        /// </summary>
        public LineStyle Style
        {
            get { return _style.Style; }
        }

        #endregion

        #region Methods

        protected override Boolean IsValid(CSSValue value)
        {
            return this.ValidateBorderPart().TryConvert(value, m =>
            {
                _width.SetWidth(m.Item1);
                _style.SetStyle(m.Item2);
                _color.SetColor(m.Item3);
            });
        }

        internal override String SerializeValue(IEnumerable<CSSProperty> properties)
        {
            if (!IsComplete(properties))
                return String.Empty;

            return String.Format("{0} {1} {2}", _width.SerializeValue(), _color.SerializeValue(), _style.SerializeValue());
        }

        #endregion
    }
}