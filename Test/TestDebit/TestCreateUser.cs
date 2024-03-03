using createUserUseCase;
using iUserRepository;
using Moq;
using NUnit.Framework;
using ProjectFinancas.Controllers.Dtos;
using ProjectFinancas.Domain.Validations.UserCase;
using user;


[TestFixture]
public class TestCreateUser
{
    [Test]
    public async Task CreateUser()
    {
        var userRepositoryMock = new Mock<IUserRepository>();
        var createUserUseCase = new CreateUserUseCase(userRepositoryMock.Object);

        var novoUsuarioDto = new UserDto
        {
            Name = "fernando",
            Email = "teste@gmail.com"
        };

        await createUserUseCase.Create(novoUsuarioDto);

        userRepositoryMock.Verify(repo => repo.Create(It.IsAny<User>()), Times.Once);

    }

    [Test]
    public async Task ErrorCreateEmail()
    {
        var userRepositoryMock = new Mock<IUserRepository>();
        var createUserUseCase = new CreateUserUseCase(userRepositoryMock.Object);

        var novoUsuarioDto = new UserDto
        {
            Name = "fernando",
            Email = "testegmailcom"
        };

        var validateUser = new ValidateUser();

        userRepositoryMock.Setup(x => x.FindByEmail(It.IsAny<string>())).ReturnsAsync(false);


        var exceptionCreate = Assert.ThrowsAsync<CustomError>(async () => await createUserUseCase.Create(novoUsuarioDto));
        Assert.That(exceptionCreate.Message, Is.EqualTo("Erro ao criar Usuario"));

        // Teste de exceção ao validar e-mail
        var exceptionValidate = Assert.Throws<CustomError>(() => validateUser.ValidateEmailFormat(novoUsuarioDto.Email));
        Assert.That(exceptionValidate.Message, Is.EqualTo("Erro ao criar Email"));
    }


}

