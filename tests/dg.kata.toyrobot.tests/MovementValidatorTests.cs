using dg.kata.toyrobot.Services;
using Xunit;

namespace dg.kata.toyrobot.tests
{
    public class MovementValidatorTests
    {
        [Theory]
        [InlineData(5,1,3)]
        [InlineData(5,3,2)]
        [InlineData(5,4,4)]
        [InlineData(10,9,0)]
        public void GivenCorrectXandY_AllowsMovement(int squareSize, int x, int y)
        {
            //Arrange
            var movementValidator = new MovementValidator(squareSize);
            
            //Act
            var canMove = movementValidator.CanMove(x, y);
            
            //Assert
            Assert.True(canMove);
        }
        
        [Theory]
        [InlineData(5,5,5)]
        [InlineData(5,5,4)]
        [InlineData(5,4,-1)]
        [InlineData(5,-1,-5)]
        [InlineData(10,10,-1)]
        public void GivenInCorrectXandY_DoesNotAllowMovement(int squareSize, int x, int y)
        {
            //Arrange
            var movementValidator = new MovementValidator(squareSize);
            
            //Act
            var canMove = movementValidator.CanMove(x, y);
            
            //Assert
            Assert.False(canMove);
        }
    }
}