
using Mediator.Abstractions.Requests;
using ProjectTemplate.Domain.Models.Aggregates;

namespace ProjectTemplate.Application.Commands.Features.TestFeature
{
    public class TestCommand : Command<Test>
    {
        public TestCommand(int number)
        {
            Number = number;
        }

        public int Number { get; }
    }
}
