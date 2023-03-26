using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTemplate.Application.Commands.Features.TestFeature
{
    public class TestCommandException : Exception
    {
        public TestCommandException() : base("Test exception")
        {
        }
    }
}
