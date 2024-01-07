namespace Translator.models;

public class SubtitleModel
{
    public string Time { get; set; }

    public string Content { get; set; }

    public override string ToString()
    {
        return "\n" + Time + "\n" + Content + "\n";
    }
}