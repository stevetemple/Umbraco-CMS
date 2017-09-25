﻿using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models.PublishedContent;

namespace Umbraco.Core.PropertyEditors.ValueConverters
{
    [DefaultPropertyValueConverter]
    public class CheckboxListValueConverter : PropertyValueConverterBase
    {
        private static readonly char[] Comma = { ',' };

        public override bool IsConverter(PublishedPropertyType propertyType)
            => propertyType.PropertyEditorAlias.InvariantEquals(Constants.PropertyEditors.CheckBoxListAlias);

        public override Type GetPropertyValueType(PublishedPropertyType propertyType)
            => typeof (IEnumerable<string>);

        public override PropertyCacheLevel GetPropertyCacheLevel(PublishedPropertyType propertyType)
            => PropertyCacheLevel.Content;

        public override object ConvertInterToObject(IPublishedElement owner, PublishedPropertyType propertyType, PropertyCacheLevel cacheLevel, object source, bool preview)
        {
            var sourceString = source?.ToString() ?? string.Empty;

            if (string.IsNullOrEmpty(sourceString))
                return Enumerable.Empty<string>();

            return sourceString.Split(Comma, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim());
        }
    }
}