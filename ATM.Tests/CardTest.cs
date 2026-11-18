namespace ATM.ATM.Tests;

using Xunit;

public class CardTest
{
    [Fact]
    public void InsertCardTest()
    {
        // Setup
        Account account = new(5000);
        // Given
        Card card = new("12345678", "1234", account);

        AtmService atm = new(5000);
        // When
        atm.InsertCard(card);
        // Then
        Assert.True(atm.HasCardInserted);

        atm.EjectCard();
        Assert.False(atm.HasCardInserted);
    }
}
