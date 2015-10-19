﻿using FakeItEasy;
using FluentTc.Domain;
using FluentTc.Locators;
using NUnit.Framework;

namespace FluentTc.Tests
{
    [TestFixture]
    public class AgentsRetrieverTests
    {
        [Test]
        [Ignore]
        public void GetAgents_All_GetFormatCalled() //todo
        {
            // Arrange
            var teamCityCaller = A.Fake<ITeamCityCaller>();
            A.CallTo(
                () =>
                    teamCityCaller.GetFormat<AgentWrapper>(
                        "/app/rest/agents?locator={0}",
                        A<object[]>._))
                .Returns(new AgentWrapper() { Count = "0" });

            var agentHavingBuilderFactory = A.Fake<IAgentHavingBuilderFactory>();
            A.CallTo(() => agentHavingBuilderFactory.CreateAgentHavingBuilder()).Returns(new AgentHavingBuilder());

            var agentsRetriever = new AgentsRetriever(teamCityCaller, agentHavingBuilderFactory);

            // Act
            var agents = agentsRetriever.GetAgents(_ => _.OnlyConnected());

            // Assert
            A.CallTo(
                () =>
                    teamCityCaller.GetFormat<AgentWrapper>(
                        "/app/rest/agents?locator={0}",
                        A<object[]>.That.IsSameSequenceAs(new object[] { })))
                .MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}