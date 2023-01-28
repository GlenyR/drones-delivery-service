using DroneApp.Domain.DomainServices.Contracts;
using DroneApp.Domain.DomainServices;
using Xunit;

namespace DroneApp.Tests.DomainServices
{
    public class InstructionsServiceTests
    {
        private IInstructionService _instructionService;

        public InstructionsServiceTests()
        {
            _instructionService = new InstructionService();
        }

        [Fact]
        public void ShouldGetInstructionObjects()
        {

            //Arrange
            var instructionString = "[DroneA], [200], [DroneB], [250], [DroneC],[100] \n [LocationA],[200] \n [LocationB],[150] \n [LocationC],[50]";


            //Act
            var result = _instructionService.ParseInstruction(instructionString);

            //Assert
            Assert.Equal(3, result.Item1.Count);
            Assert.Equal(3, result.Item2.Count);
        }
    }
}
