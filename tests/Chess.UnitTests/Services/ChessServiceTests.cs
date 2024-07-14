namespace Chess.UnitTests.Services;

using System.ComponentModel.DataAnnotations;
using Chess.Core.Services;
using Chess.Core.Models;
using NUnit.Framework;

[TestFixture]
public class ChessServiceTests
{
    private ChessService _chessService;

    [SetUp]
    public void Setup()
    {
        _chessService = new ChessService();
    }

    [Test]
    public void MakeMove_FailsWithInvalidMoveFormat()
    {
        var domain = new ChessMoveDomainModel { Fen = "e4", Move = "Qf" };
        Assert.Throws<ValidationException>(() => _chessService.MakeMove(domain));
    }

    [Test]
    public void MakeMove_FailsWithIncorrectMove()
    {
        var domain = new ChessMoveDomainModel { Fen = "e5", Move = "e7e5" };
        Assert.Throws<ValidationException>(() => _chessService.MakeMove(domain));
    }

    [Test]
    public void MakeMove_SucceedsWithCorrectData()
    {
        var domain = new ChessMoveDomainModel { Fen = "rnbqkbnr/pppppppp/8/8/4P3/8/PPPP1PPP/RNBQKBNR b KQkq e3 0 1",
            Move = "e7e5" };
        var result = _chessService.MakeMove(domain);
        Assert.That(result.Fen, Is.Not.Null.Or.Empty);
    }
}
