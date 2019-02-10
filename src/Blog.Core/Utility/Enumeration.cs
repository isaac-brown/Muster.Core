﻿// <copyright file="Enumeration.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Blog.Core.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// A base class that is used to create type safe enums. From https://lostechies.com/jimmybogard/2008/08/12/enumeration-classes/.
    /// </summary>
    public abstract class Enumeration : IComparable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Enumeration"/> class.
        /// </summary>
        protected Enumeration()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Enumeration"/> class
        /// using the given <paramref name="keyCode"/> and <paramref name="displayName"/>.
        /// </summary>
        /// <param name="keyCode">Shorthand identifier for the enumeration.</param>
        /// <param name="displayName">Longer more descriptive identifier for the enumeration, should be suitable for end users.</param>
        protected Enumeration(string keyCode, string displayName)
        {
            this.KeyCode = keyCode;
            this.DisplayName = displayName;
        }

        /// <summary>
        /// Gets the key code for this enumeration.
        /// </summary>
        public string KeyCode { get; }

        /// <summary>
        /// Gets the display name for this enumeration.
        /// </summary>
        public string DisplayName { get; }

        /// <summary>
        /// Checks if two <see cref="Enumeration"/>s are equivalent.
        /// </summary>
        /// <param name="obj1">The first <see cref="Enumeration"/> to compare.</param>
        /// <param name="obj2">The second <see cref="Enumeration"/> to compare.</param>
        /// <returns>true if the given <see cref="Enumeration"/>s are equivalent, otherwise false.</returns>
        public static bool operator ==(Enumeration obj1, Enumeration obj2)
        {
            return obj1.Equals(obj2);
        }

        /// <summary>
        /// Checks if two <see cref="Enumeration"/>s are not equivalent.
        /// </summary>
        /// <param name="obj1">The first <see cref="Enumeration"/> to compare.</param>
        /// <param name="obj2">The second <see cref="Enumeration"/> to compare.</param>
        /// <returns>true if the given <see cref="Enumeration"/>s are not equivalent, otherwise false.</returns>
        public static bool operator !=(Enumeration obj1, Enumeration obj2)
        {
            return !obj1.Equals(obj2);
        }

        /// <summary>
        /// Gets all <see cref="Enumeration"/>s of the given type.
        /// </summary>
        /// <typeparam name="T">A super type of <see cref="Enumeration"/>.</typeparam>
        /// <returns>All <see cref="Enumeration"/>s of the given type.</returns>
        public static IEnumerable<T> GetAll<T>()
            where T : Enumeration, new()
        {
            var type = typeof(T);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            foreach (var info in fields)
            {
                var instance = new T();

                if (info.GetValue(instance) is T locatedValue)
                {
                    yield return locatedValue;
                }
            }
        }

        /// <summary>
        /// Creates an <see cref="Enumeration"/> of the given type from the specified <paramref name="keyCode"/>'.
        /// </summary>
        /// <typeparam name="T">A super type of <see cref="Enumeration"/>.</typeparam>
        /// <param name="keyCode">The value to construct the <see cref="Enumeration"/> from.</param>
        /// <returns>An <see cref="Enumeration"/> of the given type.</returns>
        public static T FromKeyCode<T>(string keyCode)
            where T : Enumeration, new()
        {
            var matchingItem = Parse<T, string>(keyCode, "value", item => item.KeyCode == keyCode);
            return matchingItem;
        }

        /// <summary>
        /// asdjk
        /// </summary>
        /// <typeparam name="T">a</typeparam>
        /// <param name="displayName">asd</param>
        /// <returns>asds</returns>
        public static T FromDisplayName<T>(string displayName)
            where T : Enumeration, new()
        {
            var matchingItem = Parse<T, string>(displayName, "display name", item => item.DisplayName == displayName);
            return matchingItem;
        }

        /// <inheritdoc/>
        public override string ToString() => this.DisplayName;

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            var otherValue = obj as Enumeration;
            bool otherValueIsEnumeration = otherValue is Enumeration;

            if (!otherValueIsEnumeration)
            {
                return false;
            }

            var typeMatches = this.GetType().Equals(obj.GetType());
            var valueMatches = this.KeyCode.Equals(otherValue.KeyCode);

            return typeMatches && valueMatches;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.KeyCode.GetHashCode();
        }

        /// <inheritdoc/>
        public int CompareTo(object other)
        {
            return this.KeyCode.CompareTo(((Enumeration)other).KeyCode);
        }

        private static T Parse<T, K>(K value, string description, Func<T, bool> predicate)
            where T : Enumeration, new()
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);

            if (matchingItem == null)
            {
                var message = string.Format("'{0}' is not a valid {1} in {2}", value, description, typeof(T));
                throw new ApplicationException(message);
            }

            return matchingItem;
        }
    }
}