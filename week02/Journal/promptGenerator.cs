public class PromptGenerator
{
    // public List<string> _prompts = new List<string>();
    private List<string> _prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is one small thing that went well today?",
        "What made me smile today?",
        "What is one thing I'm grateful for right now?",
        "What scripture or thoughts stayed with me?",
        "What did I accomplish today(big or small)?",
        "What would I tell my future self about today?",
        "Describe today in three words"
    };
    private Random _random = new Random();

    public string GetRandomPrompt()
    {
        if (_prompts.Count == 0) return "No prompts available.";
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}
