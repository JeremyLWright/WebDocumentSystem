﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using System.ComponentModel;

namespace WebDocumentSystem.Document
{
    public static class QueryStringHelpers
    {
        public static T GetValue<T>(this NameValueCollection collection, string key)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }

            var value = collection[key];

            if (value == null)
            {
                throw new ArgumentOutOfRangeException("key");
            }

            var converter = TypeDescriptor.GetConverter(typeof(T));

            if (!converter.CanConvertFrom(typeof(string)))
            {
                throw new ArgumentException(String.Format("Cannot convert '{0}' to {1}", value, typeof(T)));
            }

            return (T)converter.ConvertFrom(value);
        }
    }
}