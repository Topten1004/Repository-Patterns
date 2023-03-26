using System;
using System.Collections.Generic;
using System.Text;
using ProjectTemplate.Domain.Interfaces;
using ProjectTemplate.Domain.Models.Aggregates;

namespace ProjectTemplate.Domain.Models.Events
{
    public class TestDomainEvent : IDomainEvent
    {
        public TestDomainEvent(int number, ProjectAggregate projectAggregate)
        {
            ProjectAggregate = projectAggregate;
            Number = number;
        }

        public int Number { get; set; }

        public ProjectAggregate ProjectAggregate { get; set; }
    }
}
