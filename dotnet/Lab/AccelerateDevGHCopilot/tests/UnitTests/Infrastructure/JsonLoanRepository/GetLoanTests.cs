namespace UnitTests.Infrastructure.JsonLoanRepositoryTests;

public class GetLoanTests
{

  private readonly Mock<ILoanRepository> _mockLoanRepository;
  private readonly Library.Infrastructure.Data.JsonLoanRepository _jsonLoanRepository;
  private readonly IConfiguration _configuration;
  private readonly JsonData _jsonData;

  public GetLoanTests()
  {
    _mockLoanRepository = new Mock<ILoanRepository>();

    string jsonDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "src", "Library.Console", "Json"));
    _configuration = new ConfigurationBuilder()
        .AddInMemoryCollection(new Dictionary<string, string>
        {
          ["JsonPaths:Authors"] = Path.Combine(jsonDirectory, "Authors.json"),
          ["JsonPaths:Books"] = Path.Combine(jsonDirectory, "Books.json"),
          ["JsonPaths:BookItems"] = Path.Combine(jsonDirectory, "BookItems.json"),
          ["JsonPaths:Patrons"] = Path.Combine(jsonDirectory, "Patrons.json"),
          ["JsonPaths:Loans"] = Path.Combine(jsonDirectory, "Loans.json")
        })
        .Build();

    _jsonData = new JsonData(_configuration);
    _jsonLoanRepository = new JsonLoanRepository(_jsonData);
  }

  [Fact]
  public async Task ShouldReturnLoan_WhenLoanIdExistsInData()
  {
    int loanId = 1;
    Loan expectedLoan = new Loan { Id = loanId };

    _mockLoanRepository.Setup(x => x.GetLoan(loanId))
        .ReturnsAsync(expectedLoan);

    Loan? actualLoan = await _jsonLoanRepository.GetLoan(loanId);

    Assert.NotNull(actualLoan);
    Assert.Equal(expectedLoan.Id, actualLoan!.Id);
  }

  [Fact(DisplayName = "JsonLoanRepository.GetLoan: Returns loan when loan ID is found")]
  public async Task GetLoan_ReturnsLoanWhenLoanIdIsFound()
  {
    // Arrange
    var loanId = 1; // Use a loan ID that exists in the Loans.json file
    var expectedLoan = new Loan
    {
      Id = loanId,
      BookItemId = 17,
      PatronId = 22,
      LoanDate = DateTime.Parse("2023-12-08T00:40:43.1808862"),
      DueDate = DateTime.Parse("2023-12-22T00:40:43.1808862"),
      ReturnDate = null
    };

    _mockLoanRepository.Setup(x => x.GetLoan(loanId))
        .ReturnsAsync(expectedLoan);

    // Act
    var actualLoan = await _jsonLoanRepository.GetLoan(loanId);

    // Assert
    Assert.NotNull(actualLoan);
    Assert.Equal(expectedLoan.Id, actualLoan?.Id);
  }
}