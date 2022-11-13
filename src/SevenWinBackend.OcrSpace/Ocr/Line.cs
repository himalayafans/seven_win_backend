namespace SevenWinBackend.OcrSpace.Ocr;

internal class Line
{
    public string LineText { get; set; } = string.Empty;
    public List<Word> Words { get; set; } = new List<Word>();
    public double MaxHeight { get; set; }
    public double MinTop { get; set; }
}