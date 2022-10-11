using Moq;
using Test.Application.Commands.Company;
using Test.Application.Validators.Company;
using Test.DbRepository;
using Test.Repository;
using Xunit;

namespace Test.Application.UnitTests;

public class CreateCompanyValidatorTests
{
    private readonly Mock<ICompanyRepository> _companyRepositoryMock = new();
    private readonly UnitOfWork _unitOfWorkMock;

    public CreateCompanyValidatorTests()
    {
        _unitOfWorkMock = new UnitOfWork(null, null, _companyRepositoryMock.Object, null);
    }

    [Fact]
    public async void CreateCompanyValidatorSucceededWhenCompanyDoesNotExist()
    {
        //Given
        var validator = new CreateCompanyValidator(_unitOfWorkMock);
        var createCompanyCommand = new CreateCompanyCommand("Valentin Plaza", "12345");

        _companyRepositoryMock.Setup(x => x.CompanyExistsAsync(createCompanyCommand.Code))
            .ReturnsAsync(false);

        //When
        var validationResult = await validator.Validate(createCompanyCommand);

        //Then
        Assert.True(validationResult.IsSuccessful);
    }
    
    [Fact]
    public async void CreateCompanyValidatorMustFailWhenCompanyExist()
    {
        //Given
        var validator = new CreateCompanyValidator(_unitOfWorkMock);
        var createCompanyCommand = new CreateCompanyCommand("Valentin Plaza", "12345");

        _companyRepositoryMock.Setup(x => x.CompanyExistsAsync(createCompanyCommand.Code))
            .ReturnsAsync(true);

        //When
        var validationResult = await validator.Validate(createCompanyCommand);

        //Then
        Assert.False(validationResult.IsSuccessful);
        Assert.Equal("Already exists", validationResult.Error);
    }
}