namespace ProductJudgeAPI.Entities;

public class Judge
{
    public int Id { get; set; }

    public string Text { get; set; } = string.Empty;

    public int UserId { get; set; }

    public User? User { get; set; }

    public int ProductId { get; set; }

    public Product? Product { get; set; }

}
