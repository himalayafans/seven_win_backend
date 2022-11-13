namespace SevenWinBackend.OcrSpace.Ocr;

internal class TextOverlay
{
    public List<Line> Lines { get; set; } = new List<Line>();
    public bool HasOverlay { get; set; }
    public string Message { get; set; } = string.Empty;
}