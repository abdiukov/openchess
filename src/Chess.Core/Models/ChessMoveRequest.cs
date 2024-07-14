namespace Chess.Core.Models;

public class ChessMoveRequest
{
    public string Move { get; set; }
    public string? Fen { get; set; }
}
