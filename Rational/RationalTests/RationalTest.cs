using RationalLw;
using Xunit;

namespace RationalTests
{
    public class RationalTest
    {
        [Fact]
        public void RationalCreate_DefaultConstr_DefaultRation()
        {
            var ration = new Rational();

            Assert.Equal( 0 , ration.GetNumerator());
            Assert.Equal( 1 , ration.GetDenominator());
        }

        [Fact]
        public void RationalCreate_CreateByInt_RationWithDenominat1()
        {
            var ration = new Rational(5);

            Assert.Equal( 5, ration.GetNumerator() );
            Assert.Equal( 1, ration.GetDenominator() );
        }

        [Fact]
        public void RationalCreate_CreateByInt0_RationWithDenominat1()
        {
            var ration = new Rational( 0 );

            Assert.Equal( 0, ration.GetNumerator() );
            Assert.Equal( 1, ration.GetDenominator() );
        }

        [Fact]
        public void RationalCreate_CreateByTwoInt_Ration()
        {
            var ration = new Rational( 1, 2 );

            Assert.Equal( 1, ration.GetNumerator() );
            Assert.Equal( 2, ration.GetDenominator() );
        }

        [Fact]
        public void RationalCreate_CreateByTwoIntDenomIs0_ZeroRation()
        {
            var ration = new Rational( 1, 0 );

            Assert.Equal( 0, ration.GetNumerator() );
            Assert.Equal( 1, ration.GetDenominator() );
        }

        [Fact]
        public void UnarPlus_GetPlust_ThisRational()
        {
            //Arrange
            var ration = new Rational( 1, 2 );

            //Act
            var newRation = +ration;

            //Assert
            Assert.Equal( 1, newRation.GetNumerator() );
            Assert.Equal( 2, newRation.GetDenominator() );
        }

        [Fact]
        public void UnarMinus_GetPositive_ThisRationalWithMinus()
        {
            //Arrange
            var ration = new Rational( -1, 2 );

            //Act
            var newRation = -ration;

            //Assert
            Assert.Equal( 1, newRation.GetNumerator() );
            Assert.Equal( 2, newRation.GetDenominator() );
        }

        [Fact]
        public void UnarMinus_GetNonPositive_ThisNonPositiveRational()
        {
            //Arrange
            var ration = new Rational( 1, 2 );

            //Act
            var newRation = -ration;

            //Assert
            Assert.Equal( -1, newRation.GetNumerator() );
            Assert.Equal( 2, newRation.GetDenominator() );
        }

        [Fact]
        public void BinaryPlus_PlusTwoRationals_Rational()
        {
            //Arrange
            var ration1 = new Rational( 1, 2 );
            var ration2 = new Rational( 3, 4 );

            //Act
            var newRation = ration1 + ration2;

            //Assert
            Assert.Equal( 5, newRation.GetNumerator() );
            Assert.Equal( 4, newRation.GetDenominator() );
        }

        [Fact]
        public void BinaryPlus_RationalPlusInt_Rational()
        {
            //Arrange
            var ration1 = new Rational( 1, 2 );

            //Act
            var newRation = ration1 + 2;

            //Assert
            Assert.Equal( 5, newRation.GetNumerator() );
            Assert.Equal( 2, newRation.GetDenominator() );
        }

        [Fact]
        public void BinaryPlus_IntPlusRational_Rational()
        {
            //Arrange
            var ration1 = new Rational( 1, 2 );

            //Act
            var newRation = 2 + ration1;

            //Assert
            Assert.Equal( 5, newRation.GetNumerator() );
            Assert.Equal( 2, newRation.GetDenominator() );
        }

        [Fact]
        public void BinaryPlus_IntPlusInt_Rational()
        {
            //Act
            Rational newRation = 2 + 2;

            //Assert
            Assert.Equal( 4, newRation.GetNumerator() );
            Assert.Equal( 1, newRation.GetDenominator() );
        }

        [Fact]
        public void BinaryMinus_RationalMinusRational_Rational()
        {
            //Arrange
            var ration1 = new Rational( 1, 2 );
            var ration2 = new Rational( 3, 4 );

            //Act
            var newRation = ration2 - ration1;

            //Assert
            Assert.Equal( 1, newRation.GetNumerator() );
            Assert.Equal( 4, newRation.GetDenominator() );
        }

        [Fact]
        public void BinaryMinus_IntMinusRational_Rational()
        {
            //Arrange
            var ration1 = new Rational( 1, 2 );

            //Act
            var newRation = 1 - ration1;

            //Assert
            Assert.Equal( 1, newRation.GetNumerator() );
            Assert.Equal( 2, newRation.GetDenominator() );
        }

