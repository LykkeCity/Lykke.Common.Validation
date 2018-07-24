using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Lykke.Common.Validation.NoSpecialCharacters
{
    internal class NoSpecialCharactersConfiguration : INoSpecialCharactersConfiguration
    {
        public ImmutableHashSet<char> AllowedChars { get; private set; }

        public ImmutableHashSet<char> RestrictedChars { get; private set; }

        public bool IsNullAllowed { get; private set; }

        public bool IsEmptyAllowed { get; private set; }

        public NoSpecialCharactersConfiguration()
        {
            AllowedChars = ImmutableHashSet.Create<char>();
            RestrictedChars = ImmutableHashSet.Create<char>();
            IsNullAllowed = false;
            IsEmptyAllowed = false;
        }

        internal void SetAllowed(params char[] chars)
        {
            CheckForIntersect(chars, RestrictedChars);
            AllowedChars = CreateSet(chars);
        }

        internal void SetRestricted(params char[] chars)
        {
            CheckForIntersect(chars, AllowedChars);
            RestrictedChars = CreateSet(chars);
        }

        internal void AllowNull()
        {
            IsNullAllowed = true;
        }

        internal void AllowEmpty()
        {
            IsEmptyAllowed = true;
        }

        private void CheckForIntersect(IEnumerable<char> one, IEnumerable<char> two)
        {
            if (one != null && two != null &&
                one.Intersect(two).Any())
                throw new ArgumentException(
                    $"{nameof(AllowedChars)} should not contain characters from {nameof(RestrictedChars)}!");
        }

        private static ImmutableHashSet<char> CreateSet(params char[] chars)
        {
            return chars == null
                ? ImmutableHashSet.Create<char>()
                : ImmutableHashSet.Create(chars);
        }
    }
}