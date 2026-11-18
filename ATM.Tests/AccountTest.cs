namespace ATM.ATM.Tests;

using Xunit;

public class AccountTest
{
    [Fact]
    public void AccountHasBalanceTest()
    {
        Account account = new(10000);
        Assert.Equal(10000, account.Balance);
    }

    [Theory]
    [InlineData(5000, 5000, 0)]
    [InlineData(5000, 100, 4900)]
    [InlineData(5000, 6000, 5000)]
    [InlineData(5000, 0, 5000)]
    [InlineData(5000, -1000, 5000)]
    [InlineData(5000, 75, 5000)]
    public void TestName(int accountBalance, int withdraw, int expectedAccountBalance)
    {
        // Given
        Account account = new(accountBalance);
        Card card = new("12345678", "1234", account);
        AtmService atm = new(10000);
        atm.InsertCard(card);
        atm.EnterPin("1234");

        // When
        atm.Withdraw(withdraw);

        // Then
        int actualAccountBalance = account.GetBalance();
        Assert.Equal(expectedAccountBalance, actualAccountBalance);
    }
}
