namespace SevenWinBackend.OcrSpace.Ocr;

internal class Word
{
    public string WordText { get; set; } = string.Empty;
    public double Left { get; set; }
    public double Top { get; set; }
    public double Height { get; set; }
    public double Width { get; set; }
}