public class FinishedScoreLineSignal {
    public readonly int ScoreBest;
    public readonly int Score;

    public FinishedScoreLineSignal(int scoreBest, int score) {
        ScoreBest = scoreBest;
        Score = score;
    }
}