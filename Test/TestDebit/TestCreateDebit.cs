using NUnit.Framework;
using Moq;
using idebitRepository;
using debit;

[TestFixture]
public class CreateTestDebit
{
    [Test]
    public async Task Create_ValidDebit_CreatesDebitInRepository()
    {
        
        var debitRepositoryMock = new Mock<IDebitRepository>();
        var createDebitUseCase = new CreateDebitUseCase(debitRepositoryMock.Object);

        var debitDto = new DebitDto
        {
          
            Value = 100,
            Description = "Test Debit",
            Type = "Entrada",
            Module = "TestModule"
        };

        
        await createDebitUseCase.create(debitDto);

      
        debitRepositoryMock.Verify(repo => repo.create(It.IsAny<Debit>()), Times.Once);
    }

    [Test]
    public void Create_InvalidDebitType_ThrowsException()
    {
       
        var debitRepositoryMock = new Mock<IDebitRepository>();
        var createDebitUseCase = new CreateDebitUseCase(debitRepositoryMock.Object);

        var invalidDebitDto = new DebitDto
        {
            
            Value = 100,
            Description = "Test Debit",
            Type = "InvalidType",  
            Module = "TestModule"
        };

        
        Assert.ThrowsAsync<Exception>(() => createDebitUseCase.create(invalidDebitDto));
    }
}
