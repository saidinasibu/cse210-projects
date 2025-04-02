public class Scripture
{
    private Reference _reference;
    private List<Word> _words;


    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        foreach (string word in text.Split(new[] { ' ' }))
        {
            _words.Add(new Word(word));
        }
    }
    public int NumberToHide()
    {
        int x = _words.Count;
        int y = 2;

        while (true)
        {
            if (x % y == 0)
            {
                return y;
            }
            else
            {
                y++;
            }
        }
    }
    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        int count = 0;

        int remainingWords = _words.Count - _words.Count(w => w.isHidden());

        int wordsToHide = Math.Min(numberToHide, remainingWords);

        while (count < wordsToHide)
        {
            int index = random.Next(_words.Count);
            Word selectedWord = _words[index];

            if (!selectedWord.isHidden())
            {
                selectedWord.Hide();
                count++;
            }
        }
    }


    public string GetDisplayText()
    {

        string scriptureText = "";
        foreach (Word word in _words)

        {
            scriptureText += word.GetDisplayText() + " ";
        }

        return scriptureText.Trim();

    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.isHidden())
            {
                return false;
            }
        }
        return true;
    }

}