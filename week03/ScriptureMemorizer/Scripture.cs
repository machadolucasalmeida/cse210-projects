public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] textWords = text.Split(new char[] { ' ', ',', '.', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string wordText in textWords)
        {
            _words.Add(new Word(wordText));
        }
    }
    public void HiddenRandomWords(int numberToHide)
    {
        Random random = new Random();
        int wordsHiddenCount = 0;

        while (wordsHiddenCount < numberToHide && !IsCompletelyHidden())
        {
            List<Word> unhiddenWords = _words.Where(Word => !Word.IsHidden()).ToList();
            if (unhiddenWords.Count == 0)
            {
                break;
            }
            int indexToHide = random.Next(0, unhiddenWords.Count);
            unhiddenWords[indexToHide].Hide();
            wordsHiddenCount++;
        }
    }
    public string GetDisplayText()
    {
        string scriptureText = "";
        foreach (Word word in _words) {
            scriptureText += word.GetDisplayText() + " ";
        }
        return $"{_reference.GetDisplayText()} \"{scriptureText.Trim()}\"";
    }
    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}