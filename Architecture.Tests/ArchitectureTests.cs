using FluentAssertions;
using NetArchTest.Rules;

namespace Architecture.Tests
{
    public class ArchitectureTests
    {

        private const string DomainNamespace = "Clean.Domain";
        private const string ApplicationNamespace = "Clean.Application";
        private const string DataNamespace = "Clean.Data";
        private const string SharedNamespace = "Clean.Shared";
        private const string WebApiNamespace = "Clean.WebApi";

        [Fact]
        public void Domain_Should_Not_HaveDependencyOnOtherProjects()
        {
            // Arrange
            var assembly = typeof(Clean.Domain.AssemblyReference).Assembly;

            var otherProjects = new[] { 
                ApplicationNamespace, 
                DataNamespace, 
                SharedNamespace, 
                WebApiNamespace 
            };

            // Act
            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            // Assert
            testResult.IsSuccessful.Should().BeTrue();

        }

        [Fact]
        public void Application_Should_Not_HaveDependencyOnOtherProjects()
        {
            // Arrange
            var assembly = typeof(Clean.Application.AssemblyReference).Assembly;

            var otherProjects = new[] {
                DataNamespace,
                SharedNamespace,
                WebApiNamespace
            };

            // Act
            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            // Assert
            testResult.IsSuccessful.Should().BeTrue();

        }

        [Fact]
        public void Infrastructure_Should_Not_HaveDependencyOnOtherProjects()
        {
            // Arrange
            var assemblies = new[]
            {
                typeof(Clean.Data.AssemblyReference).Assembly,
                typeof(Clean.Shared.AssemblyReference).Assembly
            };

            // Act
            var testResult = Types
                .InAssemblies(assemblies)
                .ShouldNot()
                .HaveDependencyOn(WebApiNamespace)
                .GetResult();

            // Assert
            testResult.IsSuccessful.Should().BeTrue();

        }

        [Fact]
        public void Presentation_Should_Not_HaveDependencyOnOtherProjects()
        {
            // Arrange
            var assembly = typeof(Clean.WebApi.AssemblyReference).Assembly;

            var otherProjects = new[]
            {
                DataNamespace,
                SharedNamespace
            };

            // Act
            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            // Assert
            testResult.IsSuccessful.Should().BeTrue();

        }
    }
}