﻿namespace Objectivity.AutoFixture.XUnit2.Core.Tests.Providers
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using FluentAssertions;
    using global::AutoFixture;
    using global::AutoFixture.Xunit2;
    using Objectivity.AutoFixture.XUnit2.Core.Attributes;
    using Objectivity.AutoFixture.XUnit2.Core.Providers;
    using Xunit;

    [Collection("InlineAutoDataAttributeProvider")]
    [Trait("Category", "Providers")]
    public class InlineAutoDataAttributeProviderTests
    {
        [Theory(DisplayName = "GIVEN initialized fixture WHEN GetAttribute is invoked THEN attribute with specified fixture is returned")]
        [AutoData]
        [SuppressMessage("ReSharper", "PossibleNullReferenceException", Justification = "Assertion checks it earlier and throws exception.")]
        public void GivenInitializedFixture_WhenGetAttributeIsInvoked_ThenAttributeWithSpecifiedFixtureIsReturned(Fixture fixture)
        {
            // Arrange
            var provider = new InlineAutoDataAttributeProvider();

            // Act
            var dataAttribute = provider.GetAttribute(fixture) as CompositeDataAttribute;

            // Assert
            dataAttribute.Should().NotBeNull();
            dataAttribute.Attributes.FirstOrDefault(a => a is AutoDataAdapterAttribute).As<AutoDataAdapterAttribute>().AdaptedFixture.Should().Be(fixture);
        }
    }
}
