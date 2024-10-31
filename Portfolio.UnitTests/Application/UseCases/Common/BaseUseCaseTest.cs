using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.UnitTests.Application.UseCases.Common
{
    public class BaseUseCaseTest
    {
        public Faker Faker {  get; set; }

        protected BaseUseCaseTest() => Faker = new Faker();
    }
}
