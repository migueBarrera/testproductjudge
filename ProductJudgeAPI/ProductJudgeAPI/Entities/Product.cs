﻿namespace ProductJudgeAPI.Entities;

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public ICollection<Judge> Judges { get; set; } = [];

    public IEnumerable<Barcode> Barcodes{ get; set; } = [];

    public int CategoryId { get; set; }
    public Category? Category { get; set; }

}