        [Fact]
        public void BinaryMinus_RationalMinusInt_Rational()
        {
            //Arrange
            var ration1 = new Rational( 5, 2 );

            //Act
            var newRation = ration1 - 1;

            //Assert
            Assert.Equal( 3, newRation.GetNumerator() );
            Assert.Equal( 2, newRation.GetDenominator() );
        }

        [Fact]
        public void BinaryMinus_IntMinusInt_Rational()
        {
            //Act
            Rational newRation = 2 - 2;

            //Assert
            Assert.Equal( 0, newRation.GetNumerator() );
            Assert.Equal( 1, newRation.GetDenominator() );
        }

        [Fact]
        public void BinaryMultyply_RationalMultRational_Rational()
        {
            //Arrange
            var ration1 = new Rational( 1, 2 );
            var ration2 = new Rational( 3, 4 );
            
            //Act
            Rational newRation = ration1 * ration2;

            //Assert
            Assert.Equal( 3, newRation.GetNumerator() );
            Assert.Equal( 8, newRation.GetDenominator() );
        }

        [Fact]
        public void BinaryMultyply_RationalMultInt_Rational()
        {
            //Arrange
            var ration1 = new Rational( 1, 2 );

            //Act
            Rational newRation = ration1 * 2;

            //Assert
            Assert.Equal( 1, newRation.GetNumerator() );
            Assert.Equal( 1, newRation.GetDenominator() );
        }

        [Fact]
        public void BinaryMultyply_IntMultRational_Rational()
        {
            //Arrange
            var ration1 = new Rational( 1, 2 );

            //Act
            Rational newRation = 2 * ration1;

            //Assert
            Assert.Equal( 1, newRation.GetNumerator() );
            Assert.Equal( 1, newRation.GetDenominator() );
        }


        [Fact]
        public void BinaryMultyply_IntMultInt_Rational()
        {
            //Act
            Rational newRation = 2 * 2;

            //Assert
            Assert.Equal( 4, newRation.GetNumerator() );
            Assert.Equal( 1, newRation.GetDenominator() );
        }

        [Fact]
        public void BinaryDivide_RationalDiciveRational_Rational()
        {
            //Arrange
            var ration1 = new Rational( 1, 2 );
            var ration2 = new Rational( 2, 1 );

            //Act
            Rational newRation = ration1 / ration2;

            //Assert
            Assert.Equal( 1, newRation.GetNumerator() );
            Assert.Equal( 4, newRation.GetDenominator() );
        }

        [Fact]
        public void BinaryDivide_RationalDivideInt_Rational()
        {
            //Arrange
            var ration1 = new Rational( 1, 2 );

            //Act
            Rational newRation = ration1 / 2;

            //Assert
            Assert.Equal( 1, newRation.GetNumerator() );
            Assert.Equal( 4, newRation.GetDenominator() );
        }

        [Fact]
        public void BinaryDivide_IntDivideRation_Rational()
        {
            //Arrange
            var ration1 = new Rational( 1, 2 );

            //Act
            Rational newRation = 2 / ration1;

            //Assert
            Assert.Equal( 4, newRation.GetNumerator() );
            Assert.Equal( 1, newRation.GetDenominator() );
        }

        [Fact]
        public void BinaryDivide_IntDivideInt_Rational()
        {

            //Act
            Rational newRation = 4 / 2;

            //Assert
            Assert.Equal( 2, newRation.GetNumerator() );
            Assert.Equal( 1, newRation.GetDenominator() );
        }

        [Fact]
        public void CompareOperatorsTests()
        {
            //Arrange
            var ration1 = new Rational( 1, 2 );
            var ration2 = new Rational( 4, 1 );
            var ration3 = new Rational( 3, 1 );
            var ration4 = new Rational( 2, 3 );

            //Assert
            Assert.True( ration1 == new Rational( 1, 2 ) );
            Assert.False( ration1 == ration2 );
            Assert.True( ration2 == 4 );
            Assert.False( ration1 == 7 );
            Assert.True( 3 == ration3 );
            Assert.False( 3 == ration4 );
            Assert.False( ration1 != new Rational( 1, 2 ) );
            Assert.True( ration1 != ration4 );
            Assert.False( ration2 != 4 );
            Assert.True( ration1 != 7 );
            Assert.False( 3 != ration3 );
            Assert.True( 3 != ration4 );
        }
    }
}
